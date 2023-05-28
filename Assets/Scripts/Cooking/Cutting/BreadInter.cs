using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadInter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateInterpolation();
    }

    public void RotateInterpolation()
    {
        Vector3 vector = transform.rotation.eulerAngles;
        Vector3 vector3 = new Vector3(Mathf.RoundToInt(vector.x / 90f), Mathf.Ceil(vector.y / 90f), Mathf.Ceil(vector.z / 90f));
        transform.rotation = Quaternion.Euler(vector3 * 90);
    }
}
