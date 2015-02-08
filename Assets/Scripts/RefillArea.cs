using UnityEngine;
using System.Collections;

public class RefillArea : MonoBehaviour {
	int countSpeed = 5;
	int countNum = 0;
	public float timeStamp;

	public float refillSpeed;
	public AudioClip audioClip; //get sounds

	void Start(){
		refillSpeed = Settings.refillSpeed;
		timeStamp = 0;
	}

	void Update(){
		stopSound ();
		}
	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "Follower") {
			if (countNum > countSpeed) {
				Sponge sponge = other.gameObject.GetComponent<Sponge>();

				if(sponge.amountFilled + refillSpeed < Settings.partFillCapacity){
					sponge.amountFilled += refillSpeed;
					playSound ();
				}
				countNum = 0;
			}
			countNum++;
		}
	}

	void playSound()          //function for playing a sound from the sound array
	{
		if (Time.time > timeStamp) {
			audio.clip = audioClip;
			audio.Play ();
			audio.loop = true;
			timeStamp = Time.time + audio.clip.length;
		}
	}
	void stopSound()          //function for playing a sound from the sound array
	{
		audio.clip = audioClip;
		audio.loop = false;
	}
}