using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variable Handler")]
public class VariableHandler : ScriptableObject
{
    public PlayerClass Player;
    public EnemyClass Enemy;
    public attackClass Attack;
    [System.Serializable]
    public class PlayerClass
    {
        public bool isAlive;
        public float health=100f;
        public float maxHealth = 100f;

    }
    [System.Serializable]
    public class EnemyClass
    {
        public float bulletDamage = 5f;
    }
    public class attackClass
    {
        
    }

}
