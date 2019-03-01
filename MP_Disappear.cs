using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Disappear : MonoBehaviour
{

    //setting a timer that can be modified in the inspector
    float timePass;
    [SerializeField]
    float timer;

    void Update()
    {
        //the timer which runs in update, goes by seconds
        timePass += Time.deltaTime;
        //if the timer is done
        if (timePass > timer)
        {
            //toggle the mesh and collider off and on
            gameObject.GetComponent<MeshRenderer>().enabled = !gameObject.GetComponent<MeshRenderer>().enabled;
            gameObject.GetComponent<Collider>().enabled = !gameObject.GetComponent<Collider>().enabled;
            //reset timer
            timePass = 0;

        }


    }
}
