using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semsor : MonoBehaviour
{
    [SerializeField] private float rayLength;
    [SerializeField] private float waitTime = 1;
    public bool canOvertake;

    [Header("sensor angle")]
    [SerializeField] private Transform car;
    [SerializeField] private float sensorAngle = 30;


    public void SensorHit()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * rayLength, Color.yellow) ;
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            if (hit.transform.CompareTag(TAGS.TAG_CAR))
            {
                print("hit by " + this.gameObject.name + " to " + hit.transform.name);
                StartCoroutine(WaitForOvertakeCar());
            }
        }
    }

    public void LeftAngleSensorhit()
    {
        Ray ray = new Ray(transform.position, Quaternion.AngleAxis(-sensorAngle + car.transform.rotation.y, car.up) * car.forward);
        Debug.DrawRay(transform.position, Quaternion.AngleAxis(-sensorAngle + car.transform.rotation.y, car.up) * car.forward * rayLength);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            if (hit.transform.CompareTag(TAGS.TAG_CAR))
            {
                print("hit by " + this.gameObject.name + " to " + hit.transform.name);
                StartCoroutine(WaitForOvertakeCar());
            }
        }
    }

    public void RightAngleSensorhit()
    {
        Ray ray = new Ray(transform.position, Quaternion.AngleAxis(sensorAngle + car.transform.rotation.y, car.up) * car.forward);
        Debug.DrawRay(transform.position, Quaternion.AngleAxis(sensorAngle + car.transform.rotation.y, car.up) * car.forward * rayLength);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            if (hit.transform.CompareTag(TAGS.TAG_CAR))
            {
                print("hit by " + this.gameObject.name + " to " + hit.transform.name);
                StartCoroutine(WaitForOvertakeCar());
            }
        }
    }


    IEnumerator WaitForOvertakeCar()
    {
        canOvertake = true;
        yield return new WaitForSeconds(waitTime);
        canOvertake = false;
    }
}
