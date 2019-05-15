using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Speed parameters")]
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 100f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 100f;
    [SerializeField] GameObject[] guns;
    //Range parameters
    [Header("Range parameters")]
    [SerializeField] float xRange = 200f;
    [SerializeField] float yRange = 150f;
    float xThrow = 0f;
    float yThrow = 0f;
    bool dead = false;

    //position parameters
    [Header("Position parameters")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;

    [Header("Control Throw parameters")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;
    bool isFiring = false;

    

    // Use this for initialization
	// Update is called once per frame
	void Update ()
    {
        if(!dead)
        {
            ProcessShipControl();
        }
        if (CrossPlatformInputManager.GetButton("Cancel"))
        {
            Application.Quit();
        }
    }

    private void ProcessShipControl()
    {
        float xPos = MoveTheShipX();
        float yPos = MoveTheShipY();
        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessFiring()
    {
        if(CrossPlatformInputManager.GetButton("Fire"))
        {

            ActivateGuns(true);
        }
        else
        {
            ActivateGuns(false);
        }
    }

    void ActivateGuns(bool isFiring)
    {
        foreach(GameObject gun in guns)
        {
            var emitter = gun.GetComponent<ParticleSystem>().emission;
            emitter.enabled = isFiring;
        }
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
    private void KillPlayer()//called by message from CollisionHandler
    {
        dead = true;
    }
}
