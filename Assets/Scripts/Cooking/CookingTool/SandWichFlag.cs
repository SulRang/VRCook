using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandWichFlag : MonoBehaviour
{
    // »§ -> ÇÜ - > ¼Ò½º -> Åä¸¶Åä -> ¾ç»óÃß -> Ä¡Áî -> »§
    private string[] indegridientNames = { "toast bread", "turkey ham", "chedder cheese", "lettuce", "leftSide", "rightSide", "Sphere", "tomato"};
    [SerializeField]
    private List<GameObject> sandwichedObject = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        for(int i = 0; i < indegridientNames.Length; i++)
        {
            if(indegridientNames[i] == other.name)
            {
                sandwichedObject.Add(other.gameObject);
                for (int j = 0; j < sandwichedObject.Count; j++)
                {
                    if (sandwichedObject[i] == other.gameObject)
                    {
                        sandwichedObject.RemoveAt(i);
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        for(int i = 0; i < sandwichedObject.Count; i++)
        {
            if(sandwichedObject[i] == other.gameObject)
            {
                sandwichedObject.RemoveAt(i);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(sandwichedObject.Count < 5)
        {
            if(!CheckSandWichCooking.instance.isSandWichQueueRight)
                CheckSandWichCooking.instance.isSandWichQueueRight = false;
        }
        else
        {
            if (!CheckSandWichCooking.instance.isSandWichQueueRight)
            {
                CheckSandWichCooking.instance.isSandWichQueueRight = true;
            }
        }
    }
}
