using System;
using System.Collections.Generic;
using UnityEngine;

[SerializeField] public enum EnemyColor
{
    Green,
    Blue,
    Orange,
    Red,
    Yellow,
    Purple,
    None
}

[Serializable] public struct Wave
{
    public List<EnemyColor> elements;
}

public class SpawnerBase : MonoBehaviour
{
    [SerializeField] protected float spawnRate;
    [SerializeField] float xSpawnPos;
    [SerializeField] List<float> ySpawnPos = new List<float>();
    [SerializeField] List<GameObject> enemyPrefabs;
    Vector3 spawnPos = Vector3.zero;
    [HideInInspector] public bool spawningCompleted = false;
    protected int waveCounter = 0;

    private void Awake()
    {
        spawnPos.x = xSpawnPos;
    }

    protected void SpawnWave(Wave wave)
    {
        for (int i = 0; i < wave.elements.Count; i++)
        {
            if (i==5)
            {
                foreach (EnemyColor enemyColor in wave.elements)
                {
                    Debug.Log(enemyColor);
                }
                
            }

            spawnPos.y = ySpawnPos[i];
            if (wave.elements[i] != EnemyColor.None)
            {
                Instantiate(enemyPrefabs[(int) wave.elements[i]], spawnPos, Quaternion.identity);
            }
        }
    }

    
}
