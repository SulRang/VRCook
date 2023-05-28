using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutAudioList : MonoBehaviour
{
    private static CutAudioList _instance;
    public static CutAudioList Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(CutAudioList)) as CutAudioList;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    public AudioSource audioSource;
    public AudioClip[] audioClips;
    // Start is called before the first frame update
    void Start()
    {
        if (audioSource == null)
            audioSource = transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
