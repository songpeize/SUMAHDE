using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0f;
    private bool fixcam = false;

    private Vector3 _velocity = Vector3.zero;


    void LateUpdate()
    {
        if (fixcam == false)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);
        }
    }
}
