using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    private Rigidbody rb;
    private AudioSource audioSource;
    [SerializeField] private float rotationSpeed = 150f;
    [SerializeField] private float thrust = 100f;

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

    void OnCollisionEnter(Collision collision)
    {

        print("Collided");
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        //if (collision.relativeVelocity.magnitude > 2)
        //    audioSource.Play();
    }

    private void Thrust()
    {
        float thrustThisFrame = thrust * Time.deltaTime;

        //upwards thrust and sounds
        if (Input.GetKey("up") || Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrustThisFrame);
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

        float rotationThisFrame = rotationSpeed * Time.deltaTime;

        if (Input.GetKey("left"))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        if (Input.GetKey("right"))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        rb.freezeRotation = false; // resume physics control of rotation
    }

}
