using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHold : MonoBehaviour
{
    Transform target;
    float angleSize = 90.0f;
    bool isSelect = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            target = other.transform;
            isSelect = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hand")
        {
//          target = other.transform;
            isSelect = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelect)
        {
            float rot = target.rotation.z + transform.rotation.eulerAngles.z;
            if (rot > 90)
                rot = 90;
            transform.Rotate(new Vector3(0, 0, rot - transform.rotation.eulerAngles.z));
        }
    }

    public void TraceRotation()
    {
        isSelect = true;
    }
    public void UnTraceRotation()
    {
        isSelect = false;
    }
}
