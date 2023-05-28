using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelect()
    {
        transform.GetComponent<BoxCollider>().isTrigger = true;
        transform.GetComponent<Rigidbody>().isKinematic = true;
    }
    public void OffSelect()
    {
        transform.GetComponent<BoxCollider>().isTrigger = false;
    }
}
