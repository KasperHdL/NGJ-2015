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

	public float rotationSpeed;
	public float maxRotSpeed = 5f;
	public float speed;

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

		setupJointParents();
	}

	// Update is called once per frame
	void Update () {
		//get player movement
		float hori = Input.GetAxis(player_name + "_hori");
		float vert = Input.GetAxis(player_name + "_vert");

		//contrain rotation (if angular vel is greater than max allowed set to max angular vel else add torque)
		if(Mathf.Abs(rigidbody2D.angularVelocity) > maxRotSpeed)
			rigidbody2D.angularVelocity = Mathf.Sign(rigidbody2D.rotation) * maxRotSpeed;
		else
			rigidbody2D.AddTorque(-hori * rotationSpeed);

		//add vel
		rigidbody2D.velocity = -transform.right * vert * speed;
		slider.value = health;

		if(speedup && speedupEnd < Time.time){
			speedup = false;
			speed = Settings.playerSpeed;
		}

		if(slowed && slowEnd < Time.time){
			slowed = false;
			speed = Settings.playerSpeed;
		}
	}

	public void startSlow(){
		slowEnd = Time.time + slowLength;
		slowed = true;

		speed = Settings.playerOnEnemyTrailSpeed;
	}

	public void startSpeed(){
		speedupEnd = Time.time + speedupLength;
		speedup = true;

		speed = Settings.playerOnFriendlyTrailSpeed;
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Joint" && other.transform.parent.gameObject.name != player_name + " Chain") {
			other.gameObject.GetComponent<JointConnection>().breakJoint();

		}
	}


	void setupJointParents(){
		HingeJoint2D lastJoint = GetComponent<HingeJoint2D>();//starts with being the head
		HingeJoint2D currentJoint = lastJoint.connectedBody.GetComponent<HingeJoint2D>();

		while(true){

			currentJoint.GetComponent<JointConnection>().parentJoint = lastJoint;

			if(currentJoint.connectedBody.gameObject.tag == "Follower"){
				currentJoint.connectedBody.GetComponent<Sponge>().parentJoint = currentJoint;
				break;
			}

			lastJoint = currentJoint;
			currentJoint = currentJoint.connectedBody.GetComponent<HingeJoint2D>();
		}


	}
}
