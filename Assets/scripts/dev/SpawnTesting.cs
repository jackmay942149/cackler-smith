using UnityEngine;
using System.Collections.Generic;

public class SpawnTesting : MonoBehaviour
{
    [Header("Spawn Information")]
    [SerializeField] List<GameObject> enemyWave = new List<GameObject>();
    [SerializeField] List<float> spawnYPositions = new List<float>();
    [SerializeField] float spawnRate;
    [SerializeField] float spawnXPos;

    // Tracker Information
    bool isSpawning = true;
    Vector3 spawnPos = Vector3.zero;

    private void Start()
    {
        InvokeRepeating("SpawnWave", spawnRate, spawnRate);
        spawnPos.x = spawnXPos;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            isSpawning = !isSpawning;
        }
    }

    public void SpawnWave()
    {
        if (!isSpawning)
        {
            return;
        }

        for (int i = 0; i < enemyWave.Count; i++)
        {
            spawnPos.y = spawnYPositions[i];
            Instantiate(enemyWave[i], spawnPos, Quaternion.identity);
        }
    }
}
