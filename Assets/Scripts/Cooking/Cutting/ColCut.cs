using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColCut : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Knife")
        {
            gameObject.SetActive(false);
        }
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
