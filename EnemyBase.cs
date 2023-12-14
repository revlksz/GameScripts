using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    
    public EnemyType type;
    public float enemyHealth;
    public void enemyTakeDamage(float damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void Awake()
    {
        enemyHealth = type.enemy.enemyHealth;
    }
    private void Update()
    {
        var direction = Player.Instance.transform.position-transform.position;//yöne dikkat et
        transform.position += direction * type.enemy.enemySpeed * Time.deltaTime;
    }
}
