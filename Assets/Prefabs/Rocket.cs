using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rocket : MonoBehaviour {
    private Rigidbody rb;
    private AudioSource audioSource;
    [SerializeField] private float rotationSpeed = 150f;
    [SerializeField] private float thrust = 100f;
    [SerializeField] private Text text;
    public float fuel = 100;
    [SerializeField] private float fuelCost = 1f;

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
        text.text = fuel.ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            default:
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
        }

    }

    private void Thrust()
    {
        float thrustThisFrame = thrust * Time.deltaTime;

        //upwards thrust and sounds
        if (Input.GetKey("up") || Input.GetKey(KeyCode.Space))
        {
            if (fuel > 0)
            {
                fuel -= fuelCost;
                print(fuel);
            }
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
