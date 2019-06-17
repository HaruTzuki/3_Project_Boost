using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour {

    [SerializeField] Vector3 MovementVector = new Vector3(10f, 10f, 10f);

    //todo remove from inspector later
    [Range(0,1)]
    [SerializeField] float movementFactor; // 0 for not moved, 1 for fully moved.
    [SerializeField] float period = 2f;

    Vector3 startingPos;

	// Use this for initialization
	void Start () {
        startingPos = this.transform.position; //Taking position from object
	}
	
	// Update is called once per frame
	void Update () {

        if (period <= Mathf.Epsilon) return; // Protect against period is zero
        float cycles = Time.time / period; // Grows continually from 0
        const float tau = Mathf.PI * 2f; // About 6.28
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = MovementVector * movementFactor;
        this.transform.position = startingPos + offset;
	}
}
