﻿using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	 float timeStamp;
	Vector3 originalPos;

	float shakeAmt;
	 float shakeDuration;
	 bool shake = false;
	// Use this for initialization
	void Start () {
		originalPos = transform.position;
		shakeAmt = Settings.shakeAmt;
		shakeDuration = Settings.shakeDuration;
	}

	// Update is called once per frame
	void Update () {

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

	public  void startScreenShake(){
		shake = true;
		timeStamp = Time.time + shakeDuration;
	}
	public  void startShake(float amt, float t){
		shake = true;
		shakeAmt = amt;
		timeStamp = Time.time + t;
	}
}
