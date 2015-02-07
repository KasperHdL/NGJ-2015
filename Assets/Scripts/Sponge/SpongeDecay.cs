using UnityEngine;
using System.Collections;

public class SpongeDecay : MonoBehaviour {


	public GameObject trail_prefab;
	private float trailDecayLength;

	private float distBetweenTrails;
	private Vector3 lastPlacedTrailPos;

	// Use this for initialization
	void Start () {
		trailDecayLength = Settings.decayLength;
		distBetweenTrails = Settings.decayDistance;
		lastPlacedTrailPos = transform.position;
	}

	// Update is called once per frame
	void Update () {
		//check distance to last placed trail if greater then a set value then instantiate a new
		float dist = Vector3.Distance(lastPlacedTrailPos,transform.position);
		if(dist > distBetweenTrails){
			instantTrail();
		}
	}

	//instants a trail on the currentposition
	private void instantTrail(){
		Vector3 pos = transform.position;
		lastPlacedTrailPos = pos;
		GameObject g = Instantiate(trail_prefab,pos,Quaternion.identity) as GameObject;

		//sets how long the trail will live
		Trail t = g.GetComponent<Trail>();
		t.setDecayLength(trailDecayLength);
	}
}
