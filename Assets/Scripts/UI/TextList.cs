using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextList : MonoBehaviour
{
    Text text;
    [SerializeField]
    int id = 0;

    [SerializeField]
    string[,] texts = {{
    "손을 씻고, 감자와 양파를 씻어주세요.",
    "가스레인지에 불을 켜서 물이 끓여주세요.",
    "감자를 도마 위에 놓고 칼로 큐브모양으로 한입크기가 되게 잘라주세요.",
    "냄비의 물이 끓었다면, 자른 감자를 냄비에 넣어 삶아주세요.",
    "양파를 도마 위에 올려 놓고 칼로 썰어주세요.\n그 후, 양파를 그릇으로 옮겨주세요.",
    "감자가 충분히 삶아졌으면, 감자를 그릇으로 옮겨주세요.",
    "소금과 후추를 적당량 감자가 담겨있는 그릇에 옮겨주세요.",
    "마요네즈를 마요네즈 그릇에 짠 후 숟가락으로 마요네즈를 퍼 그릇에 있는 감자와 충분히 섞어주세요.",
    "충분히 섞었다면, 감자를 접시로 옮긴 후 파슬리를 뿌려주세요.",
    "완료 버튼을 눌러 요리를 제출하세요."
    },
    {
    "손을 씻고, 감자와 양파를 씻어주세요.",
    "가스레인지에 불을 켜서 물이 끓여주세요.",
    "감자를 도마 위에 놓고 칼로 큐브모양으로 한입크기가 되게 잘라주세요.",
    "냄비의 물이 끓었다면, 자른 감자를 냄비에 넣어 삶아주세요.",
    "양파를 도마 위에 올려 놓고 칼로 썰어주세요.\n그 후, 양파를 그릇으로 옮겨주세요.",
    "감자가 충분히 삶아졌으면, 감자를 그릇으로 옮겨주세요.",
    "소금과 후추를 적당량 감자가 담겨있는 그릇에 옮겨주세요.",
    "마요네즈를 마요네즈 그릇에 짠 후 숟가락으로 마요네즈를 퍼 그릇에 있는 감자와 충분히 섞어주세요.",
    "충분히 섞었다면, 감자를 접시로 옮긴 후 파슬리를 뿌려주세요.",
    "완료 버튼을 눌러 요리를 제출하세요."
    }};

    // Start is called before the first frame update
    void Start()
    {
        text = transform.GetChild(2).GetComponent<Text>();
        text.text = texts[id, ProcessManager.Instance.idx[id]];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetStringNext()
    {
        ProcessManager.Instance.idx[id]++;
        text.text = texts[id, ProcessManager.Instance.idx[id]];
    }
}
