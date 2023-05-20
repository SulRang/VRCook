using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasBurnerSwitch : MonoBehaviour
{
    [SerializeField]
    private AudioClip sparkAudio;
    [SerializeField]
    private AudioClip fireComeOutAudio;
    [SerializeField]
    private AudioClip fireOnAudio;

    private AudioSource audioSouce;

    public bool isPressed = false;
    public bool fireOn = false;
    public float switchInput = 0.0f;

    private void Start()
    {
        audioSouce = GetComponent<AudioSource>();
    }
    private void Update()
    {
        switchInput = (transform.rotation.eulerAngles.z - 270) / 360;
        if (transform.rotation.eulerAngles.z > 360)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - 360f));
        }
        else if (transform.rotation.eulerAngles.z < -360)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + 360f));
        }

        if (isPressed && switchInput > 0.1f && switchInput < 0.9f)
        {
            fireOn = true;
            isPressed = false;
        }
        else if(!isPressed && switchInput < 0.1f && switchInput < 0.9f)
        {
            fireOn = false;
        }
        
        if(isPressed && !fireOn)
        {
            if (audioSouce.clip != sparkAudio)
            {
                audioSouce.clip = sparkAudio;
                audioSouce.Play();
            }
        }
        else if(fireOn)
        {
            if(audioSouce.clip != fireOnAudio)
            {
                audioSouce.clip = fireOnAudio;
                audioSouce.Play();
            }
        }
        else if(!isPressed && !fireOn)
        {
            audioSouce.clip = null;
            audioSouce.Pause();
        }
    }



    public float GetSwitchValue()
    {
        return switchInput;
    }
}
