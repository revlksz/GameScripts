using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variable Handler Object")]
public class VariableHandlerObject : ScriptableObject
{
    // Start is called before the first frame update
    public SpeedMultiplierClass SpeedMultiplier;
    public PlayerClass Player;
    
    [System.Serializable]
    public class SpeedMultiplierClass
    {
        public float multiplierValue;
        
        [NonSerialized]
        public float spawnDelay;
    }
    
    [System.Serializable]
    public class PlayerClass
    {
        public bool isAlive;
    }
}
