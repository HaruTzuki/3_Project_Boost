using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    //Unity Components
    private Rigidbody _Rigidbody;
    private AudioSource _AudioSource;


	// Use this for initialization
	void Start () {
        this._Rigidbody = GetComponent<Rigidbody>(); //Taking the reference of object Rigidbody.That inhireted from UnityEngine library.
        this._AudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        ProcessInput();
	}

    private void ProcessInput()
    {
        if(Input.GetKey(KeyCode.Space)) // Can thrust while rotating
        {
            //print("Thrusting");
            this._Rigidbody.AddRelativeForce(Vector3.up);
            if(!this._AudioSource.isPlaying)
                this._AudioSource.Play();
        }
        else
        {
            if (this._AudioSource.isPlaying)
                this._AudioSource.Stop();
        }

        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    this._AudioSource.Play();
        //}
        //else
        //{
        //    this._AudioSource.Stop();
        //}

        //In this case can accept only one rotate at the same time.
        if(Input.GetKey(KeyCode.A))
        {
            //print("Rotating Left");
            transform.Rotate(Vector3.forward);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            // print("Rotating Right");
            transform.Rotate(-Vector3.forward);
        }
    }
}
