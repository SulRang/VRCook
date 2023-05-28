using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLists : MonoBehaviour
{
    public static TextLists instance;

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

    string[] saladProgressTexts = {
    "손을 씻고, 감자와 양파를 씻어주세요.",
    "가스레인지에 불을 켜서 물이 끓여주세요.",
    "감자를 도마 위에 놓고 칼로 큐브모양으로 한입크기가 되게 잘라주세요.",
    "냄비의 물이 끓었다면, 자른 감자를 냄비에 넣어 삶아주세요.",
    "양파를 도마 위에 올려 놓고 칼로 썰어주세요.\n그 후, 양파를 그릇으로 옮겨주세요.",
    "감자가 충분히 삶아졌으면, 감자를 그릇으로 옮겨주세요.",
    "소금과 후추를 적당량 감자가 담겨있는 그릇에 옮겨주세요.",
    "마요네즈를 마요네즈 그릇에 짠 후 숟가락으로 마요네즈를 퍼 그릇에 있는 감자와 충분히 섞어주세요.",
    "충분히 섞었다면, 감자를 접시로 옮긴 후 파슬리를 뿌려주세요.",
    "완료 버튼을 눌러 요리를 제출하세요." };

    string[] sandwichProgressTexts = {
    "손을 씻고, 양상추와 토마토를 씻어주세요.",
    "식빵의 겉부분을 잘라주세요.",
    "토마토를 잘라주세요.",
    "가스레인지에 불을 켜서 팬을 달궈주세요.",
    "팬의 온도가 충분히 올랐다면 햄을 팬에 올려주세요.",
    "햄이 골고루 잘 익도록 잘 뒤집어 가며 구워주세요.",
    "식빵을 플레이팅 접시에 놓고 재료를 잘 쌓아주세요.",
    "모두 쌓았다면 꼬치를 꽂아 완성시켜주세요.",
    "완료 버튼을 눌러 요리를 제출하세요.",
    "" };

    string[] steakProgressTexts = {
    "손을 씻고, 가니쉬를 씻어주세요.",
    "가스레인지에 불을 켜서 팬을 달궈주세요.",
    "고기를 도마로 옮긴 후 소금과 후추를 적당히 뿌려주세요.",
    "팬의 온도가 충분히 올랐다면 집게를 사용하여 고기를 팬에 올려주세요.",
    "고기가 골고루 잘 익도록 잘 뒤집어 가며 구워주세요.",
    "고기가 다 익었다면 플레이팅 접시로 옯겨주세요.",
    "플레이팅 접시로 옮겼다면 고기를 잘라주세요.",
    "가니쉬를 예쁘게 플레이팅해 꾸며주세요.",
    "완료 버튼을 눌러 요리를 제출해주세요.",
    "" };

    public string[] GetTexts(int id)
    {
        switch(id)
        {
            case 0:
                return saladProgressTexts;
            case 1:
                return sandwichProgressTexts;
            case 2:
                return steakProgressTexts;
            default:
                return new string[] { };
        }
    }


}
