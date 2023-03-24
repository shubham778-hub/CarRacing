using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGroundRay : MonoBehaviour
{

    [SerializeField] private Transform groundRayPosition;
    [SerializeField] private float rayLenght;
    [SerializeField] private LayerMask collisionLayer;


    public bool CheckGroundCollision()
    {
        Debug.DrawRay(groundRayPosition.position, -transform.up * rayLenght, Color.red);
        if (Physics.Raycast(groundRayPosition.position, -transform.up, out RaycastHit hit, rayLenght, collisionLayer))
        {
            //print("On the road");
            return true;
        }
        else
        {
            //int("Flying in the air");
            return false;
        }
    }


}
