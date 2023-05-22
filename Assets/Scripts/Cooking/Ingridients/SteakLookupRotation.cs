using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteakLookupRotation : MonoBehaviour
{
    public Transform mayoTransform;
    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.Euler( Vector3.up);
    }
}
