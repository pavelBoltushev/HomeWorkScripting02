using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _character;
    [SerializeField] private GameObject[] _spawnPoints;
    [SerializeField] private float _spawnPeriodicity;

    private float _timeCounter = 0;

    private void Update()
    {
        _timeCounter += Time.deltaTime;

        if (_timeCounter > _spawnPeriodicity)
        {
            _timeCounter = 0;
            int randomNumber = Random.Range(0, _spawnPoints.Length);
            GameObject currentSpawnPoint = _spawnPoints[randomNumber];
            Instantiate(_character, currentSpawnPoint.transform.position, Quaternion.identity);
        }
    }
}
