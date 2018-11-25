using System;
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
    [SerializeField] float pitchFactor = -5f;
    [SerializeField] float yawFactor = 5f;
    [SerializeField] float rollFactor = -5f;

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

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * pitchFactor + yThrow;
        float yaw = transform.localPosition.x * yawFactor + xThrow;
        float roll = xThrow * rollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private float MoveTheShipX()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffsetThisFrame = xSpeed * xThrow * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffsetThisFrame;
        float xPos = Mathf.Clamp(rawXPos, -xRange, +xRange);
        return xPos;
    }

    private float MoveTheShipY()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffsetThisFrame = ySpeed * yThrow * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffsetThisFrame;
        float yPos = Mathf.Clamp(rawYPos, -yRange, +yRange);
        return yPos;
    }
}
