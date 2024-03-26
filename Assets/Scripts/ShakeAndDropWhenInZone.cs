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
    private bool bShaking = false;
	// Use this for initialization
	void Start () {
		oscillator.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
    }

    private void ShakeAndDrop()
    {
        bShaking = true;
        BeginShaking();
        Invoke("StopShaking", fShakeTime);
    }

    private void StopShaking()
    {
		oscillator.enabled = false;
		rb.useGravity = true;
        rb.isKinematic = false;
    }

    private void BeginShaking()
    {
        trigger.enabled = false;
		oscillator.enabled = true;
    }
    void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.tag == "Player")
        {
            ShakeAndDrop();
        }
        
    }
}
