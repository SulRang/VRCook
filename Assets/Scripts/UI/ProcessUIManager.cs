using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ProcessUIManager : MonoBehaviour
{
    [SerializeField]
    Text text;

    [SerializeField]
    VideoPlayer video;

    [SerializeField]
    int id = 0;

    [SerializeField]
    string[] texts = new string[10];


    [SerializeField]
    VideoClip[] videoClips = new VideoClip[10];
    

    // Start is called before the first frame update
    void Start()
    {
        texts = TextLists.instance.GetTexts(id);
        videoClips = VideoClips.instance.GetVideos(id);

        if (text == null)
            text = transform.GetChild(2).GetComponent<Text>();
        text.text = texts[0];

        if (video == null)
            video = transform.GetChild(3).GetComponent<VideoPlayer>();
        video.clip = videoClips[0];
    }

    void Update()
    {
        
    }

    /// <summary>
    /// Next 버튼 : 다음 설명으로 표시
    /// </summary>
    public void SetNext()
    {
        ProcessManager.Instance.idx[id]++;
        text.text = texts[ProcessManager.Instance.idx[id]];
        video.clip = videoClips[ProcessManager.Instance.idx[id]];
    }
}
