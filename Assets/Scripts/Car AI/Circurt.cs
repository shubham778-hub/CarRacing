using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circurt : MonoBehaviour
{

    public Transform[] wayPoints;

    private void OnDrawGizmos()
    {
        if(wayPoints.Length > 1)
        {
            Vector3 firstWaypoint = wayPoints[0].transform.position;

            for(int i = 0; i < wayPoints.Length; i++)
            {
                Vector3 nextPoint = wayPoints[i].transform.position;
                Gizmos.DrawLine(firstWaypoint, nextPoint);
                firstWaypoint = nextPoint;
            }

            Gizmos.DrawLine(firstWaypoint, wayPoints[0].transform.position);
        }
    }
}
