using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockStyleRotator : MonoBehaviour {

    [SerializeField] float rotationSpeed;

    [SerializeField] bool rotateClockWise = true;
    private Vector3 finalRotationDirection;

    // Use this for initialization
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {

        CreateFinalRotationVector();

        float rotationThisFrame = rotationSpeed * Time.deltaTime;

        transform.Rotate(finalRotationDirection * rotationThisFrame);

    }

    private void CreateFinalRotationVector()
    {
        if (rotateClockWise)
        {
            finalRotationDirection = Vector3.up;
        }
        else
        {
            finalRotationDirection = Vector3.down;
        }
    }
}
