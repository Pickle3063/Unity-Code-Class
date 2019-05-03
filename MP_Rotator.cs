using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Rotator : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		//rotates the object
        	transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
}
