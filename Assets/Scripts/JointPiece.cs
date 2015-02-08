using UnityEngine;
using System.Collections;

public class JointPiece : MonoBehaviour {

	public GameObject owner;
	public int index;

	public bool hooked = true;


	public bool jointOnCooldown = false;
	private float jointCooldownEnd;
	private float jointCooldownLength;


	// Use this for initialization
	void Start () {
		jointCooldownLength = Settings.jointCooldownLength;
	}

	void Update(){
		if(jointOnCooldown && jointCooldownEnd < Time.time){
			hooked = false;
			jointOnCooldown = false;
		}
	}

	public void startCooldown(){
		hooked = true;
		jointOnCooldown = true;
		jointCooldownEnd = Time.time + jointCooldownLength;
	}

}
