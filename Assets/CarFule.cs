using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFule : MonoBehaviour
{
    [SerializeField] private bool isFuleTankEmpty = false;
    [SerializeField] private bool needPitShop = false;
    [SerializeField] private float carFule;

    [Header("For Dubgging use")]
    [SerializeField] private float _currentCarFule;

    private void Awake()
    {
        _currentCarFule = carFule;
    }

    // Update is called once per frame
    void Update()
    {
        _currentCarFule -= Time.deltaTime;
        if(_currentCarFule <= 50)
        {
            needPitShop = true;
        }else if(_currentCarFule <= 0)
        {
            isFuleTankEmpty = true;
        }
    }

    public bool GetNeedPitShopState()
    {
        return needPitShop;
    }

    public bool GetFuleTankState()
    {
        return isFuleTankEmpty;
    }

    public void SetNeedPitshopState(bool value)
    {
        needPitShop = value;
    }

}
