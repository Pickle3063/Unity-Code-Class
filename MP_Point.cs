using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Point : MonoBehaviour {
    MP_Score counter;
	// Use this for initialization
	void Start () {
        counter = FindObjectOfType<MP_Score>();
        counter.IsAPoint();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            counter.GotPoint();
            Destroy(gameObject);
        }
    }
}
