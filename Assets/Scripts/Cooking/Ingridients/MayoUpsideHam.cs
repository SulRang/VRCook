using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayoUpsideHam : MonoBehaviour
{
    public bool isColliderEntered = false;

    public float maxSizeX = 20;
    public float maxSizeZ = 30;
    public float maxSizeY = 1;

    // Update is called once per frame
    void Update()
    {
        if(isColliderEntered)
        {
            if(transform.localScale.x < maxSizeX)
            {
                transform.localScale = new Vector3(transform.localScale.x + maxSizeX * Time.deltaTime * 0.25f, transform.localScale.y + maxSizeY * Time.deltaTime * 0.25f, transform.localScale.z + maxSizeZ * Time.deltaTime * 0.25f);
                CheckSandWichCooking.instance.mayoSpreadAmount =  transform.localScale.y / maxSizeY;
            }
        }
    }
}
