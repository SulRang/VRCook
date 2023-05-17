using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayoColliderRotation : MonoBehaviour
{
    public Transform mayoTransform;
    // Update is called once per frame
    void Update()
    {
        this.transform.localRotation
    = new Quaternion(mayoTransform.transform.rotation.x, mayoTransform.transform.rotation.y,
        mayoTransform.transform.rotation.z, -mayoTransform.transform.rotation.w);
    }
}
