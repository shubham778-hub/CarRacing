using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    [Header("Circurt Data")]
    [SerializeField] private Circurt circurt;

    [SerializeField] private Circurt pitShopPath;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        pitShopPath.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(CarManager.instance.GetCarfule().GetNeedPitShopState() == true)
        {
            pitShopPath.gameObject.SetActive(true);
            circurt.gameObject.SetActive(false);
        }
        else
        {
            pitShopPath.gameObject.SetActive(false);
            circurt.gameObject.SetActive(true);
        }
    }

    public Circurt GetCircurtData()
    {
        return circurt;
    }

    public Circurt GetPitShopCircute()
    {
        return pitShopPath;
    }


}
