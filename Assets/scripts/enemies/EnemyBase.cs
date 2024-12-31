using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Basic Enemy Values")]
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] int refreshRate;
    [SerializeField] float hitSpeed;
    [SerializeField] float hitRotSpeed = 10;

    // Tracker Values
    int refreshRateCounter = 0;
    protected Vector3 newPos;
    public Vector3 hitDir = Vector3.zero;


    void Awake()
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

    protected virtual void RefreshUpdate()
    {
        if (hitDir == Vector3.zero)
        {
            newPos.x -= speed;
            transform.position = newPos;
        }
        else
        {
            transform.position += hitDir * hitSpeed;
            transform.Rotate(Vector3.forward * hitRotSpeed * Mathf.Sign(hitDir.y));
        }
        
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
        else if (other.TryGetComponent<EnemyBoss>(out EnemyBoss boss))
        {
            HitBoss(boss);
        }
        else if (other.TryGetComponent<EnemyBase>(out EnemyBase enemy))
        {
            HitEnemy(enemy);
        }
        else if (other.TryGetComponent<PlayerController>(out PlayerController player))
        {
            HitPlayer(player);
        }
    }

    protected virtual void HitFlower(Flower flower)
    {
        flower.Destroy();
    }

    protected virtual void HitBubble(Bubble bubble)
    {
        health -= 1;
        bubble.Destroy();
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void HitPlayer(PlayerController player)
    {
        Debug.Log("Killed Player!");
        Destroy(gameObject);
    }

    protected virtual void HitEnemy(EnemyBase enemy)
    {
        if (hitDir == Vector3.zero)
        {
            hitDir = transform.position - enemy.transform.position;
        }
        else
        {
            Destroy(gameObject);   
        }
    }

    protected virtual void HitBoss(EnemyBoss boss)
    {
        if (hitDir == Vector3.zero)
        {
            return;
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
