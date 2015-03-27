using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {


	public GUISkin mySkin;
	public string levelToLoad;
	public bool paused = false;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (paused)
				paused = false;
			else 
				paused = true;
		}

		if (paused) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}


	public void onClickMouse(){
		if (paused)
			paused = false;
		else 
			paused = true;
	
	
	if (paused) {
		Time.timeScale = 0;
	} else {
		Time.timeScale = 1;
	}
}


	private void OnGUI()
	{
		GUI.skin=mySkin;   //use the custom GUISkin
		
		if (paused){    
			
			GUI.Box(new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2), "PAUSED");
			//GUI.Label(new Rect(Screen.width/4+10, Screen.height/4+Screen.height/10+10, Screen.width/2-20, Screen.height/10), "YOUR SCORE: "+ ((int)score));
			
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+Screen.height/10+10, Screen.width/2-20, Screen.height/10), "RESUME")){
				paused = false;
			}
			
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+2*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "RESTART")){
				Application.LoadLevel(Application.loadedLevel);
			}
			
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+3*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "MAIN MENU")){
				Application.LoadLevel(levelToLoad);
			} 
		}
	}
}