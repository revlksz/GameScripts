using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public float bombcoolDown;
    private float bombcoolDownAge;
    public float bombradius;
    public float bombDamage=> UpgradeManager.Instance.bombLevelp.value;// herkes ölsün istesek 9999 yap;
    
    void Update()
    {
        bombcoolDownAge += Time.deltaTime;

        if (bombcoolDownAge >= bombcoolDown)
        {// patlayýnca oalcaklar buraya eklenek partical,ses gibi;
            var bombhits = Physics2D.OverlapCircleAll(transform.position, bombradius);

            foreach (var enemy in bombhits)
            {
                if (enemy.TryGetComponent<EnemyBase>(out EnemyBase enemyscript))
                {
                    enemyscript.enemyTakeDamage(bombDamage);
                    
                }
            }
            Destroy(gameObject);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, bombradius);// damage alaný için kullanýlýr.
    }
}
