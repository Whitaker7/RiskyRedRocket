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
            case RotationMode.Negative:
                return -1f;
            case RotationMode.None:
                return 0f;
            default:
                print("something went wrong in CalculateRotationBasedOnMode in Rotator.cs" + mode);
                return 0f;
        }
    }

}
