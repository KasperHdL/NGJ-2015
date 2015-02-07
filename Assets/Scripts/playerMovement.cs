using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerMovement : MonoBehaviour {

	//used to refer to input keys
	public string player_name;

	public Slider slider;

	public float health;

	private float rotationSpeed;
	private float speed;

	//slow vars
	private bool slowed = false;
	private float slowEnd;
	private float slowLength;

	// Use this for initialization
	void Start () {
		health = Settings.playerHealth;
		slowLength = Settings.slowLength;
		speed = Settings.playerSpeed;
		rotationSpeed = Settings.playerRotSpeed;
	}

	// Update is called once per frame
	void Update () {
		//player movement
		float hori = Input.GetAxis(player_name + "_hori");
		transform.Rotate (hori * rotationSpeed, 0, 0);

		rigidbody2D.velocity = transform.forward * speed;
		slider.value = health;

		if(slowed && slowEnd < Time.time){
				slowed = false;
				speed = Settings.slowedPlayerSpeed;
				rotationSpeed = Settings.slowedPlayerRotSpeed;
		}
	}
	void OnTriggerEnter(Collider other){
			if (other.gameObject.tag == "Wall") {
				transform.Rotate (0, 180, 0);
				OnJointBreak();
			}
	}

	void OnJointBreak() {

	}

	public void startSlow(){
		slowEnd = Time.time + slowLength;
		slowed = true;

		speed = Settings.playerSpeed;
		rotationSpeed = Settings.playerRotSpeed;
	}
}
