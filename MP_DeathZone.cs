using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MP_DeathZone : MonoBehaviour {
    RaycastHit hit;
    GameObject player;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        if(Physics.Raycast(player.transform.position,player.transform.up*-1 , out hit, 5) && hit.transform.gameObject == gameObject)
        {
            Debug.Log("hit");
            RestartScene();
        }
    }
    public void RestartScene()
    {
        Debug.Log("restart");
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
