using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KnifeScript : MonoBehaviour
{
    AudioSource audioSource;

    private void OnCollisionEnter(Collision collision)
    {
        if (CutAudioList.Instance != null)
        {
            if (collision.gameObject.tag == "Steak")
            {
                audioSource.clip = CutAudioList.Instance.audioClips[0];
                transform.GetComponent<BoxCollider>().isTrigger = true;
                audioSource.Play();
            }
            else if (collision.gameObject.tag == "Bread")
            {
                audioSource.clip = CutAudioList.Instance.audioClips[1];
                transform.GetComponent<BoxCollider>().isTrigger = true;
                audioSource.Play();
            }
            else if (collision.gameObject.tag == "Potato")
            {
                audioSource.clip = CutAudioList.Instance.audioClips[2];
                transform.GetComponent<BoxCollider>().isTrigger = true;
                audioSource.Play();
            }
            else
                return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = CutAudioList.Instance.audioSource;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 2f)
            transform.GetComponent<BoxCollider>().isTrigger = false;
    }
}
