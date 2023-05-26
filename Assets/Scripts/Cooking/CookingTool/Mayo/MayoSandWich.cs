using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayoSandWich : MonoBehaviour
{
    MayoSauceBottle mayoBottle;


    private void Awake()
    {
        mayoBottle = transform.parent.parent.GetComponent<MayoSauceBottle>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (mayoBottle.isSaucePushed && other.gameObject.name == "turkey ham")
        {
            StartCoroutine(SauceFallingTime(other));
        }
    }

    IEnumerator SauceFallingTime(Collider other)
    {
        yield return new WaitForSeconds(0.3f);
        other.transform.GetChild(0).GetComponent<MayoUpsideHam>().isColliderEntered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (mayoBottle.isSaucePushed && other.gameObject.name == "turkey ham")
        {
            other.transform.GetChild(0).GetComponent<MayoUpsideHam>().isColliderEntered = false;
        }
    }
}
