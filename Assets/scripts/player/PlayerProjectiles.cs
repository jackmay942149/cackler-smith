using UnityEngine;

public class PlayerProjectiles : MonoBehaviour
{
    [SerializeField] GameObject bubblePrefab;
    [SerializeField] GameObject flowerPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SpawnBubble();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SpawnFlower();
        }
    }

    void SpawnBubble()
    {
        Instantiate(bubblePrefab, transform.position, Quaternion.identity);
    }

    void SpawnFlower()
    {
        Instantiate(flowerPrefab, transform.position, Quaternion.identity);
    }
}
