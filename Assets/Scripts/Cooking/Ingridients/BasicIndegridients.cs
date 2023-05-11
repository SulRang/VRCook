using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicIndegridients : ThermalObject
{
    [Header("물에 젖었는지 여부")]
    public bool isWet = false;
    [Header("플레이 중 최대 온도")]
    public float peekTemperature = 0.0f;
    [Header("플레이 중 최저 온도")]
    public float lowestTemperature = 100.0f;

    private void Update()
    {
        CheckTemperatureLock();
        UpdatePeekLowestTemperature();
    }

    private void UpdatePeekLowestTemperature()
    {
        if(temperature > peekTemperature)
        {
            peekTemperature = temperature;
        }
        else if(temperature < lowestTemperature)
        {
            lowestTemperature = temperature;
        }
    }

}
