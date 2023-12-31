using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {        
        if (collision.TryGetComponent<Character>(out var component))
            Destroy(collision.gameObject);          
    }
}
