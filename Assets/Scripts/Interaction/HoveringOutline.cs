using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoveringOutline : MonoBehaviour
{
    [SerializeField]
    Material OutlineMaterial;

    List<Material> materials = new List<Material>();

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
