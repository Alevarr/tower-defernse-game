using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform destination;
    public static int waypointIndex = 0;

    void Start()
    {
        destination = Waypoints.points[waypointIndex];

    }

    void Update()
    {
        Vector3 dir = destination.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, destination.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
        
    }

    void GetNextWaypoint()
    {
        if (!(waypointIndex == Waypoints.points.Length - 1))
        {
            
            waypointIndex++;
            destination = Waypoints.points[waypointIndex];

        }
        
    }

}
