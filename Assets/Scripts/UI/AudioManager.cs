using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource mainBGM;
    private void Awake()
    {
        var audioManager = FindObjectsOfType<AudioManager>();
        if(audioManager.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        mainBGM.Play();
    }
}
