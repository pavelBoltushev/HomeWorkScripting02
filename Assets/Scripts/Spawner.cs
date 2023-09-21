using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnPeriodicity;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var wait = new WaitForSeconds(_spawnPeriodicity);

        while (true)
        {
            yield return wait;

            int randomNumber = Random.Range(0, _spawnPoints.Length);
            Transform currentSpawnPoint = _spawnPoints[randomNumber];
            Instantiate(_character, currentSpawnPoint.position, Quaternion.identity);            
        }        
    }
}
