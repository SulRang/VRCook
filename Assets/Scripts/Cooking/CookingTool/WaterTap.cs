using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTap : MonoBehaviour
{
    ParticleSystem water;
    AudioSource sound;
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
}
