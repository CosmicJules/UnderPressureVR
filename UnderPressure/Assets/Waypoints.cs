using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    //This script is used in order to make assets travel to waypoints on a loop, used for spider assets
    public GameObject[] waypoints;
    public GameObject player;
    int current = 0;
    public float speed;
    float WPradius = 1;

    void Update()
        //Constantly updates in order for the asset to search for waypoint and incrementally move towards the waypoint, once reached it will got to a new waypoint
    {
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            current = Random.Range(0, waypoints.Length);
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);

    }

    void OnTriggerEnter(Collider n)
    {
        if (n.gameObject == player)
        {
            player.transform.parent = transform;
        }
    }
    void OnTriggerExit(Collider n)
    {
        if (n.gameObject == player)
        {
            player.transform.parent = null;
        }
    }
}