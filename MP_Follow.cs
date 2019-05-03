using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Follow : MonoBehaviour {

	//so we can set the speed of the object in inspector and get a reference to the player
    	public float speed;
    	public GameObject player;

	// Update is called once per frame
	void Update () {

		//simply pulls the object towards the player
        	transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * speed);
	}
}
