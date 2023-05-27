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

    [Header("�� �ɾ����� ����")]
    public bool isWashedHand = false;
    [Header("���Ͻ� �ľ����� ����")]
    public bool isWashedGanish = false;
    [Header("���� �Ѹ� Ƚ�� (1���� 1g)")]
    public int pepperShakingCount = 0;
    [Header("�ұ� �Ѹ� Ƚ�� (1���� 1g)")]
    public int saltShakingCount = 0;
    [Header("������ũ�� ������ Ƚ��")]
    public int steakFlippingCount = 0;
    [Header("������ũ�� �ɺ� �ִ� �µ�")]
    public float maxSteakInsideTemperature = 0;
    [Header("������ũ�� �ܺ� �ִ� �µ�")]
    public float maxSteakOutsideTemperature = 0;
}
