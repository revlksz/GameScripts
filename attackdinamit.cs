using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class attackdinamit : AttackBase
{
    public bomb bombprefab;
    public float bombCircleRadius;
    public override void Attack()
    {
        Vector2 spawnPosition = Random.insideUnitCircle * bombCircleRadius;
        bomb spawned = Instantiate(bombprefab, spawnPosition, Quaternion.identity);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, bombCircleRadius);
    }


}
