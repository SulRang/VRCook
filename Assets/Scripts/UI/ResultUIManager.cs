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

    //�޴� id (0 : ������, 1 : ������ġ, 2: ������ũ)
    [SerializeField]
    int id = 0;

    float resultRate = 0f;

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
        "�������(����) : ������ �ʹ� ���� �����. ���ݸ� �� �־��ּ���.",
        "�������(����) : ������ �ʹ� ���� �����. ���ݸ� �� �־��ּ���.",
        "�� �ı� : �丮 ���� �������� �׻� �����ϰ� �ľ��ּ���",
        "",
        ""
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
        ""
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
        throw new NotImplementedException();
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
        if (id == 0) //Salad
        {

        }
        else if(id == 1) //SandWich
        {

        }
        else //Steak
        {

        }
        return 0;
    }
    public float EvaluatingProcess()
    {
        //Common

        if (id == 0) //Salad
        {
            return EvaluatingShake();
        }
        else if (id == 1) //SandWich
        {

        }
        else //Steak
        {

        }
        return 0;
    }
    public float EvaluatingResult()
    {
        //Common

        if (id == 1) //SandWich
        {
            return EvaluatingMayonnaise();
        }
        else //Salad , Steak
        {
            return (EvaluatingSalt() + EvaluatingPepper() + EvaluatingPassly()) / 3.0f;
        }
    }
    public void SetStar(int idx)
    {
        starImage[idx].fillAmount = EvaluatingFood(idx) / 5.0f;
    }



//���� ��


    /// <summary>
    /// �� �ľ����� ���� ��
    /// </summary>
    /// <returns>5�� ���� float</returns>
    public float EvaluatingWashHand()
    {
        if (CheckPotatoSaladCook.instance.isWashedHand)
        {
            rate[0, 0] = true;
            return 0.0f;
        }
        else
        {
            rate[0, 0] = false;
            return 5.0f;
        }
    }

//���� ��

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


    //��ǰ ��

    /// <summary>
    /// �ұݾ� ��
    /// </summary>
    /// <returns>5�� ���� float</returns>
    public float EvaluatingSalt()
    {
        int saltAmount = CheckPotatoSaladCook.instance.saltShakingCount - 2;
        if (saltAmount < 0)
        {
            rate[2,0] = true;
        }
        else if(saltAmount > 0)
        {
            rate[2, 1] = true;
        }

        return 5.0f - Mathf.Clamp(Mathf.Abs(saltAmount), 0f, 5f);
    }
    /// <summary>
    /// ���߾� ��
    /// </summary>
    /// <returns>5�� ���� float</returns>
    public float EvaluatingPepper()
    {

        int pepperAmount = CheckPotatoSaladCook.instance.pepperShakingCount - 1;
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

        int pepperAmount = CheckPotatoSaladCook.instance.pepperShakingCount - 1;
        if (pepperAmount < 0)
        {
            rate[2, 2] = true;
        }
        else if (pepperAmount > 0)
        {
            rate[2, 3] = true;
        }

        return 5.0f - Mathf.Clamp(Mathf.Abs(pepperAmount) * 1.5f, 0f, 5f);
    }

}
