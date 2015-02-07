using UnityEngine;
using System.Collections;

public class Trail : MonoBehaviour {

	private bool inited = false;
	private float decayEnd;


	public void setDecayLength(float time){
		decayEnd = Time.time + time;
		inited = true;
	}

	void Update(){
		if(inited){
			if(decayEnd < Time.time){
				Destroy(this.gameObject);
			}
		}
	}
}
