using System.Linq.Expressions;
using UnityEngine;

public class BallloonSpawner : MonoBehaviour
{
    [SerializeField] GameObject balloonPrefab;
    [SerializeField] float xSpawnPos;
    [SerializeField] Vector2 ySpawnPos;
    [SerializeField] float repeatRate;

    Vector3 spawnPos = new Vector3();

    void Start()
    {
        spawnPos.x = xSpawnPos;
        spawnPos.z = transform.position.z;

        InvokeRepeating("SpawnBalloon", 0.0f, repeatRate);
    }

    void SpawnBalloon()
    {
        spawnPos.y = Random.Range(ySpawnPos.x, ySpawnPos.y);
        Instantiate(balloonPrefab, spawnPos, Quaternion.identity);
    }
}
