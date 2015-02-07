using UnityEngine;
using System.Collections;

public class RefillArea : MonoBehaviour {
	int countSpeed = 5;
	int countNum = 0;

	public float refillSpeed;

	void Start(){
		refillSpeed = Settings.refillSpeed;
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "Follower") {
			if (countNum > countSpeed) {
				Sponge sponge = other.gameObject.GetComponent<Sponge>();

				if(sponge.amountFilled < Settings.spongeCapacity){
					sponge.amountFilled += refillSpeed;
				}
				countNum = 0;
			}
			countNum++;
		}
	}
}