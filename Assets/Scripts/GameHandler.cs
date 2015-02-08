using UnityEngine;
using System.Collections;

public class GameHandler : MonoBehaviour{

	///Handles game states (menu, playing, gameover)

	public GameObject startScreen;

	void Awake(){
		startScreen.SetActive(true);
		Time.timeScale = 0;
	}

	public void onStartGameClick(){
		startScreen.SetActive(false);
		Time.timeScale = 1;
	}

	public static void GameOver(){
		Time.timeScale = 0;
	}

	public static void Restart(){

	}
}
