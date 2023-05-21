using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTap : MonoBehaviour
{
    ParticleSystem water;
    AudioSource sound;
    private bool isWaterTurnedOn = false;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        water = GetComponentInChildren<ParticleSystem>();

    }

    public void TurnOnWater()
    {
        water.Play();
        sound.Play();
    }

    public void TurnOffWater()
    {
        water.Stop();
        sound.Stop();
    }

    private void Update()
    {
        if(transform.GetChild(1).transform.localRotation.eulerAngles.z >= 10 && !isWaterTurnedOn)
        {
            TurnOnWater();
            isWaterTurnedOn = true;
        }
        else if(transform.GetChild(1).transform.localRotation.eulerAngles.z <= 10 && isWaterTurnedOn)
        {
            TurnOffWater();
            isWaterTurnedOn = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(isWaterTurnedOn)
        {
            CheckPotatoSaladCook.instance.isWashedHand = true;
        }
    }
}
