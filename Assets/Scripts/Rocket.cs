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

    [SerializeField] private float levelLoadDelay = 1f;
    
    [SerializeField] private ParticleSystem mainEngineParticles = null;
    [SerializeField] private ParticleSystem successParticles = null;
    [SerializeField] private ParticleSystem crashParticles = null;


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
        if (fuelTextGameObject)
        {
            fuelText = fuelTextGameObject.GetComponent<Text>();
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Alive)
        {
            RespondToThrustInput();
            RespondToRotateInput();
            if (fuelText)
            {
                fuelText.text = fuel.ToString();
            }
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
                StartSuccessSequence();
                break;
            default:
                StartDeathSequence();
                break;
        }

    }

    private void StartSuccessSequence()
    {
        state = State.Transcending;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticles.Play();
        //Invoke("LoadNextLevel", levelLoadDelay);
        LoadNextLevel();
    }

    private void StartDeathSequence()
    {
        state = State.Dying;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        crashParticles.Play();
        //Invoke("LoadFirstLevel", levelLoadDelay);
        LoadFirstLevel();
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(2);
    }
    
    private void LoadNextLevel()
    {
        fuelText.text = "Level Complete!";
        bFinished = true;
        SceneManager.LoadScene(2);
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
            mainEngineParticles.Stop();
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
        if (!mainEngineParticles.isPlaying) mainEngineParticles.Play();

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
