using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBase : MonoBehaviour
{
    public float coolDown;
    private float coolDownAge;
    
    // Start is called before the first frame update
    void Start()
    {
        coolDownAge = coolDown;
    }

    // Update is called once per frame
    void Update()
    {
        coolDownAge += Time.deltaTime;
        
        if (coolDownAge >= coolDown) 
        {
            Attack();
            coolDownAge = 0f;
        }
    }

    public abstract void Attack();
    
}
