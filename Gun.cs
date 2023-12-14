using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Gun : AttackBase
{
    public Bullet bulletPrefab => UpgradeManager.Instance.gunLevelp.value;//prefab eklenecek


    public override void Attack()
    {
        var bulletspawned = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bulletspawned.Direction = Vector2.left;
        var bulletspawned2 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bulletspawned2.Direction = Vector2.right;

    }
    
}
