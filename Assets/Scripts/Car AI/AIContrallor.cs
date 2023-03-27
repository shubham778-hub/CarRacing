using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIContrallor : MonoBehaviour
{

    [Header("Required Sctipts")]
    [SerializeField] private CheckGroundRay checkGround;
    [SerializeField] private AvoidOtherCar avoidCar;
    [SerializeField] private CarFule carfule;

    [Header("Car Property")]
    [Range(0,300)] [SerializeField] private float currentSpeed;
    [Range(0,1000)] [SerializeField] private float turnSpeed;
    [SerializeField] private float currentSteeringAngle; //TURN VALUE OF CAR
    [SerializeField] private float groundForce;
    [SerializeField] private float avoidForce;
    [SerializeField] private GameObject centerOfMass;
    [SerializeField] private float avoidanceFloce;


    [Space]
    [Header("For Debugging")]
    [SerializeField] private Vector3 traget;
    [SerializeField] private int currentWP;
    [SerializeField] private bool _isGroundTouch;

    private Rigidbody carBody;
    private bool isFuleRefling;
    private float _currentSpeed;


    // Start is called before the first frame update
    void Start()
    {
        checkGround = GetComponentInChildren<CheckGroundRay>();
        carBody = GetComponent<Rigidbody>();
        avoidCar = GetComponentInChildren<AvoidOtherCar>();
        carfule = GetComponent<CarFule>();
        SetCurrentWaypoint();
        _currentSpeed = currentSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfGroundTouch();
        CheckRelatibePosition();
    }

    private void FixedUpdate()
    {
        MoveCar();
       // CheckSensorHit();
        CarSteer();
    }

    public void CheckIfGroundTouch()
    {
        if (checkGround.CheckGroundCollision())
        {
            _isGroundTouch = true;
           // print("not in air");
        }
        else
        {
            _isGroundTouch = false;
         //   print("is in air");
        }
    }


    private void CarSteer()
    {
        //if (!_isGroundTouch)
        //  return;
        if (avoidCar != null)
        {
            if (avoidCar.rightSideClear == true)
            {
                print("Turing left");
                transform.eulerAngles += Vector3.up * -avoidanceFloce * turnSpeed * Time.deltaTime;
            } else if (avoidCar.leftSideClear == true)
            {
                print("Turing right");
                transform.eulerAngles += Vector3.up * avoidanceFloce * turnSpeed * Time.deltaTime;
            }
            else
            {
                transform.eulerAngles += Vector3.up * currentSteeringAngle * turnSpeed * Time.deltaTime;
            }
        }
    }


    private void CheckSensorHit()
    {
        float avoidanceFloce = 0;

        if(avoidCar != null)
        {
            if(avoidCar.CanOvertake() == true)
            {
                if (!avoidCar.rightSideClear)
                {
                    avoidanceFloce = -1;
                    print("Turn left side");
                }

                if (!avoidCar.leftSideClear)
                {
                    avoidanceFloce = 1;
                    print("Turn right side");
                }

                transform.eulerAngles += Vector3.up * avoidanceFloce * turnSpeed * Time.deltaTime;
            }
        }
    }

    private void CheckRelatibePosition()
    {
        Vector3 tragetDirection = traget - transform.position;
        tragetDirection.y = 0;

        float angel = Vector3.Angle(tragetDirection, transform.forward);

        Vector3 localPosition = transform.InverseTransformPoint(traget);

        if(localPosition.x < 0f)
        {
            angel = -angel;
        }



        currentSteeringAngle = Mathf.Clamp(angel / 30, -1, 1);
    }


    private void MoveCar()
    {
        if (!_isGroundTouch)
        {
            carBody.AddForce(-Vector3.up * groundForce);
        }
        else if(!carfule.GetFuleTankState() || isFuleRefling)
        {
            carBody.velocity = carBody.velocity + (transform.forward * _currentSpeed * Time.fixedDeltaTime);
        }
    }

    public void SetCurrentWaypoint()
    {
        if (carfule.GetNeedPitShopState() == false)
        {
            traget = GameManager.instance.GetCircurtData().wayPoints[currentWP].position;

            float ranX = Random.Range(-1, 1);
            float ranZ = Random.Range(-1, 1);

            traget.x += ranX;
            traget.z += ranZ;

        }
        else
        {
            traget = GameManager.instance.GetPitShopCircute().wayPoints[currentWP].position;

            float ranX = Random.Range(-1, 1);
            float ranZ = Random.Range(-1, 1);

            traget.x += ranX;
            traget.z += ranZ;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Waypoint"))
        {
            if(carfule.GetNeedPitShopState() == false)
            {
                if (other.gameObject.GetComponent<AiPathIndex>().pathIndex == currentWP)
                {
                    // print("Go to next path");
                    currentWP++;
                }

                if (currentWP >= GameManager.instance.GetCircurtData().wayPoints.Length)
                {
                    currentWP = 0;
                }
            }
            else
            {
                if (other.gameObject.GetComponent<AiPathIndex>().pathIndex == currentWP)
                {
                    // print("Go to next path");
                    currentWP++;
                }
                if(currentWP >= GameManager.instance.GetPitShopCircute().wayPoints.Length - 1)
                {
                    print("Hold to refile fule");
                    isFuleRefling = true;
                    _currentSpeed = 0;
                    StartCoroutine(HoldAtPitShop());
                }
            }
            SetCurrentWaypoint();
        }
    }
    public IEnumerator HoldAtPitShop()
    {
        carfule.SetNeedPitshopState( true);
        
        print("Corutine called");
        yield return new WaitForSeconds(5);
        carfule.SetNeedPitshopState(false);
        isFuleRefling = false;
        _currentSpeed = currentSpeed;
        currentWP = 0;
        SetCurrentWaypoint();
        print("Corutine end");
    }


}
