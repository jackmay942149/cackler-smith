using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public struct EnemySpawnWeight
{
    public EnemyColor color;
    public float spawnWeight;
}

public class RandomSpawner : SpawnerBase
{
    [SerializeField] int waveCount;
    [SerializeField] List<EnemySpawnWeight> enemySpawnWeights;
    Wave waveToSpawn;

    void Start()
    {
        InvokeRepeating("SpawnUpdate", spawnRate, spawnRate);

        float weightChecker = 0.0f;
        foreach (EnemySpawnWeight weight in enemySpawnWeights)
        {
            weightChecker += weight.spawnWeight;
        }
        if (weightChecker != 1.0f)
        {
            Debug.LogWarning("Random Spawner has weights not equal to 1");
        }
    }

    public void SpawnUpdate()
    {
        SpawnWave(RandomWave());
        waveCounter++;

        if (waveCounter == waveCount)
        {
            CancelInvoke("SpawnUpdate");
            spawningCompleted = true;
        }

    }

    Wave RandomWave()
    {

        waveToSpawn.elements = new List<EnemyColor>();
        for (int j = 0; j < 5; j++)
        {
            float rng = UnityEngine.Random.Range(0.0f, 1.0f);
            for (int i = 0; i < enemySpawnWeights.Count; i++)
            {
                if (enemySpawnWeights[i].spawnWeight < rng)
                {
                    rng -= enemySpawnWeights[i].spawnWeight;
                    continue;
                }

                waveToSpawn.elements.Add(enemySpawnWeights[i].color);
                break;
            }
        }
        
        return waveToSpawn;
    }
}
