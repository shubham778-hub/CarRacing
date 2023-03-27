using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidOtherCar : MonoBehaviour
{

    [Header ("Sensors")]
    [SerializeField] private Semsor rightSensor; 
   // [SerializeField] private Semsor centerSensor; 
    [SerializeField] private Semsor leftSensor; 
    [SerializeField] private Semsor rightAngleSensor; 
    [SerializeField] private Semsor leftAngleSensor; 

    [Space]
    [SerializeField] private Transform car;
    [SerializeField] private int numberofrays;
    [SerializeField] private int angle;
    [SerializeField] private float rayLength;
    [SerializeField] private Vector3 rightSide;
    [SerializeField] private Vector3 leftSide;
    [SerializeField] private float rightFrontSensorAngle;
    [SerializeField] private float leftFrontSensorAngle;

    [SerializeField] private bool canOvertake;
    public bool rightSideClear;
    public bool leftSideClear;

    void Update()
    {
        rightSensor.SensorHit();
        leftSensor.SensorHit();
        rightAngleSensor.RightAngleSensorhit();
        leftAngleSensor.LeftAngleSensorhit();
        rightSideClear = rightSensor.canOvertake;
        leftSideClear = leftSensor.canOvertake;
       


        /*
        Vector3 sensorPosition = transform.position;



        Debug.DrawRay(sensorPosition, car.transform.forward * rayLength, Color.blue);
        Debug.DrawRay(sensorPosition + rightSide, car.forward * rayLength, Color.blue);
        Debug.DrawRay(sensorPosition + leftSide, car.forward * rayLength, Color.blue);
        Debug.DrawRay(sensorPosition + leftSide, Quaternion.AngleAxis(leftFrontSensorAngle + car.transform.rotation.y, car.up) * car.forward * rayLength, Color.red);
        Debug.DrawRay(sensorPosition + rightSide, Quaternion.AngleAxis(rightFrontSensorAngle + car.transform.rotation.y, car.up) * car.forward * rayLength, Color.yellow);

        RaycastHit hit;


        //RAY FROM CENTER OF CAR
        if (Physics.Raycast(sensorPosition, transform.forward, out hit, rayLength))
        {
            if (hit.transform.CompareTag(TAGS.TAG_CAR))
            {
               // print("Center hit");
                canOvertake = true;
            }
            else
            {
                canOvertake = false;
            }
        }

        //RAY FROM RIGHT SIDE OF CAR
        if (Physics.Raycast(sensorPosition + rightSide, transform.forward, out hit, rayLength))
        {
            if (hit.transform.CompareTag(TAGS.TAG_CAR))
            {
               // print("Rughrt hit");
                canOvertake = true;
            }
            else
            {
                canOvertake = false;
            }
        }
        //RAY FROM RIGHT SIDE WITH ANGLE
        Vector3 rightAngle = Quaternion.AngleAxis(rightFrontSensorAngle, car.transform.up) * car.transform.forward;
        if (Physics.Raycast(sensorPosition + rightSide, rightAngle, out hit, rayLength))
        {
            if (hit.transform.CompareTag(TAGS.TAG_CAR))
            {
               // print("has car right");
                rightSideClear = false;
                canOvertake = true;
            }
            else
            {
                // print("right sidew clear");
                canOvertake = false;
                rightSideClear = true;
            }
        }

        //RAY FROM LEFT SIDE OF CAR
        if (Physics.Raycast(sensorPosition + leftSide, transform.forward, out hit, rayLength))
        {
            if (hit.transform.CompareTag(TAGS.TAG_CAR))
            {
               // print("left hit");
                canOvertake = true;
            }
            else
            {
                canOvertake = false;
            }
        }

        //RAY FROM LEFT SIDE WITH ANGLE
        Vector3 leftAngle = Quaternion.AngleAxis(leftFrontSensorAngle, car.transform.up) * car.transform.forward;
        if (Physics.Raycast(sensorPosition + leftSide, leftAngle, out hit, rayLength))
        {
            if (hit.transform.CompareTag(TAGS.TAG_CAR))
            {
               // print("left side has car");
                leftSideClear = false;
                canOvertake = true;
            }
            else
            {
                //print("left side is clear");
                leftSideClear = true;
                canOvertake = false;
            }
        }
        */
    }

    public bool CanOvertake()
    {
        return canOvertake;
    }

}
