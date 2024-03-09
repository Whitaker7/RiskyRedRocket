using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour {
	[SerializeField]
    public Rigidbody rb;
    public float thrust;

    void Start()

    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKey("left"))
		{
			transform.Rotate(0, 0, 1f);
		}
		if (Input.GetKey("right"))
		{
			transform.Rotate(0, 0, -1f);
		}
		if (Input.GetKey("up"))
		{
			rb.AddForce(transform.up, ForceMode.Impulse);
		}
	}

}
