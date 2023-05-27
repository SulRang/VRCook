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

    [Header("손 씼었는지 여부")]
    public bool isWashedHand = false; // 
    [Header("Lectucce 씻었는지 여부")]
    public bool isWashedlettuce = false;
    [Header("Tomato 씻었는지 여부")]
    public bool isWashedTomato = false;
    [Header("후추 뿌려진 횟수 (1번당 1g)")]
    public int pepperShakingCount = 0;
    [Header("소금 뿌려진 횟수 (1번당 1g)")]
    public int saltShakingCount = 0;
    [Header("마요네즈가 뿌려진 %")]
    public float mayoSpreadAmount = 0.0f; // %임.
    [Header("샌드위치의 순서가 맞음")]
    public bool isSandWichQueueRight = false;

}
