using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	static float timeStamp;
	Vector3 originalPos;

	float shakeAmt;
	static float shakeDuration;
	static bool shake = false;
	// Use this for initialization
	void Start () {
		originalPos = transform.position;
		shakeAmt = Settings.shakeAmt;
		shakeDuration = Settings.shakeDuration;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.T)){
			shake = true;
			timeStamp = Time.time + shakeDuration;
		}

		if(shake){
			if(timeStamp > Time.time){
				transform.position = new Vector3(originalPos.x + Random.Range(-shakeAmt, shakeAmt),
											 originalPos.y + Random.Range(-shakeAmt, shakeAmt),
											 originalPos.z);
			}else{
				shake = false;
				transform.position = originalPos;
			}
		}
	}

	public static void startScreenShake(){
		shake = true;
		timeStamp = Time.time + shakeDuration;
	}
}
