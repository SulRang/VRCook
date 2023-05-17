using System.Collections.Generic;
using UnityEngine;

public class MayoSauceBottle : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particleSystem;
    public bool isSaucePushed = false;
    public float rotationThresholdMax = 140f;
    public float rotationThresholdMin = 220f;
    public float rotationVelocityThreshold = 10f;


    private void Start()
    {
        particleSystem = this.GetComponentInChildren<ParticleSystem>();
    }
    private void Update()
    {
        if ((transform.eulerAngles.x >= rotationThresholdMax && transform.eulerAngles.x <= rotationThresholdMin) ||
        (transform.eulerAngles.z >= rotationThresholdMax && transform.eulerAngles.z <= rotationThresholdMin))
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
