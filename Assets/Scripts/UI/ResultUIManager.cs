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

    //�޴� id (0 : ������, 1 : ������ġ, 2: ������ũ)
    [SerializeField]
    int id = 0;

    /// <summary>
    /// �� �ǵ�� �޽��� �迭
    /// </summary>
    string[,,] texts = {
    {//������
        {
        "�� �ı� : �丮 ������ �׻� ���� �ľ� û���� �������ּ���",
        "���� �ı� : �丮 ���� �������� �׻� �����ϰ� �ľ��ּ���",
        "�� �ı� : �丮 ���� �������� �׻� �����ϰ� �ľ��ּ���",
        "",
        ""
        },
        {
        "���� �ڸ��� : ���ڴ� ���Կ� �� ������ �۰� �߶��ּ���.",
        "���� ���(ª��) : ���ڰ� �� �;����. �� �� �ε巴���� ���ڸ� �� �� ����ּ���.",
        "���� ���(��) : ���ڸ� �ʹ� ���� ��Ҿ��. �İ��� ����ֵ��� ���ݸ� ª�� ����ּ���",
        "�ҽ� ���� : �ҽ��� �� ������� �ҽ��� �ְ� ���� �� ���� �����ּ���.",
        ""
        },
        {
        "�ұ�(����) : �ʹ� �̰ſ���. �ұ��� ���� �� �־��ּ���.",
        "�ұ�(����) : �ʹ� ¥��. �ұ��� ���� �ٿ��ּ���.",
        "����(����) : �ʹ� �̰ſ���. �ұ��� ���� �� �־��ּ���.",
        "����(����) : �ʹ� ¥��. �ұ��� ���� �ٿ��ּ���.",
        "�Ľ��� : �丮�� ���� �� �Ľ����� ��¦ �ѷ� �ٸ��ּ���."
        }
    },
    {//������ġ
        {
        "�� �ı� : �丮 ������ �׻� ���� �ľ� û���� �������ּ���",
        "����� �ı� : �丮 ���� �������� �׻� �����ϰ� �ľ��ּ���.",
        "�丶�� �ı� : �丮 ���� �������� �׻� �����ϰ� �ľ��ּ���.",
        "",
        ""
        },
        {
        "�� : �Ѻκ��� �� ���� �߶��ּ���",
        "��(ª��) : ���� �� �;����. ���ݸ� �� �����ּ���.",
        "��(��) : ���� �ʹ� �;����. ���ݸ� �� �����ּ���.",
        "",
        ""
        },
        {
        "�ұ�(����) : �ʹ� �̰ſ���. �ұ��� ���� �� �־��ּ���.",
        "�ұ�(����) : �ʹ� ¥��. �ұ��� ���� �ٿ��ּ���.",
        "����(����) : �ʹ� �̰ſ���. �ұ��� ���� �� �־��ּ���.",
        "����(����) : �ʹ� ¥��. �ұ��� ���� �ٿ��ּ���.",
        "�������(����) : ������ �ʹ� ���� �����. ���ݸ� �� �־��ּ���."
        }
    },
    {//������ũ
        {
        "�� �ı� : �丮 ������ �׻� ���� �ľ� û���� �������ּ���",
        "���Ͻ� �ı� : �丮 ���� �������� �׻� �����ϰ� �ľ��ּ���.",
        "",
        "",
        ""
        },
        {
        "������ũ(������) : ������ũ�� �� �;����. ���� �� �����ּ���.",
        "������ũ(������) : ������ũ�� �ʹ� �;����. ���� �� �����ּ���.",
        "������ũ(Ž) : ������ũ�� �����. �� �� ���� �ҷ� �����ּ���.",
        "������ũ(���ʸ� ����) : ������ũ�� ���ʸ� �;����. ���� �� ���� �������� �����ּ���.",
        "������ũ(���� ������) : ������ũ�� ������ �� �;����. ���� �� ���� �����ּ���."
        },
        {
        "�ұ�(����) : �ʹ� �̰ſ���. �ұ��� ���� �� �־��ּ���.",
        "�ұ�(����) : �ʹ� ¥��. �ұ��� ���� �ٿ��ּ���.",
        "����(����) : �ʹ� �̰ſ���. �ұ��� ���� �� �־��ּ���.",
        "����(����) : �ʹ� ¥��. �ұ��� ���� �ٿ��ּ���.",
        "�÷����� : ������ �̿��Ͽ� �÷������� �� ������ ���ּ���."
        }
    }
    };

    /// <summary>
    /// �� �ǵ�� �޽��� true, false �迭
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
    /// �ǵ�� �޽��� ���� �Լ�
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
    /// �� ���� ��ȯ �Լ�
    /// idx : �� ���� (0 : ��ü, 1 : ����, 2 : ����, 3 : ���)
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



//���� ��


    /// <summary>
    /// �� �ľ����� ���� ��
    /// </summary>
    /// <returns>5�� ���� float</returns>
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

//���� ��

    /// <summary>
    /// ���� ���� �µ� ��
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
    /// ������ ���� �ð� ��
    /// </summary>
    /// <returns>5�� ���� float</returns>
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
    /// ������ġ �� �µ� ��
    /// </summary>
    /// <returns>5�� ���� float</returns>
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
    /// ������ġ �� �µ� ��
    /// </summary>
    /// <returns>5�� ���� float</returns>
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


    //��ǰ ��

    /// <summary>
    /// �ұݾ� ��
    /// </summary>
    /// <returns>5�� ���� float</returns>
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
    /// ���߾� ��
    /// </summary>
    /// <returns>5�� ���� float</returns>
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
    /// �Ľ��� ��
    /// </summary>
    /// <returns>5�� ���� float</returns>
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
    /// �������� ��
    /// </summary>
    /// <returns>5�� ���� float</returns>
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
