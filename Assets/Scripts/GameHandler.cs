using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameHandler : MonoBehaviour{

	///Handles game states (menu, playing, gameover)

	public Text Loser;
	public GameObject titlescreen;
	public GameObject restartScreen;
	public static CameraShake cam;

	public static bool stopGame = false;
	public static float stopGameTime;


	public bool inited = false;


	void Awake(){
		Time.timeScale = 0;


		cam = Camera.main.GetComponent<CameraShake>();
	}

	void Update(){
		if(!inited && Time.unscaledTime > 2f){
			titlescreen.SetActive(false);
			Time.timeScale = 1f;
			inited = true;
		}

	}

	public void onStartGameClick(){

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

	public void Restart(){
		Application.LoadLevel(Application.loadedLevel);
	}
}
