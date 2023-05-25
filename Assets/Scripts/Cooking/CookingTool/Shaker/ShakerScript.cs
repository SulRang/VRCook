using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakerScript : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particleSystem;
    public float rotationThresholdMax = 0.9f;
    public float rotationThresholdMin = -0.9f;
    public float rotationVelocityThreshold = 10f;
    public float cooldownTime = 1f;  // Time between particle emissions

    private float cooldownTimer = 1f;
    private Vector3 prevPosition = new Vector3();

    private void Start()
    {
        particleSystem = this.GetComponentInChildren<ParticleSystem>();
    }
    private void Update()
    {
        // Check if the cooldown timer has expired
        if (cooldownTimer <= 0f)
        {
            Quaternion rotation = transform.rotation;
            if ((prevPosition.y - transform.position.y) > rotationVelocityThreshold * Time.deltaTime)
            {
                if(rotation.x < rotationThresholdMin || rotation.x > rotationThresholdMax || rotation.z < rotationThresholdMin || rotation.z > rotationThresholdMax)
                {
                    // Check if the velocity is faster than the threshold
                    particleSystem.Play();
                    cooldownTimer = cooldownTime;  // Reset the cooldown timer
                    transform.GetComponentInChildren<ShakingCheck>().CheckShakingSalt();
                }
            }

            prevPosition = transform.position;
        }
        else
        {
            // Reduce the cooldown timer
            cooldownTimer -= Time.deltaTime;
        }
    }
}
