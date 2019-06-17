using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    //Unity Components
    private Rigidbody _Rigidbody;
    private AudioSource _AudioSource;


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

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space)) // Can thrust while rotating
        {
            this._Rigidbody.AddRelativeForce(Vector3.up);
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
        //In this case can accept only one rotate at the same time.
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
        }

        this._Rigidbody.freezeRotation = false; // resume physincs control of rotation

    }

}
