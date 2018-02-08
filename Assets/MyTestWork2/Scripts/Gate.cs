using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {

    RCC_EnterExitCar car;
    Rigidbody rb;

    void Start () {
        car = FindObjectOfType<RCC_EnterExitCar>();
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
        if (car.isPlayerIn)
        {
            rb.isKinematic = false;
        }
        else
        {
            rb.isKinematic = true;
        }
	}
}
