using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_MovingPlatform : MonoBehaviour {

    	//set a variable for player
    	GameObject pChar;
	//make a variable for the collider
    	BoxCollider trigZone;
	//setup the raycast
    	RaycastHit hit;

	// Use this for initialization
	void Start () {
		//assign a alue ot the player using the tag Player
        	pChar = GameObject.FindWithTag("Player");
        
		//makes a new collider on the moving platform
       		trigZone = gameObject.AddComponent<BoxCollider>();
		//sets the collider to trigger
        	trigZone.isTrigger = true;
		//sets the size of the platforms new collider
        	trigZone.size = new Vector3(1,1.6f,1);
	}
	
	//don't worry about this old code
	// Update is called once per frame
	void Update () {
		/*if(Physics.Raycast(pChar.transform.position,pChar.transform.up *-1, out hit, 5) && hit.transform.gameObject == gameObject)
        {
            Debug.Log("enter");
            pChar.transform.parent = transform;
        }
        else
        {
            if(pChar.transform.parent != null)
            {
                Debug.Log("exit");
                pChar.transform.parent = null;
            }
        }
        */
	}

	//if the player enters the trigger collider
   private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
		//tell console you entered then set the player's parent to this object
            Debug.Log("enter");
            pChar.transform.parent = transform;
        }
    }
	//if the player exits the trigger collider
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
		//tell the console you exited and remove the player's parent
            Debug.Log("exit");
            pChar.transform.parent = null;
        }
    }
	//ignore this old code
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == GameObject.FindWithTag("Player"))
        {
            Debug.Log("Enter");
            pChar.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == GameObject.FindWithTag("Player"))
        {
            Debug.Log("Exit");
            pChar.transform.parent = null;
        }
    }*/
}
