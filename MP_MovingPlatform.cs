using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_MovingPlatform : MonoBehaviour {

    [SerializeField]
    GameObject pChar;
    BoxCollider trigZone;
    RaycastHit hit;

	// Use this for initialization
	void Start () {
        pChar = GameObject.FindWithTag("Player");
        
       trigZone = gameObject.AddComponent<BoxCollider>();
        trigZone.isTrigger = true;
        trigZone.size = new Vector3(1,1.6f,1);
	}
	
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

   private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("enter");
            pChar.transform.parent = transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("exit");
            pChar.transform.parent = null;
        }
    }
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
