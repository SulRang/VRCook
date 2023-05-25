using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        string sceneName = SceneManager.GetActiveScene().name;
        GameObject gameManager = GameObject.Find("GameManager");
        if(isWaterTurnedOn)
        {
            switch (sceneName)
            {
                case "SaladScene":
                    if (other.gameObject.name == "Onion")
                    {
                        CheckPotatoSaladCook.instance.isWashedOnion = true;
                    }
                    else if (other.gameObject.name == "Potato")
                    {
                        CheckPotatoSaladCook.instance.isWashedPotato = true;
                    }
                    else
                    {
                        CheckPotatoSaladCook.instance.isWashedHand = true;
                    }
                break;

                case "SandWichScene":
                    if(other.gameObject.name == "lettuce")
                    {
                        CheckSandWichCooking.instance.isWashedlettuce = true;
                    }
                    else
                    {
                        CheckSandWichCooking.instance.isWashedHand = true;
                    }
                    break;
                case "SteakScene":
                    break;
            }
        }
    }
}
