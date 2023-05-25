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

}
