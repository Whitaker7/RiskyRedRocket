using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeAndDropWhenInZone : MonoBehaviour {

	[SerializeField] Rigidbody rb;
	[SerializeField] BoxCollider trigger;
	[SerializeField] Oscillator oscillator;
	[SerializeField] float fShakeTime = 1.0f;

	private float timer = 0;
	// Use this for initialization
	void Start () {
		oscillator.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        ShakeAndDrop();
    }

    private void ShakeAndDrop()
    {
        timer += 1f;
        BeginShaking();
        if (timer > 250)
        {
            StopShaking();
        }
    }

    private void StopShaking()
    {
		oscillator.enabled = false;
		rb.useGravity = true;
    }

    private void BeginShaking()
    {
		oscillator.enabled = true;
    }
}
