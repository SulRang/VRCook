using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoClips : MonoBehaviour
{
    public static VideoClips instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    [SerializeField]
    VideoClip[] saladProgressVideos;

    [SerializeField]
    VideoClip[] sandwichProgressVideos;

    [SerializeField]
    VideoClip[] steakProgressVideos;

    public VideoClip[] GetVideos(int id)
    {
        switch (id)
        {
            case 0:
                return saladProgressVideos;
            case 1:
                return sandwichProgressVideos;
            case 2:
                return steakProgressVideos;
            default:
                return new VideoClip[] { };
        }
    }


}
