using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatCutting : MonoBehaviour
{
    [SerializeField]
    Material material;
    float ctime = 0.0f;
    bool isHolding = false;

    private void Update()
    {
        ctime += Time.deltaTime;
        Debug.Log(ctime);
        if (ctime > 10.0f)
        {
            isHolding = true;
            ctime = 0.0f;
        }
    }

    public void SetHoldIn()
    {
        isHolding = true;
    }
    public void SetHoldOut()
    {
        isHolding = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Knife" && isHolding)
        {
            GameObject[] gameObjects = ObjectCutting.Cut(gameObject, collision.transform.position, Vector3.left, material);
            gameObjects[1].transform.transform.parent = gameObjects[0].transform;
            isHolding = false;
        }
    }
}
