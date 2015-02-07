using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerMovement : MonoBehaviour {

	//used to refer to input keys
	public string player_name;

	public static int health = 50;

	public Slider slider;

	private float rotationSpeed;
	private float speed;

	//slow vars
	private bool slowed = false;
	private float slowEnd;
	private float slowLength;

	// Use this for initialization
	void Start () {
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

		//debug for healthbar slider
		if (health <= 100) {
				if (Input.GetKey (KeyCode.Q)) {
						health += 1;
				}
		}
		if (health >= 0) {
				if (Input.GetKey (KeyCode.E)) {
						health -= 1;
				}
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
