using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour
{
    private const int ForwardDirection = 1;
    private const int ReverseDirection = -1;
    private const string IsForwardWalk = "IsForwardWalk";
    
    [SerializeField] private float _speed;

    private int _direction;
    private Animator _animator;

    private void Awake()
    {
        _direction = GetRandomDirection();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        if (_direction == ReverseDirection)
            _animator.SetBool(IsForwardWalk, false);     
    }

    private void Update()
    {
        float xPosition = transform.position.x;
        xPosition += _speed * _direction * Time.deltaTime;
        transform.position = new Vector2(xPosition, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Character>(out var component))
        {
            _direction = -_direction;
            ChangeMoveAnimation();
        }
    }

    private void ChangeMoveAnimation()
    {        
        if (_animator.GetBool(IsForwardWalk))        
            _animator.SetBool(IsForwardWalk, false);        
        else
            _animator.SetBool(IsForwardWalk, true);
    }

    private int GetRandomDirection()
    {              
        int randomNumber = Random.Range(0, 2);

        if (randomNumber == 0)
            return ForwardDirection;
        else
            return ReverseDirection;
    }
}
