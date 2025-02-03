using UnityEngine;

public class EnemyBoss : EnemyBase
{
    // Cap Movement xpos
    // Stop Hit Direction Stuff
    // Lose Health on hit
    [SerializeField] protected float minXPos;
    protected float minDist = 0.2f;
    protected RandomSpawner spawner;


    

    private void Start()
    {
        spawner = GetComponentInChildren<RandomSpawner>();
    }

    protected void Update()
    {
        delayTimer += Time.deltaTime;
    }

    protected override void RefreshUpdate()
    {   
        if (delayTimer > hitDelay)
        {
            sr.sprite = defaultSprite;
            delayTimer = 0;
        }

        newPos.x = transform.position.x;
        if (newPos.x - speed > minXPos)
        {
            newPos.x -= speed;
        }
        else if (newPos.x + speed < minXPos)
        {
            newPos.x += speed;
        }
        transform.position = newPos;
    }

    protected override void HitEnemy(EnemyBase enemy)
    {
        if (enemy.hitDir == Vector3.zero)
        {
            return;
        }

        sr.sprite = hitSprite;
        delayTimer = 0.0f;

        health -= 1;
        if (health == 0)
        {
            spawner.transform.parent = null;
            spawner.spawningCompleted = true;
            Destroy(gameObject);
        }
    }

    protected override void HitBubble(Bubble bubble)
    {
        sr.sprite = hitSprite;
        delayTimer = 0.0f;

        if (health == 1) // health gets reduced in base func
        {
            spawner.transform.parent = null;
            spawner.spawningCompleted = true;
        }
        base.HitBubble(bubble);
    }
}
