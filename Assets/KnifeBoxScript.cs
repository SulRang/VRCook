using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBoxScript : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if(other.name == "leftSide" || other.name == "rightSide")
            transform.parent.GetComponent<BoxCollider>().isTrigger = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
