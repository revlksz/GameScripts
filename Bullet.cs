using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 20f;
    public float lifeDuration = 5f;
    public Vector2 Direction;
    public float bulletDamage;
    

    private float _lifeTimer = 0f;
    private void Update()
    {
        var direction = ((Vector3)Direction).normalized;
        

        transform.position += Speed * Time.deltaTime * direction;

        _lifeTimer += Time.deltaTime;
        if (_lifeTimer >= lifeDuration)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.gameObject.TryGetComponent<EnemyBase>(out EnemyBase enemyscript))
        {
            enemyscript.enemyTakeDamage(bulletDamage);
        }
    }
}
