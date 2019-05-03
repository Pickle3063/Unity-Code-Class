using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//you need this to restart the scene
using UnityEngine.SceneManagement;

public class MP_DeathZone : MonoBehaviour {

    //when colliding with a player
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //restart scene
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }
}
