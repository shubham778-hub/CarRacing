using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{

    public static CarManager instance;
    private CarFule carFule;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        carFule = GetComponent<CarFule>();
    }



   

    public CarFule GetCarfule()
    {
        return carFule;
    }
}
