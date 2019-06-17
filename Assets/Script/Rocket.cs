using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ProcessInput();
	}

    private void ProcessInput()
    {
        if(Input.GetKey(KeyCode.Space)) // Can thrust while rotating
        {
            print("Thrusting");
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
