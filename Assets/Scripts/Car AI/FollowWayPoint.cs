using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWayPoint : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float checkDistanceofSecondWaypoint;
    [SerializeField] private int currentWaypoint = 0;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, waypoints[currentWaypoint].transform.position) < checkDistanceofSecondWaypoint)
            currentWaypoint++;

        if (currentWaypoint >= waypoints.Length)
            currentWaypoint = 0;

        //this.transform.LookAt(waypoints[currentWaypoint].transform.position);

        Quaternion waypointRotation = Quaternion.LookRotation(waypoints[currentWaypoint].transform.position - this.transform.position);

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, waypointRotation, rotationSpeed * Time.deltaTime);

        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
