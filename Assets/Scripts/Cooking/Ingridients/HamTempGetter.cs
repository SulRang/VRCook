using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamTempGetter : MonoBehaviour
{
    public ThermalObject ham;
    // Start is called before the first frame update
    private void Awake()
    {
        ham = transform.GetComponent<ThermalObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ham.temperature > CheckSandWichCooking.instance.hamMaxTemperature)
            CheckSandWichCooking.instance.hamMaxTemperature = ham.temperature;
    }
}
