using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		//if(other.gameObject.tag == ){
		//Component.Destroy(yourComponent); 
		HingeJoint[] joints = GetComponents<HingeJoint>();
		foreach (HingeJoint joint in joints)
		Destroy(joint);
	}
}