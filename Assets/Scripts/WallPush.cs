using UnityEngine;
using System.Collections;

public class WallPush : MonoBehaviour {

	public Vector2 pushDir;
	public float pushForce;

	// Use this for initialization
	void Start () {

		pushForce = Settings.wallPushForce;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay2D(Collider2D other){
		Rigidbody2D rb = other.rigidbody2D;
		Vector3 delta = other.transform.position - transform.position;
		rb.AddForce(pushDir * pushForce * rb.mass);
	}
}
