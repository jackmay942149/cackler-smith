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

    protected override void RefreshUpdate()
    { 
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

        if (health == 1) // health gets reduced in base func
        {
            spawner.transform.parent = null;
            spawner.spawningCompleted = true;
        }
        base.HitBubble(bubble);
    }
}
