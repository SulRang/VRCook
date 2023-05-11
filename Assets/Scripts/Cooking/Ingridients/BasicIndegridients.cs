using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicIndegridients : ThermalObject
{
    [Header("���� �������� ����")]
    public bool isWet = false;
    [Header("�÷��� �� �ִ� �µ�")]
    public float peekTemperature = 0.0f;
    [Header("�÷��� �� ���� �µ�")]
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
