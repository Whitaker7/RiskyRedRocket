using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class Rotator : MonoBehaviour {

	[SerializeField] float rotationSpeed;
    private enum RotationMode { Positive, Negative, None};

    [SerializeField] RotationMode xRotationMode = RotationMode.None;
    [SerializeField] RotationMode yRotationMode = RotationMode.None;
    [SerializeField] RotationMode zRotationMode = RotationMode.None;

	//[SerializeField] bool rotateOnX;
	//private Vector3 xRotation = Vector3.right;

	//[SerializeField] bool rotateOnY;
	//private Vector3 yRotation = Vector3.up;

	//[SerializeField] bool rotateOnZ;
	//private Vector3 zRotation = Vector3.forward;

	private Vector3 finalRotationDirection;

	// Use this for initialization
	void Start ()
    {
        CreateFinalRotationVector();
    }


    // Update is called once per frame
    void Update () {

		float rotationThisFrame = rotationSpeed * Time.deltaTime;


		transform.Rotate(finalRotationDirection * rotationThisFrame);
	
	}

    private void CreateFinalRotationVector()
    {

        finalRotationDirection.x = CalculateRotationBasedOnMode(xRotationMode);
        finalRotationDirection.y = CalculateRotationBasedOnMode(yRotationMode);
        finalRotationDirection.z = CalculateRotationBasedOnMode(zRotationMode);

        print(finalRotationDirection);
    }

    private float CalculateRotationBasedOnMode(RotationMode mode)
    {
        switch (mode)
        {
            case RotationMode.Positive:
                return 1f;
                break; 
            case RotationMode.Negative:
                return -1f;
                break;
            case RotationMode.None:
                return 0f;
                break;
            default:
                print("something went wrong" + mode);
                return 0f;
                break;
        }
    }

}
