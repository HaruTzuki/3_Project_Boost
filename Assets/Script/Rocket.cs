using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{

    //Unity Components
    private Rigidbody _Rigidbody;
    private AudioSource _AudioSource;

    //Our Fields
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;

    [SerializeField] AudioClip MainEngine;
    [SerializeField] AudioClip Death;
    [SerializeField] AudioClip Success;

    enum State
    {
        Alive, Dying, Transceding
    }

    State _State = State.Alive;


    // Use this for initialization
    void Start()
    {
        this._Rigidbody = GetComponent<Rigidbody>(); //Taking the reference of object Rigidbody.That inhireted from UnityEngine library.
        this._AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this._State == State.Alive)
        {
            RespondToThrustInput();
            RespondToRotateInput(); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (this._State != State.Alive) return;

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Enemy":
                StartDeathSequence();
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            case "Fuel":
                print("You are regenerate your fuel");
                break;
            default:
                break;
        }
    }

    private void StartDeathSequence()
    {
        this._State = State.Dying;
        this._AudioSource.Stop();
        this._AudioSource.PlayOneShot(Death);
        Invoke("LoadFirstLevel", 1f);
    }

    private void StartSuccessSequence()
    {
        this._AudioSource.Stop();
        this._AudioSource.PlayOneShot(Success);
        this._State = State.Transceding;
        Invoke("LoadNextLevel", 1f);
    }

    private void RespondToThrustInput()
    {
        if (Input.GetKey(KeyCode.Space)) // Can thrust while rotating
        {
            this._Rigidbody.AddRelativeForce(Vector3.up * mainThrust);
            if (!this._AudioSource.isPlaying)
                this._AudioSource.PlayOneShot(MainEngine);
        }
        else
        {
            if (this._AudioSource.isPlaying)
                this._AudioSource.Stop();
        }
    }

    private void RespondToRotateInput()
    {
        this._Rigidbody.freezeRotation = true; // take manual control of rotation
        
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        //In this case can accept only one rotate at the same time.
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        this._Rigidbody.freezeRotation = false; // resume physincs control of rotation

    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(1);
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
    }

}
