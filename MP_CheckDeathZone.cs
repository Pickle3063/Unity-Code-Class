using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this script is almost identical to the regular deathzone
public class MP_CheckDeathZone : MonoBehaviour {
    RaycastHit hit;
    GameObject player;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        if (Physics.Raycast(player.transform.position, player.transform.up * -1, out hit, 5) && hit.transform.gameObject == gameObject)
        {
            Debug.Log("hit");
            RestartScene();
        }
    }
    public void RestartScene()
    {
        Debug.Log("restart");
        //instead it checks if you have won and if you haven't then you go to a checkpoint, if you have won you restart scene like normal
        if (FindObjectOfType<MP_Score>().GetWon())
        {
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
        else
        {
            FindObjectOfType<MP_CheckpointManager>().Respawn();
        }
       
    }
}
