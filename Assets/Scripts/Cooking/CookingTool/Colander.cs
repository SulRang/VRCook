using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colander : MonoBehaviour
{
    public List<GameObject> potatoes;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "leftSide" || other.gameObject.name == "rightSide")
        {
            potatoes.Add(other.gameObject);
            StartCoroutine(WaitForAdd(other.gameObject));
        }
    }

    IEnumerator WaitForAdd(GameObject obj)
    {
        yield return new WaitForSeconds(0.3f);
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.GetComponent<BoxCollider>().isTrigger = false;
    }

    private void Update()
    {
        Quaternion rot = transform.parent.localRotation;
        
        
        if(((rot.x < -0.5f || rot.x > 0.5f)) || (rot.y < -0.5f || rot.y > 0.5f))
        {
            for(int i = 0; i < potatoes.Count; i++)
            {
                potatoes[i].GetComponent<Rigidbody>().isKinematic = false;
            }

        }
        
    }
}
