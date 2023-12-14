using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollowerSC : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    public ScriptableObject1 change_global_value;
    private int currentWaypointIndex=0;
    public float platform_speed=2f;
    // Update is called once per frame
    void Update()
    {
        if (change_global_value.platform.active)
        {
            if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * platform_speed);
        }
    }
}
