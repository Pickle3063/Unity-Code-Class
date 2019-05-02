using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class MP_PlayerController : MonoBehaviour {

    public float speed;
    public float jumpHeight;
    public Text countText;
    public Text winText;
    public Camera cam;

    private Rigidbody rb;
    private int Count;
    private bool touchingGround;

    RaycastHit hit;
    float dist = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Count = 0;
        SetCountText();
        winText.text = "";
    }
    private void Update()
    {
        if(Physics.Raycast(transform.position,Vector3.down,out hit, dist))
        {
            touchingGround = true;
        }
        else
        {
            touchingGround = false;
        }
    }
    private void FixedUpdate()
    {
        float moveHoriz = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");
        Vector3 fore = Vector3.Scale(cam.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 movement = (moveVert * fore + moveHoriz * cam.transform.right).normalized;
        rb.AddForce(movement * speed);
        //Vector3 movement = new Vector3(moveHoriz, 0, moveVert);

        if (Input.GetKeyDown(KeyCode.Space) && touchingGround == true)
        {
            rb.AddForce(Vector3.up * jumpHeight);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            Count = Count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + Count.ToString();
        if(Count >= 12)
        {
            winText.text = "You Win!";
        }
    }
}
