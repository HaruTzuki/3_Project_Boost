﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour {

    [SerializeField] Vector3 MovementVector;

    //todo remove from inspector later
    [Range(0,1)]
    [SerializeField] float movementFactor; // 0 for not moved, 1 for fully moved.

    Vector3 startingPos;

	// Use this for initialization
	void Start () {
        startingPos = this.transform.position; //Taking position from object
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 offset = MovementVector * movementFactor;
        this.transform.position = startingPos + offset;
	}
}
