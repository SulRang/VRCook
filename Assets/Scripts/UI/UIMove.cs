using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMove : MonoBehaviour
{
    float smoothTime = 0.2f;
    float cameraDistance = 1.0f;
    Transform target;
    Transform tracking;
    Transform targetCamera;
    private Vector3 velocity = Vector3.zero;
    bool isSelect = false;

    // Start is called before the first frame update
    void Start()
    {
        tracking = transform.parent;
        targetCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRayTrigger(Transform rayTransform)
    {
        Transform targetUI = transform.parent;
        targetUI.position = Vector3.SmoothDamp(targetUI.position, rayTransform.position, ref velocity, smoothTime);
    }
    public void OffRayTrigger(Transform rayTransform)
    {
        Transform targetUI = transform.parent;
        targetUI.position = Vector3.SmoothDamp(targetUI.position, rayTransform.position, ref velocity, smoothTime);
    }

    public void OnTrigger()
    {
        target = GameObject.Find("Ray(Clone)").transform;
        isSelect = true;
    }
    public void OffTrigger()
    {
        isSelect = true;
    }

    public void DragMoveUI()
    {
        if (isSelect)
        {
            Vector2 targetPos = new Vector2(target.position.x, target.position.z) - new Vector2(targetCamera.position.x, targetCamera.position.z);
            Vector2 trackPos = new Vector2(tracking.position.x, tracking.position.z) - new Vector2(targetCamera.position.x, targetCamera.position.z);

            float angle = Vector2.SignedAngle(targetPos, trackPos);
            Mathf.Clamp(angle, -1, 1);

            tracking.RotateAround(targetCamera.position, Vector3.up, angle);
            tracking.position = Vector3.SmoothDamp(tracking.position, new Vector3(tracking.position.x,target.position.y, tracking.position.z), ref velocity, smoothTime);
        }
        //tracking.position = Vector3.SmoothDamp(tracking.position, targetPosition, ref velocity, smoothTime);
        //tracking.position = Vector3.SmoothDamp(tracking.position, new Vector3(targetPos.x, tracking.position.y, tracking.position.z), ref velocity, smoothTime);
    }
    public void SetColor()
    {
        gameObject.GetComponent<Image>().color = new Color(0, 0, 0);
    }
    public void SetColor2()
    {
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
    }
}
