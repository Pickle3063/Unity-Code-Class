using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Disappear : MonoBehaviour
{

    //public Light myLight;
    [SerializeField]
    float timePass;
    [SerializeField]
    float timer;

    void Update()
    {
        timePass += Time.deltaTime;
        if (timePass > timer)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = !gameObject.GetComponent<MeshRenderer>().enabled;
            gameObject.GetComponent<Collider>().enabled = !gameObject.GetComponent<Collider>().enabled;
            timePass = 0;

        }


    }
}
