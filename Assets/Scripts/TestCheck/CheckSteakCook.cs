using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSteakCook : MonoBehaviour
{
    public static CheckSteakCook instance;

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

    [Header("손 씼었는지 여부")]
    public bool isWashedHand = false;
    [Header("가니쉬 씻었는지 여부")]
    public bool isWashedGanish = false;
    [Header("후추 뿌린 횟수 (1번당 1g)")]
    public int pepperShakingCount = 0;
    [Header("소금 뿌린 횟수 (1번당 1g)")]
    public int saltShakingCount = 0;
    [Header("스테이크를 뒤집은 횟수")]
    public int steakFlippingCount = 0;
    [Header("스테이크의 심부 최대 온도")]
    public float maxSteakInsideTemperature = 0;
    [Header("스테이크의 외부 최대 온도")]
    public float maxSteakOutsideTemperature = 0;
}
