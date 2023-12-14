using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject obstacle;
    public GameObject shieldIcon;
    public VariableHandlerObject variableHandler;
    public float spawnDelay;
    public float scoreZoneWidth;
    public float shieldSpawnPercentage;
    
    private readonly Vector3 _spawnPosition = new Vector3(12f,0f,0f);
    private float _speedMultiplier;
    private readonly float _upperLimit = 5;
    private readonly float _lowerLimit = -5;
    // Start is called before the first frame update
    void Start()
    {
        variableHandler.SpeedMultiplier.spawnDelay = spawnDelay;
        _speedMultiplier = variableHandler.SpeedMultiplier.multiplierValue;
        StartCoroutine(WaitAndSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    } 

    IEnumerator WaitAndSpawn()
    {
        float randomNumber;
        float seconds = spawnDelay;
        while (true)
        {
            if(variableHandler.Player.isAlive)
            {
                randomNumber = Random.Range(_lowerLimit+scoreZoneWidth/2f+0.5f, _upperLimit-scoreZoneWidth/2f-0.5f);
                Instantiate(obstacle, (_spawnPosition + Vector3.up * randomNumber), Quaternion.identity);
            }
            yield return new WaitForSeconds(seconds/2);
            SpawnShield();
            yield return new WaitForSeconds(seconds/2);
            _speedMultiplier = variableHandler.SpeedMultiplier.multiplierValue;
            seconds = spawnDelay / _speedMultiplier;
            
        }
    }
    
    void SpawnShield()
    {
        float randomNumber = Random.Range(1f, 100f);;
        if(variableHandler.Player.isAlive && randomNumber <= shieldSpawnPercentage )
        {
            randomNumber = Random.Range(_lowerLimit+scoreZoneWidth/2f, _upperLimit-scoreZoneWidth/2f);
            Instantiate(shieldIcon, (_spawnPosition + Vector3.up * randomNumber), Quaternion.identity);

        }
        
    }
}
