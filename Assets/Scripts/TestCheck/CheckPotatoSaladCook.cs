using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPotatoSaladCook : MonoBehaviour
{
    public static CheckPotatoSaladCook instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    [Header("손 씼었는지 여부")]
    public bool isWashedHand = false; // 손 씻었냐 
    [Header("감자를 씻었는지 여부")]
    public bool isWashedPotato = false; // 감자 씻었냐
    [Header("양파 씻었는지 여부")]
    public bool isWashedOnion = false; // 양파 씻었냐

    [Header("감자의 최대 온도")]
    public float maxPotatoTemp = 0.0f; // 감자 최대 온도.
    [Header("감자 섞는 시간")]
    public float mixingTime = 0.0f; // 감자 섞는 시간.
    [Header("소금 뿌린 횟수 (1번당 1g)")]
    public int saltShakingCount = 0; // 감자 조각 위에서 소금 뿌린 횟수.
    [Header("후추 뿌린 횟수 (1번당 1g)")]
    public int pepperShakingCount = 0;// 감자 조각 위에서 후추 뿌린 횟수.
    [Header("파슬리 뿌린 횟수 (1번당 1g)")]
    public int parsleyShakingCount = 0;
}
