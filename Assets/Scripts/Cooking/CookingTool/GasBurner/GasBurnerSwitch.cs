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

        if (switchInput > 0.05f && switchInput < 0.95f)
        {
            fireOn = true;
        }
        else if(switchInput < 0.05f && switchInput < 0.95f)
        {
            fireOn = false;
        }
        
        if(fireOn)
        {
            if ((audioSouce.clip == null))
            {
                audioSouce.clip = sparkAudio;
                audioSouce.Play();
                StartCoroutine(sparkCoroutine());
            }
        }
        else if(!fireOn)
        {
            audioSouce.clip = null;
            audioSouce.Pause();
        }
    }

    IEnumerator sparkCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
        audioSouce.clip = fireOnAudio;
        audioSouce.Play();
    }



    public float GetSwitchValue()
    {
        return switchInput;
    }
}
