using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 100f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 100f;
    [SerializeField] float xRange = 200f;
    [SerializeField] float yRange = 150f;
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
        print("Hello there");
        //transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
    }

    private float MoveTheShipX()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffsetThisFrame = xSpeed * xThrow * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffsetThisFrame;
        float xPos = Mathf.Clamp(rawXPos, -xRange, +xRange);
        return xPos;
    }

    private float MoveTheShipY()
    {
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffsetThisFrame = ySpeed * yThrow * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffsetThisFrame;
        float yPos = Mathf.Clamp(rawYPos, -yRange, +yRange);
        return yPos;
    }
}
