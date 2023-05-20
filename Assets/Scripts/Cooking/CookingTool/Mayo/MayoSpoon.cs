using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayoSpoon : MonoBehaviour
{
    public bool mayoSpooned = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Mayo In Bowl" && other.transform.localScale.z >= 0.3f)
        {
            mayoSpooned = true;
            MayoToggle(mayoSpooned);
        }
        
    }
    
    private void MayoToggle(bool mayoState)
    {
        transform.GetChild(0).gameObject.SetActive(mayoState);
    }
}
