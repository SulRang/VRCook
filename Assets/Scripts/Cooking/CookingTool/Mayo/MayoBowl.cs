using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayoBowl : MonoBehaviour
{
    public float mayoAmount = 0.0f;
    public Transform mayoInBowl;
    public MayoSauceBottle mayoSauceBottle;

    private void Update()
    {
        mayoInBowl.transform.localScale = new Vector3(1,1, mayoAmount);
    }

    private void OnTriggerStay(Collider other)
    {
        if(mayoAmount < 1.0f)
        {
            if (other.gameObject.name == "MayoCollider" && mayoSauceBottle.isSaucePushed)
            {
                mayoAmount += 0.001f * Time.deltaTime;
            }
        }
    }
}
