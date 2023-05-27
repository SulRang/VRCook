using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteakSound : MonoBehaviour
{

    public AudioClip[] audioClips = new AudioClip[2];
    public AudioSource[] audioSources;

    public bool isOnPan = false;
    public bool isLostedOnPan = false;
    public ThermalObject panThermal;
    public ThermalObject outerSteakThermal;
    private float plusSound = 0.0f;

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
            float volume = (200 + tempDelta) / 200;
            audioSources[0].volume = 0.13f * volume + plusSound;
            audioSources[1].volume = 0.2f * volume + plusSound;
        }
    }

    IEnumerator PlusSound(float time)
    {
        for(float i = 0.1f; i > 0; i-= ((0.1f * Time.deltaTime) / time))
        {
            plusSound = i;
            yield return new WaitForEndOfFrame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FryPan" && other.transform.GetComponent<ThermalObject>().temperature > 30f)
        {
            if(isLostedOnPan)
            {
                StartCoroutine(PlusSound(5.0f));
                isLostedOnPan = false;
                CheckSteakCook.instance.steakFlippingCount++;
            }
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
            isLostedOnPan = true;
            audioSources[0].Stop();
            audioSources[1].Stop();
        }
    }
}
