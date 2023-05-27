using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSandWichCooking : MonoBehaviour
{
    public static CheckSandWichCooking instance;

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
    public bool isWashedHand = false; // 
    [Header("Lectucce �ľ����� ����")]
    public bool isWashedlettuce = false;
    [Header("Tomato �ľ����� ����")]
    public bool isWashedTomato = false;
    [Header("���� �ѷ��� Ƚ�� (1���� 1g)")]
    public int pepperShakingCount = 0;
    [Header("�ұ� �ѷ��� Ƚ�� (1���� 1g)")]
    public int saltShakingCount = 0;
    [Header("������ �ѷ��� %")]
    public float mayoSpreadAmount = 0.0f; // %��.
    [Header("������ġ�� ������ ����")]
    public bool isSandWichQueueRight = false;

}
