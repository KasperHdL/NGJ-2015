using UnityEngine;
using System.Collections;

public class Seeker : MonoBehaviour {

	public playerMovement player;

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.tag == "Joint"){
			JointPiece j = coll.gameObject.GetComponent<JointPiece>();
			if(!j.hooked && j.owner == player.gameObject){
				player.hook(j);
			}
		}
	}
}
