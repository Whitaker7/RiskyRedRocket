//using System.Collections;
//using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rocket : MonoBehaviour {

    [SerializeField] private float rotationSpeed = 150f;
    [SerializeField] private float thrust = 100f;
    [SerializeField] private float fuelCost = 1f;
    [SerializeField] private AudioClip mainEngine = null;
    [SerializeField] private AudioClip success = null;
    [SerializeField] private AudioClip crash = null;


    private Rigidbody rb;
    private AudioSource audioSource;
    private Text fuelText;
    public float fuel = 100;
    private bool bFinished = false;
    enum State { Alive, Dying, Transcending };
    State state = State.Alive;


    void Start()
    {

        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        var fuelTextGameObject = GameObject.Find("FuelText");
        fuelText = fuelTextGameObject.GetComponent<Text>();

        
    }

    // Update is called once per frame
    void Update()
    {
        //todo Stop Sound if not alive
        if (state == State.Alive)
        {
            RespondToThrustInput();
            RespondToRotateInput();
            fuelText.text = fuel.ToString();
        }
        
    }
    

    void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive) return; //ignore collisions when dead

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                state = State.Transcending;
                audioSource.PlayOneShot(success);
                Invoke("LoadNextScene", 1f);
                break;
            default:
                state = State.Dying;
                audioSource.Stop();
                audioSource.PlayOneShot(crash);
                Invoke("LoadFirstLevel", 1f);
                break;
        }

    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
    }
    
    private void LoadNextScene()
    {
        fuelText.text = "Level Complete!";
        bFinished = true;
        SceneManager.LoadScene(1);
    }

    private void RespondToThrustInput()
    {

        //upwards thrust and sounds
        if (Input.GetKey("up") || Input.GetKey(KeyCode.Space))
        {
            Thrust();
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void Thrust()
    {
        float thrustThisFrame = thrust * Time.deltaTime;

        if (fuel > 0)
        {
            fuel -= fuelCost;
        }
        rb.AddRelativeForce(Vector3.up * thrustThisFrame);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
    }

    private void RespondToRotateInput()
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
