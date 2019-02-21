using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MP_Score : MonoBehaviour {

    int winPoints = 0;
    int totPoints = 0;

    float timePass;
    float timer = .2f;

    bool won = false;
    float winPass = 0;
    float winTime = 4;
	
	// Update is called once per frame
	void Update () {
        timePass += Time.deltaTime;
        if (won)
        {

            winPass += Time.deltaTime;
            if (winPass > winTime)
            {
                FindObjectOfType<MP_DeathZone>().RestartScene();
            }
        }
    }

    public void IsAPoint()
    {
        winPoints++;
        UpdatePoints();
        Debug.Log("WinPoints: " + winPoints);
    }
    public void GotPoint()
    {
        if(timePass > timer)
        {
            totPoints++;
            timePass = 0;
        }

        
       
        UpdatePoints();
        Debug.Log("got a point");
        if (totPoints == winPoints)
        {
            gameObject.GetComponent<Text>().rectTransform.anchoredPosition = new Vector2(0, 0);
            gameObject.GetComponent<Text>().text = "YOU WIN";
            won = true;
        }
    }

    void UpdatePoints()
    {
        gameObject.GetComponent<Text>().text = ("Score: " + totPoints + " / " + winPoints + "");
    }
}
