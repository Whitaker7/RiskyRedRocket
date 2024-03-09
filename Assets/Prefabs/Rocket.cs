using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    [SerializeField]
    public Rigidbody rb;
    public AudioSource audioSource;

    void Start()

    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }

    private void Thrust()
    {
        //upwards thrust and sounds
        if (Input.GetKey("up") || Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void Rotate()
    {
        rb.freezeRotation = true; // take manual control of rotation

        if (Input.GetKey("left"))
        {
            transform.Rotate(Vector3.forward);
        }
        if (Input.GetKey("right"))
        {
            transform.Rotate(-Vector3.forward);
        }

        rb.freezeRotation = false; // resume physics control of rotation
    }

}
