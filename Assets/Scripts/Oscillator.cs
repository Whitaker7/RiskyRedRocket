using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour {

	[SerializeField] private Vector3 movementVector  = new Vector3(10f, 10f, 10f);
	[SerializeField] float period = 2f;

	//TODO remove from inspector later
	[Range(0f, 1f)]
	[SerializeField]
	float movementFactor; //0 for not moved, 1 for fully moved

	private Vector3 startingPos;

	// Use this for initialization
	void Start () {
		startingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (period <= Mathf.Epsilon)
		{
			return;
		}
		float cycles = Time.time / period; //grows continually from zero

		const float tau = Mathf.PI * 2; // ~6.28
		float rawSinWave = Mathf.Sin(cycles * tau);


		movementFactor = (rawSinWave / 2) + .5f;

		Vector3 offset = movementVector * movementFactor;
		transform.position = startingPos + offset;
	}

	public void SetMovementVector(Vector3 inputVector)
	{
		movementVector = inputVector;
	}

	public void SetPeriod(float inputPeriod)
	{
		period = inputPeriod;
	}
}
