using UnityEngine;
using System.Collections.Generic;

public class FixedSpawner : SpawnerBase
{
    [SerializeField] List<Wave> waves = new List<Wave>();
    int waveCounter = 0;

    void Start()
    {
        InvokeRepeating("SpawnUpdate", spawnRate, spawnRate);
    }

    public void SpawnUpdate()
    {
        SpawnWave(waves[waveCounter]);
        waveCounter++;

        if (waveCounter == waves.Count)
        {
            CancelInvoke("SpawnUpdate");
            spawningCompleted = true;
        }

    }
}