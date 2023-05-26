using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteakTempGetter : MonoBehaviour
{
    public ThermalObject outerSteak;
    public ThermalObject innerSteak;
    // Start is called before the first frame update
    private void Awake()
    {
        outerSteak = transform.GetComponent<ThermalObject>();
        innerSteak = transform.GetChild(0).GetChild(2).GetComponent<ThermalObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (outerSteak.temperature > CheckSteakCook.instance.maxSteakOutsideTemperature)
        {
            CheckSteakCook.instance.maxSteakOutsideTemperature = outerSteak.temperature;
        }
        if (innerSteak.temperature > CheckSteakCook.instance.maxSteakInsideTemperature)
        {
            CheckSteakCook.instance.maxSteakInsideTemperature = innerSteak.temperature;
        }
    }
}
