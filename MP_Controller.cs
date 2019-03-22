using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Controller : MonoBehaviour {

    [SerializeField]
    float mouseSensX;
    [SerializeField]
    float mouseSensY;
    [SerializeField]
    float speed;
    float sprintSpd;
    [SerializeField]
    float jumpHeight;
    Rigidbody rigBod;

    RaycastHit hit;
    float dist = 1.2f;

    Camera cam;
    float rotationY;
    CursorLockMode lockIt = CursorLockMode.Locked;

	// Use this for initialization
	void Start () {
        rigBod = gameObject.GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
        SetCursorState();
        sprintSpd = speed * 3f;
	}
	
	// Update is called once per frame
	void Update () {

        
        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(transform.position, transform.up * -1, out hit, dist))
        {
            rigBod.AddForce(transform.up * jumpHeight);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rigBod.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * sprintSpd) + (transform.right * Input.GetAxis("Horizontal") * sprintSpd));
        }
        else
        {
            rigBod.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * speed) + (transform.right * Input.GetAxis("Horizontal") * speed));
        }
	}
    private void FixedUpdate()
    {
        rigBod.MoveRotation(rigBod.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * mouseSensX, 0)));
        cam.transform.rotation = (cam.transform.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * mouseSensX, 0)));
        rotationY += Input.GetAxis("Mouse Y") * mouseSensY;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);
        cam.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);


    }

    void SetCursorState()
    {
        Cursor.lockState = lockIt;
        Cursor.visible = (CursorLockMode.Locked != lockIt);
    }
}
