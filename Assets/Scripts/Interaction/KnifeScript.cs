using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "leftSide" || collision.gameObject.name == "rightSide")
            transform.GetComponent<BoxCollider>().isTrigger = true;
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
