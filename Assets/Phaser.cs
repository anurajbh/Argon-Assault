using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phaser : MonoBehaviour
{

    // Use this for initialization

    [SerializeField] GameObject firepoint;
    [SerializeField] LineRenderer lr;
    [SerializeField] Camera cam;
    [SerializeField] float maxLength;

	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        lr.SetPosition(0, firepoint.transform.position);
        RaycastHit hit;
        var mousePos = Input.mousePosition;
        var rayMouse = cam.ScreenPointToRay(mousePos);

        if(Physics.Raycast (rayMouse.origin, rayMouse.direction, out hit, maxLength))
        {
            if(hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }
            else
            {
                var pos = rayMouse.GetPoint(maxLength);
                lr.SetPosition(1, pos);
            }
        }
	}
}
