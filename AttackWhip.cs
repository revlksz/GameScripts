using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWhip : AttackBase
{
    public float circleRadius;
    public float whipDistance;
    public LayerMask EnemyLayer;
    public float damage=> UpgradeManager.Instance.whipLevelp.value;
    public override void Attack()
    {
        RaycastHit2D[] right = Physics2D.CircleCastAll(transform.position, circleRadius, Vector2.right, whipDistance, EnemyLayer);
        RaycastHit2D[] left = Physics2D.CircleCastAll(transform.position, circleRadius, Vector2.left, whipDistance, EnemyLayer);
        
        foreach (RaycastHit2D enemy in right)
        {
            if (enemy.collider.TryGetComponent<EnemyBase>(out EnemyBase enemyscript))
            {
                enemyscript.enemyTakeDamage(damage);
            }
        }
        foreach (RaycastHit2D enemy in left)
        {
            if (enemy.collider.TryGetComponent<EnemyBase>(out EnemyBase enemyscript))
            {
                enemyscript.enemyTakeDamage(damage);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, circleRadius);
        var left = transform.position + (Vector3)(Vector2.left * whipDistance);
        Gizmos.DrawWireSphere(left, circleRadius);
        var right = transform.position + (Vector3)(Vector2.right * whipDistance);
        Gizmos.DrawWireSphere(right, circleRadius);
    }
    
}
