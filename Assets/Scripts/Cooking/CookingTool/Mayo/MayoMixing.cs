using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayoMixing : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> potatoPieces;
    public Transform midPosition;
    public GameObject spoon;
    private Vector3 spoonPrevPosition = Vector3.zero;
    private Vector3 spoonRotationPrevPosition;
    [SerializeField]
    private float spoonmovingThreshhold = 5.0f;
    public int rotationState = 0;
    public float rotationSpeed = 5.0f;
    private bool isrotating = false;
    private bool isSpoonExited = false;

    // rightSide leftSide

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "rightSide" || other.gameObject.name == "leftSide")
        {
            potatoPieces.Add(other.gameObject);
            StartCoroutine(WaitForAdd(other.gameObject));
        }
    }

    IEnumerator WaitForAdd(GameObject obj)
    {
        yield return new WaitForSeconds(0.2f);
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.GetComponent<BoxCollider>().isTrigger = false;
    }

    private void OnTriggerStay(Collider other)
    {
        Transform target = other.gameObject.transform;
        if (other.gameObject.name == "Spoon")
        {
            isSpoonExited = false;
            if (other.transform.position - spoonPrevPosition != Vector3.zero)
            {
                Debug.Log("ȸ�����̴�!!");
                for (int i = 0; i < potatoPieces.Count; i++)
                {
                    if (rotationState == 1)
                    {
                        potatoPieces[i].transform.RotateAround(midPosition.position, Vector3.up, 50.0f * Time.deltaTime);
                    }
                    else if (rotationState == 2)
                    {
                        potatoPieces[i].transform.RotateAround(midPosition.position, Vector3.up, -50.0f * Time.deltaTime);
                    }
                }
                spoonPrevPosition = target.position;
                CheckPotatoSaladCook.instance.mixingTime += Time.deltaTime;
            }
            else
            {
                spoonPrevPosition = other.transform.position;
            }
        }
        
    }


    IEnumerator SpoonExitDelay()
    {
        yield return new WaitForSeconds(1.0f);
        if(isSpoonExited)
        {
            ActivatePotatoCollider();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Spoon")
        {
            isSpoonExited = true;
            StartCoroutine(SpoonExitDelay());
        }
    }

    private void ActivatePotatoCollider()
    {
        for(int i = 0; i < potatoPieces.Count; i++)
        {
            potatoPieces[i].GetComponent<Rigidbody>().isKinematic = false;
            potatoPieces[i].GetComponent<BoxCollider>().isTrigger = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        spoon = GameObject.Find("Spoon");
        spoonRotationPrevPosition = spoon.gameObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // ���� �����Ӱ� ���� �������� ������Ʈ ��ġ�� �������� ȸ�� ������ �Ǵ��մϴ�.
        Vector3 currentPosition = midPosition.InverseTransformPoint(spoon.gameObject.transform.position);
        Vector3 prevPosition = midPosition.InverseTransformPoint(spoonRotationPrevPosition);

        float prevAngle = Vector3.SignedAngle(midPosition.forward, currentPosition, midPosition.up);
        float currentAngle = Vector3.SignedAngle(midPosition.forward, prevPosition, midPosition.up);

        float angle = currentAngle - prevAngle;
        if (angle < 0)
        {
            rotationState = 2;
        }
        else if (angle >= 0)
        {
            rotationState = 1;
        }
        else
        {
            rotationState = 0;
        }

        spoonRotationPrevPosition = spoon.gameObject.transform.position;

    }
}
