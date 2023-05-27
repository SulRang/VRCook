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

    [Header("�� �ɾ����� ����")]
    public bool isWashedHand = false; // �� �ľ��� 
    [Header("���ڸ� �ľ����� ����")]
    public bool isWashedPotato = false; // ���� �ľ���
    [Header("���� �ľ����� ����")]
    public bool isWashedOnion = false; // ���� �ľ���

    [Header("������ �ִ� �µ�")]
    public float maxPotatoTemp = 0.0f; // ���� �ִ� �µ�.
    [Header("���� ���� �ð�")]
    public float mixingTime = 0.0f; // ���� ���� �ð�.
    [Header("�ұ� �Ѹ� Ƚ�� (1���� 1g)")]
    public int saltShakingCount = 0; // ���� ���� ������ �ұ� �Ѹ� Ƚ��.
    [Header("���� �Ѹ� Ƚ�� (1���� 1g)")]
    public int pepperShakingCount = 0;// ���� ���� ������ ���� �Ѹ� Ƚ��.
    [Header("�Ľ��� �Ѹ� Ƚ�� (1���� 1g)")]
    public int parsleyShakingCount = 0;
}
