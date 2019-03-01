using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MP_DeathZone : MonoBehaviour {
    //setting up the raycast
    RaycastHit hit;
    //setting up the player variable
    GameObject player;
    private void Start()
    {
        //assigning a value to the player variable by find the object tagged Player
        player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        //sending out a raycast downard from player, and then checking if it hits this object
        if(Physics.Raycast(player.transform.position,player.transform.up*-1 , out hit, 5) && hit.transform.gameObject == gameObject)
        {
            //tells if you hit the object in console then calls the restart scene function
            Debug.Log("hit");
            RestartScene();
        }
    }
    //restarts the scene when called
    public void RestartScene()
    {
        //tells console this function was called
        Debug.Log("restart");
        //makes and sets a variable named scene to the current scene
        int scene = SceneManager.GetActiveScene().buildIndex;
        //loads the current scene
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
