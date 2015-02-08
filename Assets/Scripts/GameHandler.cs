using UnityEngine;
using System.Collections;

public class GameHandler : MonoBehaviour{

	///Handles game states (menu, playing, gameover)

	public GameObject startScreen;
	public static GameObject restartScreen;
	public static CameraShake cam;

	public static bool stopGame = false;
	public static float stopGameTime;


	void Awake(){
		startScreen.SetActive(true);
		Time.timeScale = 0;

		restartScreen = GameObject.Find("RestartScreen");

		cam = Camera.main.GetComponent<CameraShake>();
	}

	void Update(){


	}

	public void onStartGameClick(){
		startScreen.SetActive(false);

				XInputDotNetPure.GamePad.SetVibration (XInputDotNetPure.PlayerIndex.One, 0, 0);
				XInputDotNetPure.GamePad.SetVibration (XInputDotNetPure.PlayerIndex.Two, 0, 0);


		Time.timeScale = 1;
	}

	public static void GameOver(string name){
//				restartScreen.SetActive(true);
				XInputDotNetPure.GamePad.SetVibration (XInputDotNetPure.PlayerIndex.One, 0, 0);
				XInputDotNetPure.GamePad.SetVibration (XInputDotNetPure.PlayerIndex.Two, 0, 0);
				Time.timeScale = 0;
	}

	public static void Restart(){

	}
}
