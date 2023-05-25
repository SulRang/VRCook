using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongsGrab : MonoBehaviour
{
    Transform target;

    bool isActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "steak")
        {
            target = other.transform;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && isActive)
        {
            target.position = transform.position;
            target.rotation = transform.rotation;
        }
    }

    public void GrabTongs()
    {
        if (target != null)
        {
            isActive = true;
            target.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    public void UnGrabTongs()
    {
        if (target != null)
        {
            isActive = false;
            target.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
