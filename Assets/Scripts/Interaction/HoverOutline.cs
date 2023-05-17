using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverOutline : MonoBehaviour
{
    List<GameObject> hoverObjs = new List<GameObject>();
    GameObject selectedObj;
    bool isChange = false;

    [SerializeField]
    Material OutlineMaterial;

    List<Material> materials = new List<Material>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Object")
        {
            if (hoverObjs.Count < 1)
            {
                selectedObj = other.gameObject;
                SetOutline(selectedObj.GetComponent<MeshRenderer>());
            }
            hoverObjs.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Object")
        {
            hoverObjs.Remove(other.gameObject);
            if (hoverObjs.Count < 1)
                UnSetOutline(selectedObj.GetComponent<MeshRenderer>());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (hoverObjs.Count > 1)
            CalculateDistance();
    }

    void CalculateDistance()
    {
        float minDistance = float.MaxValue;
        GameObject minObj = selectedObj;
        isChange = false;
        foreach (GameObject obj in hoverObjs)
        {
            float curDistance = Vector3.Distance(obj.transform.position, transform.position);
            if (minDistance > curDistance)
            {
                minObj = obj;
                minDistance = curDistance;
                isChange = true;
            }
        }
        if(isChange)
        {
            UnSetOutline(selectedObj.GetComponent<MeshRenderer>());
            SetOutline(minObj.GetComponent<MeshRenderer>());
            selectedObj = minObj;
        }
    }
    public void SetOutline(MeshRenderer renderer)
    {
        materials.Clear();
        materials.AddRange(renderer.sharedMaterials);
        materials.Add(OutlineMaterial);

        renderer.materials = materials.ToArray();
    }
    public void UnSetOutline(MeshRenderer renderer)
    {
        materials.Clear();
        materials.AddRange(renderer.sharedMaterials);
        materials.Remove(OutlineMaterial);

        renderer.materials = materials.ToArray();
    }
}
