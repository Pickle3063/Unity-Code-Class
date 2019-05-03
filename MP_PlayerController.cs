using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//you need this to use the UI such as the Text variable
using UnityEngine.UI;   

public class MP_PlayerController : MonoBehaviour {

    //for adjusting speed and jump height in inspector
    public float speed;
    public float jumpHeight;
    //so we can change the text objects we drag into here through script
    public Text countText;
    public Text winText;
    //so we can reference the camera easier
    public Camera cam;

    //for referencing the rigidbody of our player
    private Rigidbody rb;
    //the amount of pickups we have collected
    private int Count;
    //are we touching the ground or not so that we can jump if true
    private bool touchingGround;

    //basics of a raycast, a hit and a distance, in this case the distance is to the ground
    RaycastHit hit;
    float dist = 1;

    private void Start()
    {
        //setting up our rigidbody reference to the rigidbody of this object
        rb = GetComponent<Rigidbody>();
        //resetting our count to 0 then updating the text
        Count = 0;
        SetCountText();
        //making sure the wintext is "invisible"
        winText.text = "";
    }
    //runs every frame
    private void Update()
    {
        //raycast down, like pointing a laser down to see if we hit something
        if(Physics.Raycast(transform.position,Vector3.down,out hit, dist))
        {
            //if we do hit something then we can jump again
            touchingGround = true;
        }
        else
        {
            //if not then we cannot jump again
            touchingGround = false;
        }
    }
    //runs the physics every frame
    private void FixedUpdate()
    {
        //gets our input
        float moveHoriz = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");
        //gets the forward vector of the camera, so direction camera is facing
        Vector3 fore = Vector3.Scale(cam.transform.forward, new Vector3(1, 0, 1)).normalized;
        //moves the character forward and back in reference to camera view, or left and right in reference to camera view
        Vector3 movement = (moveVert * fore + moveHoriz * cam.transform.right).normalized;
        //pushes our character as if rolling a ball by adding force in the direction we tell it to move
        rb.AddForce(movement * speed);

        //if we press space and are touching the ground
        if (Input.GetKeyDown(KeyCode.Space) && touchingGround == true)
        {
            //then add force upwards times our jumpheight to jump
            rb.AddForce(Vector3.up * jumpHeight);
        }
        
    }

    //if we collide with a pickup that has a trigger collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            //deactivate the pikcup and increase our count then update the text
            other.gameObject.SetActive(false);
            Count = Count + 1;
            SetCountText();
        }
    }

    //updates the text each time we call it
    void SetCountText()
    {
        //sets our count to how many pickups we have
        countText.text = "Count: " + Count.ToString();
        //if we have more than twelve pickups we win
        if(Count >= 12)
        {
            winText.text = "You Win!";
        }
    }
}
