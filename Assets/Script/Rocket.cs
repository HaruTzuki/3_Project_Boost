using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    //Unity Components
    private Rigidbody _Rigidbody;


	// Use this for initialization
	void Start () {
        this._Rigidbody = GetComponent<Rigidbody>(); //Taking the reference of object Rigidbody.That inhireted from UnityEngine library.
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
        }

        //In this case can accept only one rotate at the same time.
        if(Input.GetKey(KeyCode.A))
        {
            print("Rotating Left");
        }
        else if(Input.GetKey(KeyCode.D))
        {
            print("Rotating Right");
        }
    }
}
