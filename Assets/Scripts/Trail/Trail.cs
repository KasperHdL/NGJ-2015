using UnityEngine;
using System.Collections;

public class Trail : MonoBehaviour {

	private bool inited = false;
	private float decayEnd;
	public GameObject owner;


	public void setDecayLength(float time){
		decayEnd = Time.time + time;
		inited = true;
	}

	public void setOwner(GameObject o){
		owner = o;
	}

	void Update(){
		if(inited){
			if(decayEnd < Time.time){
				Destroy(this.gameObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.tag == "Player"){
			playerMovement script = coll.gameObject.GetComponent<playerMovement>();
			if(owner != coll.gameObject){
				script.startSlow();
			}
			Destroy(this.gameObject);
		}
	}
}
