using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float speedMultiplier;
    public float obstacleSpeed;
    public int destructionCoordinate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
        {
            transform.Translate(Vector3.left*Time.deltaTime*speedMultiplier*obstacleSpeed);
        }
        
        if (transform.position.x < destructionCoordinate)
        {
            Destroy(gameObject);
        }
    }
}
    