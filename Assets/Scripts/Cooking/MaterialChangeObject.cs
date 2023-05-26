using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TemperatureMaterial
{
    public Material material;
    public float minTemperature;
    public float maxTemperature;
}

public class MaterialChangeObject : MonoBehaviour
{
    public List<TemperatureMaterial> temperatureMaterials = new List<TemperatureMaterial>();
    private MeshRenderer meshRenderer;
    private ThermalObject thermalObject;
    public float temperature;


    private void Start()
    {
        thermalObject = GetComponent<ThermalObject>();
        meshRenderer = GetComponent<MeshRenderer>();


        Material[] materials = transform.GetComponent<MeshRenderer>().materials;
        for (int i = 0; i < temperatureMaterials.Count; i++)
        {
            Color color = materials[i].color;
            color.a = 0.0f;
            materials[i].color = color;
            temperatureMaterials[i].material = materials[i];
        }
    }

    public Material GetMostRelevantMat()
    {
        Material tmp = temperatureMaterials[0].material;
        float minDiff = 10000.0f;
        for (int i = 0; i < temperatureMaterials.Count; i++)
        {
            float diff = Mathf.Min(Mathf.Abs(thermalObject.temperature - temperatureMaterials[i].minTemperature), 
                                   Mathf.Abs(thermalObject.temperature - temperatureMaterials[i].maxTemperature));
            if(diff < minDiff)
            {
                tmp = temperatureMaterials[i].material;
            }

        }
        return tmp;
    }

    private void Update()
    {
        // Calculate temperature based on your simulation
        temperature = thermalObject.temperature;

        // Update the alphas array based on the temperature
        for (int i = 0; i < temperatureMaterials.Count; i++)
        {
            if(i == 0 && temperature <= temperatureMaterials[i].minTemperature)
            {
                SetMaterialAlpha(i, 1f);
            }
            else if (temperature >= temperatureMaterials[i].minTemperature && temperature <= temperatureMaterials[i].maxTemperature)
            {
                // If the temperature is within the range of the material, set its alpha to 1
                SetMaterialAlpha(i, 1f);
            }
            else if (i > 0 && temperature > temperatureMaterials[i - 1].maxTemperature && temperature < temperatureMaterials[i].minTemperature)
            {
                float alpha = Mathf.InverseLerp(temperatureMaterials[i - 1].maxTemperature, temperatureMaterials[i].minTemperature, temperature);
                SetMaterialAlpha(i, alpha);
                SetMaterialAlpha(i-1, 1 - alpha / 3);
            }
            else if(i == temperatureMaterials.Count - 1 && temperature >= temperatureMaterials[i].maxTemperature)
            {
                SetMaterialAlpha(i, 1f);
            }
            else
            {
                // If the temperature is not within the range of the material, set its alpha to 0
                SetMaterialAlpha(i, 0f);
            }

        }
        // You can also update the materials with the new values here
    }

    private void SetMaterialAlpha(int index, float alpha)
    {
        Color color = meshRenderer.materials[index].color;
        color.a = alpha;
        meshRenderer.materials[index].color = color;
    }

}