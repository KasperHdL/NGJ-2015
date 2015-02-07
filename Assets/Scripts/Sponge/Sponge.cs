using UnityEngine;
using System.Collections;

public class Sponge : MonoBehaviour {
	//references
	public GameObject owner;
	public GameObject trail_prefab;
	public Transform trail_container;

	public HingeJoint2D parentJoint;


	//how long between each trail
	private float trailDecayLength;
	private float decayCost;

	public float amountFilled;

	private float distBetweenTrails;
	private Vector3 lastPlacedTrailPos;

	// Use this for initialization
	void Start () {
		trailDecayLength = Settings.decayLength;
		distBetweenTrails = Settings.decayDistance;
		lastPlacedTrailPos = transform.position;

		amountFilled = Settings.spongeCapacity;
		decayCost = Settings.drainSpeedPerTrail;
	}

	// Update is called once per frame
	void Update () {
		//check distance to last placed trail if greater then a set value then instantiate a new
		float dist = Vector3.Distance(lastPlacedTrailPos,transform.position);
		if(dist > distBetweenTrails && amountFilled >= 0){
			instantTrail();
			amountFilled -= decayCost;
		}
	}

	//instants a trail on the currentposition
	private void instantTrail(){
		Vector3 pos = transform.position;
		lastPlacedTrailPos = pos;
		GameObject g = Instantiate(trail_prefab,pos,Quaternion.identity) as GameObject;
		g.transform.parent = trail_container;
		//sets how long the trail will live
		Trail t = g.GetComponent<Trail>();
		t.setOwner(owner);
		t.setDecayLength(trailDecayLength);

	}
}
