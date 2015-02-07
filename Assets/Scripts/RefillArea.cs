using UnityEngine;
using System.Collections;

public class RefillArea : MonoBehaviour {
	public int countSpeed = 5;
	int countNum = 0;

	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Player") {
			if (countNum > countSpeed) {
				if(playerMovement.health<100){
					playerMovement.health = playerMovement.health + 1;
				}
				countNum = 0;
			}
			countNum++;
			}
	}
}