using UnityEngine;

public class EnemyGreen : EnemyBase
{
    protected override void HitPlayer(PlayerController player)
    {
        hitDir = transform.position - player.transform.position;
    }
}