using UnityEngine;

public class PlayerProjectiles : MonoBehaviour
{
    [SerializeField] GameObject bubblePrefab;
    [SerializeField] GameObject flowerPrefab;

    // trackers
    PlayerController pc;

    void Start(){
       pc = GetComponent<PlayerController>(); 
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !pc.gamePaused)
        {
            SpawnBubble();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && !pc.gamePaused)
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
