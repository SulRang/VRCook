using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShakingCheck : MonoBehaviour
{
    int potatoSliceCount = 0;
    bool isPotatoUnderShaker = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "leftSide" || other.gameObject.name == "rightSide" || other.gameObject.name == "turkey ham" || other.gameObject.name == "MEAT")
        {
            potatoSliceCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "leftSide" || other.gameObject.name == "rightSide" || other.gameObject.name == "turkey ham" || other.gameObject.name == "MEAT")
        {
            potatoSliceCount--;
        }
    }
    
    public void CheckShakingSalt()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        GameObject gameManager = GameObject.Find("GameManager");
        if (isPotatoUnderShaker)
        {
            switch (sceneName)
            {
                case "SaladScene":
                    if (transform.parent.gameObject.name == "Pepper")
                    {
                        CheckPotatoSaladCook.instance.pepperShakingCount++;
                    }
                    else if (transform.parent.gameObject.name == "Salt")
                    {
                        CheckPotatoSaladCook.instance.saltShakingCount++;
                    }
                    else if (transform.parent.gameObject.name == "Parsley")
                    {
                        CheckPotatoSaladCook.instance.parsleyShakingCount++;
                    }
                    break;
                case "SandWichScene":
                    if (transform.parent.gameObject.name == "Pepper")
                    {
                        CheckSandWichCooking.instance.pepperShakingCount++;
                    }
                    else if (transform.parent.gameObject.name == "Salt")
                    {
                        CheckSandWichCooking.instance.saltShakingCount++;
                    }
                    break;
                case "SteakScene":
                    if (transform.parent.gameObject.name == "Pepper")
                    {
                        CheckSteakCook.instance.pepperShakingCount++;
                    }
                    else if (transform.parent.gameObject.name == "Salt")
                    {
                        CheckSteakCook.instance.saltShakingCount++;
                    }
                    break;
            }
        }

        if (isPotatoUnderShaker)
        {


        }
    }

    private void Update()
    {
        if(potatoSliceCount > 0)
        {
            isPotatoUnderShaker = true;
        }
        else
        {
            isPotatoUnderShaker = false;
        }
    }
}
