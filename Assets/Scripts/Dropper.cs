using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Dropper : MonoBehaviour {

	[SerializeField] Rigidbody rb;

	private int timer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += 1;
		print(timer);

		if (timer > 500) {
			rb.useGravity = true;
		}
	}
}
