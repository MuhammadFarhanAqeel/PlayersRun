﻿using UnityEngine;
using System.Collections;

public class GameControlScript : MonoBehaviour {

	float timeRemaining = 10f; // pre-earned time
	float timeExtension = 2f; //time to extend by colleting powerup
	float timeDeduction = 4f; //time to reduce on collecting the snag
	float totalTimeElapsed = 0; 
	public float score = 0f;			// total score
	public bool isGameOver = false; 
	public GUISkin skin; 



	void Start () {
		Time.timeScale = 1;
	}



	void Update () {
	if (isGameOver)
			return; // if the gameover variable is true then it will jump out of the update method

		totalTimeElapsed += Time.deltaTime;
		score = totalTimeElapsed * 10;
		timeRemaining -= Time.deltaTime;

		if (timeRemaining <= 0) {
			isGameOver =true;
		}
	}

	void OnGUI()
	{
		GUI.skin = skin;
		//check if game is not over, if so, display the score and the time left
		if(!isGameOver)    
		{
			GUI.Label(new Rect(10, 10, Screen.width/5, Screen.height/6),"TIME LEFT: "+((int)timeRemaining).ToString());
			GUI.Label(new Rect(Screen.width-(Screen.width/6), 10, Screen.width/6, Screen.height/6), "SCORE: "+((int)score).ToString());
		}
		//if game over, display game over menu with score
		else
		{
			Time.timeScale = 0; //set the timescale to zero so as to stop the game world
			
			//display the final score
			GUI.Box(new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2), "GAME OVER\nYOUR SCORE: "+(int)score);
			
			//restart the game on click
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+Screen.height/10+10, Screen.width/2-20, Screen.height/10), "RESTART")){
				Application.LoadLevel(Application.loadedLevel);
			}
			
			//load the main menu, which as of now has not been created
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+2*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "MAIN MENU")){
				Application.LoadLevel(0);
			}
			
			//exit the game
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+3*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "EXIT GAME")){
				Application.Quit();
			}
		}
	}



	public void powerUpCollected(){
		timeRemaining += timeExtension;
	}

	public void obstacleCollected(){
		timeRemaining -= timeDeduction;
	}
}
