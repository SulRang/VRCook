using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasBurner : MonoBehaviour
{
    private GasBurnerSwitch gasSwitch;
    private ThermalObject thermal;

    private void Awake()
    {
        gasSwitch = transform.GetChild(0).GetComponentInChildren<GasBurnerSwitch>();
        thermal = GetComponent<ThermalObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gasSwitch.GetSwitchValue() > 0.0f)
        {
            thermal.isTemperatureChangeEnabled = true;
        }
        else
        {
            thermal.isTemperatureChangeEnabled = false;
        }
    }
}
