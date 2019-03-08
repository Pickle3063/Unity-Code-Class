using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Checkpoint : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //if player enters area set the checkpoint
        if(other.tag == "Player")
        {
            SetCheckpoint();
        }
    }

    void SetCheckpoint()
    {
        //sets the current position and rotation that the checkpoint manager saves to the checkpoints current position and rotation
        FindObjectOfType<MP_CheckpointManager>().curPos = transform.position;
        FindObjectOfType<MP_CheckpointManager>().curRot = transform.rotation;
    }
}
