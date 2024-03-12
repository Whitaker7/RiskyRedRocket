using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    private Transform target;
    [SerializeField] float smoothSpeed = 0.125f;
    [SerializeField] Vector3 locationOffset;
    [SerializeField] Vector3 rotationOffset;

    void Start()
    {
        target = GameObject.Find("Rocket Ship").transform;
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + locationOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        //Quaternion desiredrotation = target.rotation * Quaternion.Euler(rotationOffset);
        //Quaternion smoothedrotation = Quaternion.Lerp(transform.rotation, desiredrotation, smoothSpeed);
        //transform.rotation = smoothedrotation;
    }
}
