using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermalObject : MonoBehaviour
{
    [Header("�ʱ�µ���")]
    public float initialTemperature = 20.0f;
    [Header("���� �µ�")]
    public float temperature = 20.0f;
    [Header("��")]
    public float specificHeat = 1.0f;
    [Header("ũ��")]
    public float volume = 1.0f;
    [Header("��������")]
    public float thermalConductivity = 1.0f;
    [Header("�ִ� �µ�")]
    public float limitTemperature = 100.0f;

    [Header("�µ��� InitialTemperature�� ����")]
    // �Ұ� ���� ������Ʈ���� ���� temperature lock ���. temperature�� initialtemperature�� �µ��� lock��Ų��.
    public bool temperatureLockInInitial = false;
    [Header("�µ� ��ȭ Ȱ��ȭ")]
    // �µ� ��ȭ�� �Ͼ�� �ʰ� �ϱ�.
    public bool isTemperatureChangeEnabled = false;

    private void Update()
    {
        CheckTemperatureLock();
    }

    protected void CheckTemperatureLock()
    {
        if (temperatureLockInInitial)
        {
            temperature = initialTemperature;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        ThermalObject otherThermal = collision.gameObject.GetComponent<ThermalObject>();
        if(otherThermal != null)
        {
            if (isTemperatureChangeEnabled && otherThermal != null && otherThermal.isTemperatureChangeEnabled)
            {
                if((temperature < otherThermal.temperature && temperature < limitTemperature) || (temperature > otherThermal.temperature && otherThermal.temperature < otherThermal.limitTemperature))
                {
                    // ��ü �� �µ����� ���
                    float deltaTemperature = temperature - otherThermal.temperature;

                    // Ǫ������ ��������Ģ�� ����Ͽ� ��ü �� �������� ���
                    float heatFlow = deltaTemperature * thermalConductivity;

                    // ��ü �� ���޵� �������� ���
                    float heatEnergyTransferred = heatFlow * Time.deltaTime;

                    // �� ��ü�� �񿭰� ���Ǹ� ����Ͽ� ��ü�� �µ� ��ȭ ���
                    float temperatureChange = -heatEnergyTransferred * ThermalChangeController.instance.timeScale / (specificHeat * volume);
                    float otherTemperatureChange = heatEnergyTransferred * ThermalChangeController.instance.timeScale / (otherThermal.specificHeat * otherThermal.volume);

                    // �� ��ü�� �µ��� ������Ʈ
                    temperature += temperatureChange;
                    otherThermal.temperature += otherTemperatureChange;

                    // ����� �α� ���
                    Debug.Log(otherThermal.gameObject.name + "�� " + otherTemperatureChange + "��ŭ ��ȭ�Ͽ�" + otherThermal.temperature + "'C �� �Ǿ����ϴ�.");

                }
            }
        }


    }

    
}
