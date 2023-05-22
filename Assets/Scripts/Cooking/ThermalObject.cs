using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermalObject : MonoBehaviour
{
    [Header("초기온도값")]
    public float initialTemperature = 20.0f;
    [Header("현재 온도")]
    public float temperature = 20.0f;
    [Header("비열")]
    public float specificHeat = 1.0f;
    [Header("크기")]
    public float volume = 1.0f;
    [Header("열전도율")]
    public float thermalConductivity = 1.0f;
    [Header("최대 온도")]
    public float limitTemperature = 100.0f;

    [Header("온도를 InitialTemperature로 고정")]
    // 불과 같은 오브젝트들을 위한 temperature lock 기능. temperature를 initialtemperature의 온도로 lock시킨다.
    public bool temperatureLockInInitial = false;
    [Header("온도 변화 활성화")]
    // 온도 상변화가 일어나지 않게 하기.
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
                    // 객체 간 온도차이 계산
                    float deltaTemperature = temperature - otherThermal.temperature;

                    // 푸리에의 열전도법칙을 사용하여 객체 간 열유동량 계산
                    float heatFlow = deltaTemperature * thermalConductivity;

                    // 객체 간 전달된 열에너지 계산
                    float heatEnergyTransferred = heatFlow * Time.deltaTime;

                    // 각 객체의 비열과 부피를 고려하여 객체의 온도 변화 계산
                    float temperatureChange = -heatEnergyTransferred * ThermalChangeController.instance.timeScale / (specificHeat * volume);
                    float otherTemperatureChange = heatEnergyTransferred * ThermalChangeController.instance.timeScale / (otherThermal.specificHeat * otherThermal.volume);

                    // 각 객체의 온도를 업데이트
                    temperature += temperatureChange;
                    otherThermal.temperature += otherTemperatureChange;

                    // 디버그 로그 출력
                    Debug.Log(otherThermal.gameObject.name + "이 " + otherTemperatureChange + "만큼 변화하여" + otherThermal.temperature + "'C 가 되었습니다.");

                }
            }
        }


    }

    
}
