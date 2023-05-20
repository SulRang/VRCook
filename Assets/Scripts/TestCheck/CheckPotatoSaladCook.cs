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

    public bool isWashedHand = false; // 손 씻었냐 
    public float maxPotatoTemp = 0.0f; // 감자 최대 온도.
    public float mixingTime = 0.0f; // 감자 섞는 시간.
    public int saltShakingCount = 0; // 감자 조각 위에서 소금 뿌린 횟수.
    public int pepperShakingCount = 0;// 감자 조각 위에서 후추 뿌린 횟수.
}
