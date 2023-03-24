using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semsor : MonoBehaviour
{
    [SerializeField] private float rayLength;


    public bool SensorHit()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * rayLength, Color.yellow) ;
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit , rayLength))
        {
            if (hit.transform.CompareTag(TAGS.TAG_CAR))
            {
                print("hit by " + this.gameObject.name + " to " + hit.transform.name);
                return true;
            }
        }

        return false;
    }
}
