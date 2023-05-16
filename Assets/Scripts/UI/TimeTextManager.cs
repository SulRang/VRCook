using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTextManager : MonoBehaviour
{
    float curTime = 0.0f;   //현재 시간
    float maxTime = 30.0f * 60.0f;  //30분

    [SerializeField]
    bool isStart = false;

    [SerializeField]
    Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            curTime += Time.deltaTime;
            int secTime = (int)curTime;
            timeText.text = string.Format("{0:D2} : {1:D2}", secTime / 60, secTime % 60);    //분 : 초
            if (curTime > maxTime)
                timeText.color = new Color(1, 0, 0);
        }
    }

    public void StartTime()
    {
        isStart = true;
    }

    public void StopTime()
    {
        isStart = false;
    }

    public void InitTime()
    {
        curTime = 0.0f;
    }
}
