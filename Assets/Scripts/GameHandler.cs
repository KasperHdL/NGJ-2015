using UnityEngine;
using System.Collections;

public class GameHandler : MonoBehaviour{

	///Handles game states (menu, playing, gameover)

	public GameObject startScreen;
	public static CameraShake cam;

	public static bool stopGame = false;
	public static float stopGameTime;


	void Awake(){
		startScreen.SetActive(true);
		Time.timeScale = 0;

		cam = Camera.main.GetComponent<CameraShake>();
	}

	void Update(){


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
