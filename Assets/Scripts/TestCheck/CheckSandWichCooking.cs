using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSandWichCooking : MonoBehaviour
{
    public static CheckSandWichCooking instance;

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
    public bool isWashedlettuce = false;
    public int pepperShakingCount = 0;
    public int saltShakingCount = 0;
    public float mayoSpreadAmount = 0.0f; // %юс.
}
