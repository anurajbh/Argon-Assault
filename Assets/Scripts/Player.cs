﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 100f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 100f;

    //Range parameters
    [SerializeField] float xRange = 200f;
    [SerializeField] float yRange = 150f;
    float xThrow;
    float yThrow;

    //Rotation parameters
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlRollFactor = -20f;

    

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float xPos = MoveTheShipX();
        float yPos = MoveTheShipY();
        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
        ProcessRotation();
    }
    private void OnTriggerEnter(Collider other)
    {
        print("Player hit something");
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;//pitch is coupled to both control throw and position
        float yaw = transform.localPosition.x * positionYawFactor;//yaw is coupled to position
        float roll = xThrow * controlRollFactor;//roll is coupled to control throw
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private float MoveTheShipX()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");//crossplatform input
        float xOffsetThisFrame = xSpeed * xThrow * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffsetThisFrame;
        float xPos = Mathf.Clamp(rawXPos, -xRange, +xRange);
        return xPos;
    }

    private float MoveTheShipY()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");//crossplatform input
        float yOffsetThisFrame = ySpeed * yThrow * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffsetThisFrame;
        float yPos = Mathf.Clamp(rawYPos, -yRange, +yRange);
        return yPos;
    }
}
