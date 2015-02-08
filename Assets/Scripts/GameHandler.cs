using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameHandler : MonoBehaviour{

	///Handles game states (menu, playing, gameover)

	public Text Loser;
	public GameObject startScreen;
	public GameObject restartScreen;
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

				XInputDotNetPure.GamePad.SetVibration (XInputDotNetPure.PlayerIndex.One, 0, 0);
				XInputDotNetPure.GamePad.SetVibration (XInputDotNetPure.PlayerIndex.Two, 0, 0);


		Time.timeScale = 1;
	}

	public void GameOver(string name){
				restartScreen.SetActive(true);
				if(name == "P1")name = "Red";
				else name = "Blue";

				Loser.text = name + " lost!";
				XInputDotNetPure.GamePad.SetVibration (XInputDotNetPure.PlayerIndex.One, 0, 0);
				XInputDotNetPure.GamePad.SetVibration (XInputDotNetPure.PlayerIndex.Two, 0, 0);
				Time.timeScale = 0;
	}

	public static void Restart(){

	}
}
