using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this lets the script use the UI
using UnityEngine.UI;

public class MP_Score : MonoBehaviour {

	//variables to track how many points needed to win and how many you have
    int winPoints = 0;
    int totPoints = 0;

	//set up a .2 second timer
    float timePass;
    float timer = .2f;

	//make a boolean for if you have won and a timer set for 4 seconds
    bool won = false;
    float winPass = 0;
    float winTime = 4;
	
	// Update is called once per frame
	void Update () {
		//run the regular timer
        timePass += Time.deltaTime;
		//if you win then run the win timer
        if (won)
        {

            winPass += Time.deltaTime;
		//when the win timer is done
            if (winPass > winTime)
            {
		    //find the death zone and tell it to restart the scene
                FindObjectOfType<MP_DeathZone>().RestartScene();
		     //use this line instead if using checkpoints
                //FindObjectOfType<MP_CheckDeathZone>().RestartScene();
            }
        }
    }

	//this is called by points to say that is is a point
    public void IsAPoint()
    {
	    //when this is called it increases the max points needed by one
        winPoints++;
	    //it updates the text saying your score
        UpdatePoints();
	    //and tells the console how many is needed to win
        Debug.Log("WinPoints: " + winPoints);
    }
	//this is called by a point when you collect the point
    public void GotPoint()
    {
	    //if the normal timer is done
        if(timePass > timer)
        {
		//increase the amount of points scored by one
            totPoints++;
		//reset the timer, this timer makes sure it only counts one point per point gotten
            timePass = 0;
        }

        
       //update the text saying how many points you scored
        UpdatePoints();
	    //tells the console you got a point
        Debug.Log("got a point");
	    //if your score is equal to the total needed
        if (totPoints == winPoints)
        {
		//move the text to the center of the screen
            gameObject.GetComponent<Text>().rectTransform.anchoredPosition = new Vector2(0, 0);
		//say you win
            gameObject.GetComponent<Text>().text = "YOU WIN";
		//tell the boolean you won
            won = true;
        }
    }
 //lets other scripts check if the boolean is true or false
    public bool GetWon()
    {
        return won;
    }
	//this is called whenever you want to update the score text
    void UpdatePoints()
    {
	    //this sets the text to say how much you've scored out of the total
        gameObject.GetComponent<Text>().text = ("Score: " + totPoints + " / " + winPoints + "");
    }
}
