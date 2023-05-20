using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingUI : MonoBehaviour
{
    [SerializeField]
    Camera cameraFollow;

    public float cameraDistance = 3.0f;
    public float smoothTime = 0.3f;
    public float rotateSmoothTime = 35f;

    private Vector3 velocity = Vector3.zero;
    private Transform target;

    void Awake()
    {
        target = cameraFollow.transform;
    }


    void Update()
    {
        /*//UI 목표 위치
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, cameraDistance));

        //UI 이동
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // no dampening
        // transform.LookAt(transform.position + cameraFollow.transform.rotation * Vector3.forward, cameraFollow.transform.rotation * Vector3.up);

        // smooth.damp
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, rotateSmoothTime * Time.deltaTime);*/

        Vector3 targetPosition = target.transform.TransformPoint(new Vector3(0, 0, cameraDistance));

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        Vector3 lookAtPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        transform.LookAt(lookAtPos);
        transform.Rotate(new Vector3(0, 180, 0));
    }
}
