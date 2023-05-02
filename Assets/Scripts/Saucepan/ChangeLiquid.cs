using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLiquid : MonoBehaviour
{
    [SerializeField]
    GameObject Liquid;
    [SerializeField]
    Material material;
    float time = 0.0f;
    void Start()
    {
        material = Liquid.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        material.color = new Color(1,1,1, 0.01f * time);
    }
}
