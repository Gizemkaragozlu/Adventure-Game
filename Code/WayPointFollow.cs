using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollow : MonoBehaviour
{
   public Vector2[] waypoints;
   private int currentWaypointIndex = 0;
   public float speed = 2f;
   private void Update()
    {
        if(Vector2.Distance(waypoints[currentWaypointIndex], transform.position) < .1f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex], Time.deltaTime* speed);
    
    }
    

   
}
