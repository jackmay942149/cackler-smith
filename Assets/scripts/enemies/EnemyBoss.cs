using UnityEngine;

public class EnemyBoss : EnemyBase
{
    // Cap Movement xpos
    // Stop Hit Direction Stuff
    // Lose Health on hit
    [SerializeField] float minXPos;
    RandomSpawner spawner;


    

    private void Start()
    {
        spawner = GetComponentInChildren<RandomSpawner>();
    }

    private void Update()
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

        newPos.x -= speed;
        if (newPos.x > minXPos)
        {
            transform.position = newPos;
        }
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
