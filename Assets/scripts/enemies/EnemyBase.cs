using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Basic Enemy Values")]
    [SerializeField] int health;
    [SerializeField] float speed;
    [SerializeField] int refreshRate;

    // Tracker Values
    int refreshRateCounter = 0;
    Vector3 newPos;


    void Start()
    {
        newPos = transform.position;
    }

    void FixedUpdate()
    {
        if (refreshRateCounter == refreshRate)
        {
            RefreshUpdate();
            refreshRateCounter = 0;
        }
        else
        {
            refreshRateCounter++;
        }
    }

    void RefreshUpdate()
    {
        newPos.x -= speed;
        transform.position = newPos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.TryGetComponent<Bubble>(out Bubble bubble))
        { 
            HitBubble(bubble);
        }
        else if (other.TryGetComponent<Flower>(out Flower flower))
        {
            HitFlower(flower); 
        }
    }

    protected virtual void HitFlower(Flower flower)
    {
        flower.Destroy();
    }

    protected void HitBubble(Bubble bubble)
    {
        health -= 1;
        if (health == 0)
        {
            Destroy(gameObject);
        }
        bubble.Destroy();
    }

}
