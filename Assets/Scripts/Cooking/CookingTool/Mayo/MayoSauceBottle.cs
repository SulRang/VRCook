using System.Collections.Generic;
using UnityEngine;

public class MayoSauceBottle : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particleSystem;
    public bool isSaucePushed = false;
    public float rotationThresholdMax = 0.9f;
    public float rotationThresholdMin = -0.9f;
    public float rotationVelocityThreshold = 10f;


    private void Start()
    {
        particleSystem = this.GetComponentInChildren<ParticleSystem>();
    }
    private void Update()
    {
        Quaternion rotation = transform.rotation;
        if (rotation.x < rotationThresholdMin || rotation.x > rotationThresholdMax || rotation.z < rotationThresholdMin || rotation.z > rotationThresholdMax)
        {
            // Check if the velocity is faster than the threshold
            particleSystem.Play();
            isSaucePushed = true;
        }
        else
        {
            particleSystem.Stop();
            isSaucePushed = false;
        }
    }
}
