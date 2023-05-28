using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermalChangeController : MonoBehaviour
{
    public static ThermalChangeController instance;
    private float timeScale;
    [Header("시간 배율")]
    public float realTimeScale = 1f;
    public float timerScale = 5f;
    private float timeScaleRatio = 0.01f;
    public GameObject steak;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        timeScale = realTimeScale * timeScaleRatio;
        
    }

    private void Start()
    {
        //steak = GameObject.Find("steak");
    }

    private void Update()
    {
        if (timerScale == 1f)
        {
            steak.transform.GetComponent<ThermalObject>().specificHeat = 5;
            steak.transform.GetComponent<ThermalObject>().volume = 3;
            realTimeScale = 1f;

        }
        else if(timerScale == 2.5f)
        {
            steak.transform.GetComponent<ThermalObject>().specificHeat = 5;
            steak.transform.GetComponent<ThermalObject>().volume = 3;
            realTimeScale = 3f;
        }
        else if(timerScale == 5f)
        {
            steak.transform.GetComponent<ThermalObject>().specificHeat = 3;
            steak.transform.GetComponent<ThermalObject>().volume = 3;
            realTimeScale = 10f;
        }
        timeScale = realTimeScale * timeScaleRatio;
    }

    public void UpdateTimeScale(float _realTimeScale)
    {
        realTimeScale = _realTimeScale;
        timeScale = realTimeScale * timeScaleRatio;
    }

}
