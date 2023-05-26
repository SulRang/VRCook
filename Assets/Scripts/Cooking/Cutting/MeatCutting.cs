using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatCutting : MonoBehaviour
{
    [SerializeField]
    Material material;
    float ctime = 0.0f;
    bool isHolding = false;
    bool isStay = false;

    [SerializeField]
    float size = 0.15f;

    public void SetSize(float _size)
    {
        size = _size;
    }

    private void OnTriggerExit(Collider other)
    {
        //isHolding = true;
        if (other.tag == "Knife")
            isStay = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Knife")
            isStay = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Knife")
            isStay = true;
    }

    private void Start()
    {
        if (material == null)
            material = transform.parent.GetComponent<MeshRenderer>().materials[1];
    }

    private void Update()
    {
        ctime += Time.deltaTime;
        if (ctime > 0.5f && !isStay)
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
            Debug.Log("CUT");
            float angle = (360 - collision.transform.rotation.eulerAngles.y) * Mathf.Deg2Rad;
            Vector3 rot = new Vector3(-1 * Mathf.Cos(angle), 0,-1 * Mathf.Sin(angle) * Mathf.Cos(angle));
            GameObject[] gameObjects = ObjectCutting.Cut(gameObject, collision.contacts[0].point, Vector3.right, material, size);
            if(gameObjects.Length > 1)
                gameObjects[1].transform.parent = gameObjects[0].transform;
            isHolding = false;
            collision.transform.GetComponent<BoxCollider>().isTrigger = true;
        }
    }
}
