using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    //Unity Components
    private Rigidbody _Rigidbody;
    private AudioSource _AudioSource;

    //Our Fields
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;


    // Use this for initialization
    void Start()
    {
        this._Rigidbody = GetComponent<Rigidbody>(); //Taking the reference of object Rigidbody.That inhireted from UnityEngine library.
        this._AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("Spawn Point");
                break;
            case "Enemy":
                print("You losing life");
                break;
            case "FinishPoint":
                print("Finish");
                break;
            case "Fuel":
                print("You are regenerate your fuel");
                break;
            default:
                break;
        }
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space)) // Can thrust while rotating
        {
            this._Rigidbody.AddRelativeForce(Vector3.up * mainThrust);
            if (!this._AudioSource.isPlaying)
                this._AudioSource.Play();
        }
        else
        {
            if (this._AudioSource.isPlaying)
                this._AudioSource.Stop();
        }
    }

    private void Rotate()
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

}
