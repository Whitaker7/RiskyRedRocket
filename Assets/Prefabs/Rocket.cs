using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    [SerializeField]
    public Rigidbody rb;
    public AudioSource audioSource;
    public float thrust;

    void Start()

    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Input.GetKey("left"))
        {
            transform.Rotate(Vector3.forward);
        }
        if (Input.GetKey("right"))
        {
            transform.Rotate(-Vector3.forward);
        }
        CheckIfThrusting();
    }

    private void CheckIfThrusting()
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
}
