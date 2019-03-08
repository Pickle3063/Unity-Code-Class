using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_CheckpointManager : MonoBehaviour {
    //where the player is going to be put when they respawn
    public Vector3 curPos;
    public Quaternion curRot;

	// Use this for initialization
	void Start () {
        //resets the checkpoints to starting position when starting the scene
        curPos = GameObject.FindWithTag("Player").transform.position;
        curRot = GameObject.FindWithTag("Player").transform.rotation;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //respawn function
    public void Respawn()
    {
        //puts the player at the last checkpoint
        GameObject.FindWithTag("Player").transform.SetPositionAndRotation(curPos, curRot);
    }
}
