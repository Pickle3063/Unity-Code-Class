using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_CameraController : MonoBehaviour {

    public GameObject player;
    public float turnSpeed;
    private Vector3 offset;
   // private Vector3 camOffset;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
        //camOffset = new Vector3(player.transform.position.x, player.transform.position.y + 10.0f, player.transform.position.z + 10.0f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate () {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform.position);
	}
}
