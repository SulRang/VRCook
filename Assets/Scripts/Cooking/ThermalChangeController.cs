using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermalChangeController : MonoBehaviour
{
    public static ThermalChangeController instance;
    public float timeScale;
    [SerializeField]
    public float realTimeScale = 5.0f;
    [SerializeField]
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


    public void UpdateTimeScale(float _realTimeScale)
    {
        realTimeScale = _realTimeScale;
        timeScale = realTimeScale * timeScaleRatio;
    }

}
