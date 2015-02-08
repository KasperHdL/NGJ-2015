using UnityEngine;
using System.Collections;

public class RefillArea : MonoBehaviour {
	int countSpeed = 5;
	int countNum = 0;

	public float refillSpeed;
	public AudioClip mySound; //get sounds

	void Start(){
		refillSpeed = Settings.refillSpeed;
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "Follower") {
			if (countNum > countSpeed) {
				Sponge sponge = other.gameObject.GetComponent<Sponge>();
				audio.Play ();

				if(sponge.amountFilled + refillSpeed < Settings.partFillCapacity){
					sponge.amountFilled += refillSpeed;
				}else{
					sponge.amountFilled = Settings.partFillCapacity;
				}
				countNum = 0;
			}
			countNum++;
			audio.Stop();
		}
	}
}