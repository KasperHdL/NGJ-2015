using UnityEngine;
using System.Collections;

public class FollowerScript : MonoBehaviour {

	public Transform player;
	public Transform tail;

	public static int speed = Settings.followSpeed;
	public static int chain = Settings.chainLength;

	Vector2 tailVelocity;

	Vector2 target;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

		/*tail.rigidbody.velocity *= 0.99f;

		Debug.DrawLine(tail.position, player.position, Color.white, 0.0f);

		target = new Vector2(player.position.x, player.position.y);

		tail.transform.LookAt(player);

		if(Vector2.Distance(player.position, tail.position) > chain){
			tail.rigidbody.AddForce(tail.forward * speed);
		}*/
	}
}
