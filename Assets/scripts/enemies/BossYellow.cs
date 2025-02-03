using UnityEngine;

public class BossYellow : EnemyBoss
{
    [SerializeField] Vector2 xPositions = new Vector2();

    private void Update()
    {
        base.Update();
        if (Mathf.Abs(transform.position.x - xPositions[0]) < minDist)
        {
            minXPos = xPositions[1];
        }
        else if (Mathf.Abs(transform.position.x - xPositions[1]) < minDist)
        {
            minXPos = xPositions[0];
        }
    }

    protected override void HitBubble(Bubble bubble)
    {
        bubble.Destroy();
    }

    protected override void HitFlower(Flower flower)
    {
        sr.sprite = hitSprite;
        delayTimer = 0.0f;

        health -= 1;
        if (health == 0)
        {
            spawner.transform.parent = null;
            spawner.spawningCompleted = true;
            Destroy(gameObject);
        }
        base.HitFlower(flower);
    }
}
