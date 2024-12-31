using UnityEngine;

public class EnemyPurple : EnemyBase
{
    [SerializeField] float speedIncrement;

    override protected void HitBubble(Bubble bubble)
    {
        base.HitBubble(bubble);
        speed += speedIncrement;
    }
}
