using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower: MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    // platforms current position on index
    private int currentWaypointIndex = 0;
    // movementspeed of the platform
    private float speed = 2f;
    private void Update()
    {
        // calculate distance between two vectors
        // if platform is touching one waypoint ( distance < 0 ), tranform position to other waypoint
        if(Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            // if we are in the last waypoint
            if(currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        // move platform directly frame by frame
        // final argument defines how much we want to move our platform = two gameunits per second
        // deltatime assures, that no matter what the framerate is, platform moves only two gameunit per second
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
