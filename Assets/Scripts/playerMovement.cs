using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerMovement : MonoBehaviour {

	//used to refer to input keys
	public string player_name;

	//references
	public Slider slider;
	public Sponge sponge;


	public float health;

	private float rotationSpeed;
	private float speed;

	//slow vars
	private bool slowed = false;
	private float slowEnd;
	private float slowLength;

	//speedup vars
	private bool speedup = false;
	private float speedupEnd;
	private float speedupLength;

	// Use this for initialization
	void Start () {
		health = Settings.playerHealth;

		slowLength = Settings.playerOnEnemyTrailSpeedLength;
		speedupLength = Settings.playerOnFriendlyTrailSpeedLength;

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

		if(speedup && speedupEnd < Time.time){
			speedup = false;
			speed = Settings.playerSpeed;
		}

		if(slowed && slowEnd < Time.time){
			slowed = false;
			speed = Settings.playerSpeed;
			rotationSpeed = Settings.playerRotSpeed;
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

		speed = Settings.playerOnEnemyTrailSpeed;
		rotationSpeed = Settings.playerOnEnemyTrailRotSpeed;
	}

	public void startSpeed(){
		speedupEnd = Time.time + speedupLength;
		speedup = true;

		speed = Settings.playerOnFriendlyTrailSpeed;
	}
}
