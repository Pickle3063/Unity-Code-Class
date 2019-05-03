using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_CameraController : MonoBehaviour {

	//get reference to player, give us the ability to change the camera sensitivity and gives us a value to use as our offset later on
    	public GameObject player;
   	public float turnSpeed;
    	private Vector3 offset;

	// Use this for initialization
	void Start () {
		
		//set the offset to camera position - player position,  might not actually need this anymore?
        	offset = transform.position - player.transform.position;
		//prevent the mouse from moving off screen (also hides mouse, hit escape to use mouse in editor)
        	Cursor.lockState = CursorLockMode.Locked;
    	}

    // Update is called last once per frame
    	void LateUpdate () {
		//sets offset to work with our mouse movements left and right
        	offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
		//sets the camera back and facing player
        	transform.position = player.transform.position + offset;
        	transform.LookAt(player.transform.position);
	}
}
