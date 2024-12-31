using UnityEngine;

public class BossSpawner : SpawnerBase
{
    [SerializeField] GameObject bossPrefab;
    SpawnerBase childSpawner;

    void Start()
    {
        GameObject boss = Instantiate(bossPrefab, spawnPos, Quaternion.identity);
        childSpawner = boss.GetComponentInChildren<SpawnerBase>();
    }

    // Update is called once per frame
    void Update()
    {
        if (childSpawner.spawningCompleted)
        {
            spawningCompleted = childSpawner.spawningCompleted;
            Destroy(childSpawner);
        }
    }
}
