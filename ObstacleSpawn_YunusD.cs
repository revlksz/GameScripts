using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleSpawn : MonoBehaviour
{

    public  GameObject obstacle;
    public float spawnDelay;
    public float speedMultiplier;
    public Vector3 spawnPosition;
    public bool playerAlive;
    public float obstacleSpaceWidth;
    public float obstacleLength;
    public float upperLimit;
    public float lowerLimit;
    // Start is called before the first frame update
    void Start()
    {
        obstacle.transform.Find("UpperObstacle").transform.position = Vector3.up * (obstacleSpaceWidth + obstacleLength)/2f;
        obstacle.transform.Find("LowerObstacle").transform.position =  Vector3.down * (obstacleSpaceWidth + obstacleLength)/2f;
        obstacle.transform.Find("ScoreZone").transform.position = Vector3.zero;
        StartCoroutine(WaitAndSpawn(spawnDelay / speedMultiplier));
    }

    // Update is called once per frame
    void Update()
    {
        
    } 

    IEnumerator WaitAndSpawn(float seconds)
    {
        while(playerAlive)
        {
            float randomNumber = Random.Range(lowerLimit+obstacleSpaceWidth/2f+1f, upperLimit-obstacleSpaceWidth/2f-1f);
            Instantiate(obstacle, (spawnPosition + Vector3.up * randomNumber), Quaternion.identity);
            yield return new WaitForSeconds(seconds);
        }
    }
}
