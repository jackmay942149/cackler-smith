using UnityEngine;

public class EnemyRed : EnemyBase
{
    protected override void HitBubble(Bubble bubble)
    {
        health -= 1;
        bubble.Destroy();
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
