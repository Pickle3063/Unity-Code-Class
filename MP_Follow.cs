using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Follow : MonoBehaviour {

    public float speed;
    public GameObject player;

	// Update is called once per frame
	void Update () {

        //transform.LookAt(player.transform.position);
        transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * speed);
	}
}
