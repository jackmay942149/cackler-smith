using UnityEngine;

public class EnemyYellow : EnemyBase
{
    protected override void HitFlower(Flower flower)
    {
        base.HitFlower(flower);
        Destroy(gameObject);
    }
}
