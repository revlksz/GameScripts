using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackstar : AttackBase
{
    public Bullet starPrefabs;//prefab eklenecek
    
    public override void Attack()
    {
        var bulletspawned = Instantiate(starPrefabs, transform.position, Quaternion.identity);
        bulletspawned.Direction = Player.Instance.moveDirection * -1;
    }

}
