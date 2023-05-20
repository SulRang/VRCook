using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPot : MonoBehaviour
{
    [SerializeField]
    private Material waterBubbleMat;
    [SerializeField]
    private AudioSource waterBubbleSound;
    [SerializeField]
    private ThermalObject waterTemperature;
    [SerializeField]
    private GameObject waterSteam;
    [SerializeField]
    private List<BasicIndegridients> potatoSlices;

    private float bubbleMatMin = 0.0f;
    private float bubbleMatMax = 0.6f;

    private float soundMin = 0.0f;
    private float soundMax = 0.4f;

    private bool isSoundPlayed = false;


    private void Awake()
    {
        waterBubbleMat = transform.GetChild(1).GetComponent<MeshRenderer>().materials[0];
        waterBubbleSound = transform.GetChild(4).GetComponent<AudioSource>();
        waterSteam = transform.GetChild(3).gameObject;
        waterTemperature = GetComponent<ThermalObject>();
        potatoSlices = new List<BasicIndegridients>();
    }

    private void Update()
    {
        if (waterTemperature.temperature > 80)
        {
            if(!waterSteam.activeInHierarchy)
            {
                waterSteam.SetActive(true);
            }
            if(!isSoundPlayed)
            {
                waterBubbleSound.Play();
                isSoundPlayed = true;
            }

            float waterRaio = ((waterTemperature.temperature - 80.0f )/ 20.0f);
            Debug.Log(waterRaio);

            waterBubbleMat.color = new Color(1, 1, 1, waterRaio * bubbleMatMax);
            waterBubbleSound.volume = soundMax * waterRaio;
        }
        else
        {
            if (waterSteam.activeInHierarchy)
            {
                waterSteam.SetActive(false);
            }
            waterBubbleMat.color = new Color(1,1,1,bubbleMatMin);
            waterBubbleSound.volume = soundMin;
        }

        CheckPotatoTemp();
    }

    private void CheckPotatoTemp()
    {
        float maxTemp = CheckPotatoSaladCook.instance.maxPotatoTemp;
        for (int i = 0; i < potatoSlices.Count; i++)
        {
            
            if(potatoSlices[i].temperature > maxTemp)
            {
                maxTemp = potatoSlices[i].temperature;
            }
        }
        CheckPotatoSaladCook.instance.maxPotatoTemp = maxTemp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BasicIndegridients>() != null)
        {
            other.gameObject.GetComponent<BasicIndegridients>().isWet = true;
            potatoSlices.Add(other.GetComponent<BasicIndegridients>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "leftSide" || other.gameObject.name == "rightSide")
        {
            potatoSlices.Clear();
        }
    }

}
