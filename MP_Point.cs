using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Point : MonoBehaviour {
	//make a variable to call the MP_Score script easier
    MP_Score counter;
	// Use this for initialization
	void Start () {
		//set the variable to the MP_Score script
        counter = FindObjectOfType<MP_Score>();
		//call the IsAPoint function from the MP_Score script
        counter.IsAPoint();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//check if player entered the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
		//tell the MP_Score script you collected this point
            counter.GotPoint();
		//get rid of this point
            Destroy(gameObject);
        }
    }
}
