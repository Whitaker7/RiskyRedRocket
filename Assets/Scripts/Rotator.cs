using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	[SerializeField] float rotationSpeed;

	[SerializeField] bool rotateOnX;
	private Vector3 xRotation = Vector3.right;

	[SerializeField] bool rotateOnY;
	private Vector3 yRotation = Vector3.up;

	[SerializeField] bool rotateOnZ;
	private Vector3 zRotation = Vector3.forward;

	private Vector3 finalRotationDirection;

	// Use this for initialization
	void Start ()
    {
        CreateFinalRotationVector();
    }


    // Update is called once per frame
    void Update () {
        print(finalRotationDirection);

		float rotationThisFrame = rotationSpeed * Time.deltaTime;

		transform.Rotate(finalRotationDirection * rotationThisFrame);
	
	}

    private void CreateFinalRotationVector()
    {
        if (rotateOnX)
        {
            finalRotationDirection += xRotation;
        }
        if (rotateOnY)
        {
            finalRotationDirection += yRotation;
        }
        if (rotateOnZ)
        {
            finalRotationDirection += zRotation;
        }
    }

}
