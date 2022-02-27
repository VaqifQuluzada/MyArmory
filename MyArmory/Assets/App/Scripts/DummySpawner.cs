using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummySpawner : MonoBehaviour
{
    [SerializeField] private GameObject dummyPrefab;

    [SerializeField] private Transform[] dummySpawnPoints;

    private GameObject currentDummy;

    private void Start()
    {
        InvokeRepeating("SpawnNewDummy", 0, 0.1f);
    }


    private void SpawnNewDummy()
    {
        if (currentDummy != null)
        {
            return;
        }

        int randomDummyPos = Random.Range(0, dummySpawnPoints.Length);
        Quaternion randomDummyRotation = Quaternion.Euler(0,Random.Range(0,180), 0);
        currentDummy = Instantiate(dummyPrefab, dummySpawnPoints[randomDummyPos].position, randomDummyRotation);
    }

    
}
