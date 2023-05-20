using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakingCheck : MonoBehaviour
{
    int potatoSliceCount = 0;
    bool isPotatoUnderShaker = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "leftSide" || other.gameObject.name == "rightSide")
        {
            potatoSliceCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "leftSide" || other.gameObject.name == "rightSide")
        {
            potatoSliceCount--;
        }
    }
    
    public void CheckShakingSalt()
    {
        if(isPotatoUnderShaker)
        {
            if (transform.parent.gameObject.name == "Pepper")
            {
                CheckPotatoSaladCook.instance.pepperShakingCount++;
            }
            else if (transform.parent.gameObject.name == "Salt")
            {
                CheckPotatoSaladCook.instance.saltShakingCount++;
            }

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
