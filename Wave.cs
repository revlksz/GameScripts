using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave")]
public class Wave : ScriptableObject
{
    public int spawnAmount;
    public EnemyBase[] enemyType;
    public float nextWaveTime;
}
