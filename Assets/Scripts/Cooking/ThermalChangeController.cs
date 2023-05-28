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

    private void Update()
    {
        timeScale = realTimeScale * timeScaleRatio;
    }

    public void UpdateTimeScale(float _realTimeScale)
    {
        realTimeScale = _realTimeScale;
        timeScale = realTimeScale * timeScaleRatio;
    }

}
