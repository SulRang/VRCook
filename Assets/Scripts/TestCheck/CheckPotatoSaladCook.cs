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

    public bool isWashedHand = false; // �� �ľ��� 
    public float maxPotatoTemp = 0.0f; // ���� �ִ� �µ�.
    public float mixingTime = 0.0f; // ���� ���� �ð�.
    public int saltShakingCount = 0; // ���� ���� ������ �ұ� �Ѹ� Ƚ��.
    public int pepperShakingCount = 0;// ���� ���� ������ ���� �Ѹ� Ƚ��.
}
