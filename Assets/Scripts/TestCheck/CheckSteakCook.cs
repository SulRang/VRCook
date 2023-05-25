using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSteakCook : MonoBehaviour
{
    public static CheckSteakCook instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public bool isWashedHand = false;
    public int pepperShakingCount = 0;
    public int saltShakingCount = 0;
    public float maxSteakInsideTemperature = 0;
    public float maxSteakOutsideTemperature = 0;
}
