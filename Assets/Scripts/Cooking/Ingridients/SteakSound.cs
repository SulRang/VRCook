using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteakSound : MonoBehaviour
{

    public AudioClip[] audioClips = new AudioClip[2];
    public AudioSource[] audioSources;

    public bool isOnPan = false;
    public ThermalObject panThermal;
    public ThermalObject outerSteakThermal;

    // Start is called before the first frame update
    void Start()
    {
        audioSources = GetComponents<AudioSource>();
        audioSources[0].clip = audioClips[0];
        audioSources[1].clip = audioClips[1];
        outerSteakThermal = GetComponent<ThermalObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isOnPan)
        {
            float tempDelta = panThermal.temperature - outerSteakThermal.temperature;
            float volume = tempDelta / 80;
            audioSources[0].volume = 0.1f * volume;
            audioSources[1].volume = 0.1f * volume;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FryPan")
        {
            isOnPan = true;
            panThermal = other.GetComponent<ThermalObject>();
            audioSources[0].Play();
            audioSources[1].Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "FryPan")
        {
            isOnPan = false;
            audioSources[0].Stop();
            audioSources[1].Stop();
        }
    }
}
