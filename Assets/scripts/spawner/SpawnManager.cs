using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> spawners = new List<GameObject>();
    SpawnerBase currSpawner;
    int currSpawnInd = 0;

    private void Start()
    {
        currSpawner = Instantiate(spawners[currSpawnInd]).GetComponent<SpawnerBase>();
    }

    private void Update()
    {
        if (currSpawner.spawningCompleted)
        {
            currSpawnInd++;
            Destroy(currSpawner.gameObject);
            if (currSpawnInd == spawners.Count)
            {
                Debug.LogWarning("No Spawners Left To Spawn");
                Destroy(gameObject);
            }
            else
            {
                currSpawner = Instantiate(spawners[currSpawnInd]).GetComponent<SpawnerBase>();
            }
            
        }
    } 

}
