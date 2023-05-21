using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatCutting : MonoBehaviour
{
    [SerializeField]
    Material material;
    float ctime = 0.0f;
    bool isHolding = false;

    private void Start()
    {
        if (material == null)
            material = transform.parent.GetComponent<MeshRenderer>().materials[1];
    }

    private void Update()
    {
        ctime += Time.deltaTime;
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
            Vector3 rot = new Vector3(-1 * Mathf.Cos(collision.transform.rotation.eulerAngles.y), 0, collision.transform.rotation.eulerAngles.y >0 ? 1 * Mathf.Cos(collision.transform.rotation.eulerAngles.y) * Mathf.Sin(collision.transform.rotation.eulerAngles.y) : -1 * Mathf.Cos(collision.transform.rotation.eulerAngles.y) * Mathf.Sin(collision.transform.rotation.eulerAngles.y));
            GameObject[] gameObjects = ObjectCutting.Cut(gameObject, collision.contacts[0].point, rot, material);
            if(gameObjects.Length > 1)
                gameObjects[1].transform.transform.parent = gameObjects[0].transform;
            isHolding = false;
        }
    }
}
