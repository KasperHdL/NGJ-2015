using UnityEngine;
using System.Collections;

public class RefillArea : MonoBehaviour {
	int countSpeed = 5;
	int countNum = 0;
	public float timeStamp;

	public float refillSpeed;

	public GameObject owner;

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
				if(sponge.owner == owner && sponge.amountFilled + refillSpeed < Settings.partFillCapacity){
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
			audio.Play ();
			audio.loop = true;
			timeStamp = Time.time + audio.clip.length;
		}
	}
	void stopSound()          //function for playing a sound from the sound array
	{
		audio.loop = false;
	}
}