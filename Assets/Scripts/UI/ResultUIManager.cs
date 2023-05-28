using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUIManager : MonoBehaviour
{
    [SerializeField]
    Image[] starImage;

    [SerializeField]
    Text[] feedbackTexts;

    const int SALT_AMOUNT = 2;

    const int PEPPER_AMOUNT = 1;

    //메뉴 id (0 : 샐러드, 1 : 샌드위치, 2: 스테이크)
    [SerializeField]
    int id = 0;

    /// <summary>
    /// 평가 피드백 메시지 배열
    /// </summary>
    string[,,] texts = {
    {//샐러드
        {
        "손 씻기 : 요리 전에는 항상 손을 씻어 청결을 유지해주세요",
        "감자 씻기 : 요리 재료는 쓰기전에 항상 깨끗하게 씻어주세요",
        "파 씻기 : 요리 재료는 쓰기전에 항상 깨끗하게 씻어주세요",
        "",
        ""
        },
        {
        "감자 자르기 : 감자는 한입에 들어갈 정도로 작게 잘라주세요.",
        "감자 삶기(짧음) : 감자가 덜 익었어요. 좀 더 부드럽도록 감자를 좀 더 삶아주세요.",
        "감자 삶기(김) : 감자를 너무 많이 삶았어요. 식감이 살아있도록 조금만 짧게 삶아주세요",
        "소스 섞기 : 소스가 덜 섞였어요 소스를 넣고 조금 더 많이 섞어주세요.",
        ""
        },
        {
        "소금(부족) : 너무 싱거워요. 소금을 조금 더 넣어주세요.",
        "소금(과다) : 너무 짜요. 소금을 조금 줄여주세요.",
        "후추(부족) : 너무 싱거워요. 소금을 조금 더 넣어주세요.",
        "후추(과다) : 너무 짜요. 소금을 조금 줄여주세요.",
        "파슬리 : 요리가 끝난 후 파슬리를 살짝 뿌려 꾸며주세요."
        }
    },
    {//샌드위치
        {
        "손 씻기 : 요리 전에는 항상 손을 씻어 청결을 유지해주세요",
        "양상추 씻기 : 요리 재료는 쓰기전에 항상 깨끗하게 씻어주세요.",
        "토마토 씻기 : 요리 재료는 쓰기전에 항상 깨끗하게 씻어주세요.",
        "",
        ""
        },
        {
        "빵 : 겉부분을 더 많이 잘라주세요",
        "햄(짧음) : 햄이 덜 익었어요. 조금만 더 익혀주세요.",
        "햄(김) : 햄이 너무 익었어요. 조금만 덜 익혀주세요.",
        "",
        ""
        },
        {
        "소금(부족) : 너무 싱거워요. 소금을 조금 더 넣어주세요.",
        "소금(과다) : 너무 짜요. 소금을 조금 줄여주세요.",
        "후추(부족) : 너무 싱거워요. 소금을 조금 더 넣어주세요.",
        "후추(과다) : 너무 짜요. 소금을 조금 줄여주세요.",
        "마요네즈(적음) : 마요네즈가 너무 조금 들어갔어요. 조금만 더 넣어주세요."
        }
    },
    {//스테이크
        {
        "손 씻기 : 요리 전에는 항상 손을 씻어 청결을 유지해주세요",
        "가니쉬 씻기 : 요리 재료는 쓰기전에 항상 깨끗하게 씻어주세요.",
        "",
        "",
        ""
        },
        {
        "스테이크(덜익음) : 스테이크가 덜 익었어요. 조금 더 익혀주세요.",
        "스테이크(과익음) : 스테이크가 너무 익었어요. 조금 덜 익혀주세요.",
        "스테이크(탐) : 스테이크가 탔어요. 좀 더 약한 불로 익혀주세요.",
        "스테이크(한쪽만 익음) : 스테이크가 한쪽만 익었어요. 조금 더 자주 뒤집으며 익혀주세요.",
        "스테이크(안이 안익음) : 스테이크의 안쪽이 덜 익었어요. 조금 더 오래 익혀주세요."
        },
        {
        "소금(부족) : 너무 싱거워요. 소금을 조금 더 넣어주세요.",
        "소금(과다) : 너무 짜요. 소금을 조금 줄여주세요.",
        "후추(부족) : 너무 싱거워요. 소금을 조금 더 넣어주세요.",
        "후추(과다) : 너무 짜요. 소금을 조금 줄여주세요.",
        "플레이팅 : 바질을 이용하여 플레이팅을 해 마무리 해주세요."
        }
    }
    };

    /// <summary>
    /// 평가 피드백 메시지 true, false 배열
    /// </summary>
    bool[,] rate = new bool[3, 5] {
        { false, false, false, false, false },
        { false, false, false, false, false },
        { false, false, false, false, false }
    };

    // Start is called before the first frame update
    void Start()
    {
        Evaluate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Evaluate()
    {
        for(int i =0; i < 4; i++)
        {
            SetStar(i);
            SetTexts(i);
        }    
    }

    /// <summary>
    /// 피드백 메시지 적용 함수
    /// </summary>
    /// <param name="i"></param>
    private void SetTexts(int i)
    {
        if (i == 0)
            return;
        string rateStr = "";
        for(int j = 0; j < 5; j++)
        {
            if (rate[i - 1, j])
            {
                rateStr = rateStr + '\n' + texts[id, i - 1, j];
            }
        }
        feedbackTexts[i].text = rateStr;
    }

    /// <summary>
    /// 평가 점수 반환 함수
    /// idx : 평가 종류 (0 : 전체, 1 : 위생, 2 : 과정, 3 : 결과)
    /// </summary>
    /// <param name="idx"></param>
    /// <returns></returns>
    public float EvaluatingFood(int idx)
    {
        switch(idx)
        {
            case 0: return (EvaluatingClean() + EvaluatingProcess() + EvaluatingResult()) / 3.0f;
            case 1: return EvaluatingClean();
            case 2: return EvaluatingProcess();
            case 3: return EvaluatingResult();
            default:
                return 0.0f;
        }
    }

    public float EvaluatingClean()
    {
        //Common
        float handRate = EvaluatingWashHand();
        if (id == 2) //steak
        {
            return (handRate + EvaluatingWashIngredients()) / 2.0f;
        }
        else //Salad, SandWich
        {
            return (handRate + EvaluatingWashIngredients()) / 3.0f;
        }
    }
    public float EvaluatingProcess()
    {
        //Common

        if (id == 0) //Salad
        {
            return (EvaluatingPotato() + EvaluatingShake()) / 2.0f;
        }
        else if (id == 1) //SandWich
        {
            return (Evaluatingham() + EvaluatingBread()) / 2.0f;
        }
        else //Steak
        {
            return (EvaluatingStakeInside() + EvaluatingStakeOutside() + EvaluatingStakeFlip()) / 3.0f;
        }
    }
    public float EvaluatingResult()
    {
        //Common

        if (id == 1) //SandWich
        {
            return (EvaluatingSalt() + EvaluatingPepper() + EvaluatingMayonnaise()) /3.0f;
        }
        else //Salad , Steak
        {
            return (EvaluatingSalt() + EvaluatingPepper())/2.0f;// + EvaluatingPassly()) / 3.0f;
        }
    }
    public void SetStar(int idx)
    {
        starImage[idx].fillAmount = Mathf.Ceil(EvaluatingFood(idx)*2.0f) / 10.0f;
    }



//위생 평가


    /// <summary>
    /// 손 씻었는지 여부 평가
    /// </summary>
    /// <returns>5점 만점 float</returns>
    public float EvaluatingWashHand()
    {
        switch(id)
        {
            case 0:
                if (!CheckPotatoSaladCook.instance.isWashedHand)
                {
                    rate[0, 0] = true;
                    return 0.0f;
                }
                else
                {
                    rate[0, 0] = false;
                    return 5.0f;
                }
            case 1:
                if (!CheckSandWichCooking.instance.isWashedHand)
                {
                    rate[0, 0] = true;
                    return 0.0f;
                }
                else
                {
                    rate[0, 0] = false;
                    return 5.0f;
                }
            case 2:
                if (!CheckSteakCook.instance.isWashedHand)
                {
                    rate[0, 0] = true;
                    return 0.0f;
                }
                else
                {
                    rate[0, 0] = false;
                    return 5.0f;
                }
            default:
                return 0.0f;

        }
    }
    public float EvaluatingWashIngredients()
    {
        switch (id)
        {
            case 0:
                if (!CheckPotatoSaladCook.instance.isWashedPotato)
                {
                    rate[0, 1] = true;
                    if (!CheckPotatoSaladCook.instance.isWashedOnion)
                    {
                        rate[0, 2] = true;
                        return 0.0f;
                    }
                    else
                    {
                        return 5.0f;
                    }
                }
                else
                {
                    if (!CheckPotatoSaladCook.instance.isWashedOnion)
                    {
                        rate[0, 2] = true;
                        return 5.0f;
                    }
                    else
                        return 10.0f;
                }
            case 1:
                if (!CheckSandWichCooking.instance.isWashedlettuce)
                {
                    rate[0, 1] = true;
                    if (!CheckSandWichCooking.instance.isWashedTomato)
                    {
                        rate[0, 2] = true;
                        return 0.0f;
                    }
                    else
                    {
                        return 5.0f;
                    }
                }
                else
                {
                    if (!CheckSandWichCooking.instance.isWashedTomato)
                    {
                        rate[0, 2] = true;
                        return 5.0f;
                    }
                    else
                        return 10.0f;
                }
            case 2:
                if (CheckSteakCook.instance.isWashedGanish)
                {
                    rate[0, 1] = true;
                    return 0.0f;
                }
                else
                {
                    rate[0, 1] = false;
                    return 5.0f;
                }
            default:
                return 0.0f;

        }
    }

//과정 평가

    /// <summary>
    /// 감자 삶은 온도 평가
    /// </summary>
    /// <returns></returns>
    public float EvaluatingPotato()
    {
        if (CheckPotatoSaladCook.instance.maxPotatoTemp < 70.0f)
        {
            rate[1, 1] = true;
            return (CheckPotatoSaladCook.instance.maxPotatoTemp - 40) < 0 ? 0f : 2.5f;
        }
        else if (CheckPotatoSaladCook.instance.maxPotatoTemp > 90.0f)
        {
            rate[1, 2] = true;
            return (CheckPotatoSaladCook.instance.maxPotatoTemp - 100) > 0 ? 0f : 2.5f;
        }
        else
        {
            rate[1, 1] = false;
            rate[1, 2] = false;
            return 5.0f;
        }
        
    }

    /// <summary>
    /// 샐러드 섞은 시간 평가
    /// </summary>
    /// <returns>5점 만점 float</returns>
    public float EvaluatingShake()
    {
        if (CheckPotatoSaladCook.instance.mixingTime < 10.0f)
        {
            rate[1, 3] = true;
            return CheckPotatoSaladCook.instance.mixingTime / 2f;
        }
        else
        {
            rate[1, 3] = false;
            return 5.0f;
        }
    }


    /// <summary>
    /// 샌드위치 빵 온도 평가
    /// </summary>
    /// <returns>5점 만점 float</returns>
    public float EvaluatingBread()
    {
        if (BreadCutChecking.Instance.GetCutting())
        {
            return 5.0f;
        }
        else
        {
            rate[1, 0] = true;
            return 0f;
        }
    }


    /// <summary>
    /// 샌드위치 햄 온도 평가
    /// </summary>
    /// <returns>5점 만점 float</returns>
    public float Evaluatingham()
    {
        if (CheckSandWichCooking.instance.hamMaxTemperature < 40.0f)
        {
            rate[1, 1] = true;
            return 0f;
        }
        else if (CheckSandWichCooking.instance.hamMaxTemperature < 80.0f)
        {
            rate[1, 1] = true;
            return 2.5f;
        }
        else if (CheckSandWichCooking.instance.hamMaxTemperature > 180.0f)
        {
            rate[1, 2] = true;
            return 0f;
        }
        else if (CheckSandWichCooking.instance.hamMaxTemperature > 150.0f)
        {
            rate[1, 2] = true;
            return 2.5f;
        }
        else
        {
            return 5.0f;
        }
    }

    public float EvaluatingStakeInside()
    {
        if (CheckSteakCook.instance.maxSteakInsideTemperature < 50.0f)
        {
            rate[1, 4] = true;
            return 1.0f;
        }
        else
        {
            rate[1, 4] = false;
            return 5.0f;
        }
    }
    public float EvaluatingStakeOutside()
    {
        if (CheckSteakCook.instance.maxSteakOutsideTemperature < 80.0f)
        {
            rate[1, 0] = true;
            return 2.5f;
        }
        else if (CheckSteakCook.instance.maxSteakOutsideTemperature > 180.0f)
        {
            rate[1, 2] = true;
            return 0.0f;
        }
        else if (CheckSteakCook.instance.maxSteakOutsideTemperature > 140.0f)
        {
            rate[1, 1] = true;
            return 2.5f;
        }
        else
        {
            return 5.0f;
        }
    }
    public float EvaluatingStakeFlip()
    {
        if (CheckSteakCook.instance.steakFlippingCount < 3)
        {
            rate[1, 3] = true;
            return CheckSteakCook.instance.steakFlippingCount;
        }
        else
        {
            rate[1, 3] = false;
            return 5.0f;
        }
    }


    //작품 평가

    /// <summary>
    /// 소금양 평가
    /// </summary>
    /// <returns>5점 만점 float</returns>
    public float EvaluatingSalt()
    {
        int saltAmount;
        switch (id)
        {
            case 0:
                saltAmount = CheckPotatoSaladCook.instance.saltShakingCount - SALT_AMOUNT;
                break;
            case 1:
                saltAmount = CheckSandWichCooking.instance.saltShakingCount - SALT_AMOUNT;
                break;
            case 2:
                saltAmount = CheckSteakCook.instance.saltShakingCount;
                if(saltAmount < 5)
                {
                    rate[2, 0] = true;
                    return saltAmount;
                }
                else if (saltAmount > 10)
                {
                    rate[2, 1] = true;
                    return 5.0f - Mathf.Clamp(saltAmount - 10, 0, 5);
                }
                else
                {
                    return 5.0f;
                }
            default:
                return 0.0f;

        }

        if (saltAmount < 0)
        {
            rate[2, 0] = true;
        }
        else if (saltAmount > 0)
        {
            rate[2, 1] = true;
        }

        return 5.0f - Mathf.Clamp(Mathf.Abs(saltAmount), 0, 5);
    }
    /// <summary>
    /// 후추양 평가
    /// </summary>
    /// <returns>5점 만점 float</returns>
    public float EvaluatingPepper()
    {

        int pepperAmount;
        switch (id)
        {
            case 0:
                pepperAmount = CheckPotatoSaladCook.instance.pepperShakingCount - PEPPER_AMOUNT;
                break;
            case 1:
                pepperAmount = CheckSandWichCooking.instance.pepperShakingCount - PEPPER_AMOUNT;
                break;
            case 2:
                pepperAmount = CheckSteakCook.instance.pepperShakingCount;
                if (pepperAmount < 4)
                {
                    rate[2, 2] = true;
                    return pepperAmount+1;
                }
                else if (pepperAmount > 8)
                {
                    rate[2, 3] = true;
                    return 5.0f - Mathf.Clamp(pepperAmount - 8, 0, 5);
                }
                else
                {
                    return 5.0f;
                }
            default:
                return 0.0f;

        }
        if (pepperAmount < 0)
        {
            rate[2, 2] = true;
        }
        else if (pepperAmount > 0)
        {
            rate[2, 3] = true;
        }

        return 5.0f - Mathf.Clamp(Mathf.Abs(pepperAmount)*1.5f, 0f, 5f);
    }
    /// <summary>
    /// 파슬리 평가
    /// </summary>
    /// <returns>5점 만점 float</returns>
    public float EvaluatingPassly()
    {
        if (CheckPotatoSaladCook.instance.parsleyShakingCount < 1)
        {
            rate[2, 4] = true;
            return 0.0f;
        }
        else
        {
            rate[2, 4] = false;
            return 5.0f;
        }
    }
    /// <summary>
    /// 마요네즈양 평가
    /// </summary>
    /// <returns>5점 만점 float</returns>
    public float EvaluatingMayonnaise()
    {

        float mayoAmount = CheckSandWichCooking.instance.mayoSpreadAmount;
        if (mayoAmount > 0.1f)
        {
            return 5.0f;
        }
        else
        {
            rate[2, 4] = true;
            return 0.0f;
        }

    }

}
