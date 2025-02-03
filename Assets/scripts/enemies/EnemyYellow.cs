using System.Xml;
using UnityEngine;

public class EnemyYellow : EnemyBase
{
    protected override void HitFlower(Flower flower)
    {
        base.HitFlower(flower);
        Destroy(gameObject);
    }

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
