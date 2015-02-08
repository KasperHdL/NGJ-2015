using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerMovement : MonoBehaviour {

	//used to refer to input keys
	public string player_name;

	//references
	public Sponge sponge;

	public SpriteRenderer spriteRenderer;
	public int changeChannel;

	//fill stuff
	public float fillAmount;
	public float totalFillAmount;


	public GameObject trail_prefab;
	public Transform trail_container;

	private float trailDecayLength;

	CameraShake cam;

	public float health;

	public float rotationSpeed;
	public float maxRotSpeed;
	public float speed;

	//slow vars
	private bool slowed = false;
	private float slowEnd;
	private float slowLength;

	//speedup vars
	private bool speedup = false;
	private float speedupEnd;
	private float speedupLength;

	//dash vars
	private bool dash = false;

	//joints and Tail
	public GameObject[] joints = new GameObject[7];
	public int tailLength = 7;


	//how long between each trail
	private float decayCost;

	private float distBetweenTrails;
	private Vector3 lastPlacedTrailPos;

	//HACK -

	public GameObject[] allBodyParts = new GameObject[6];

	//Seeker -- looks for unattached parts
	public GameObject seeker;

	//dummy to fix unjointing
	public GameObject dummy_prefab;

	// Use this for initialization
	void Start () {
		cam = Camera.main.GetComponent<CameraShake>();
		//headfill
		fillAmount = 10;

		for(int i = 0;i<joints.Length-1;i++){
			allBodyParts[i] = joints[i];
			JointPiece j = joints[i].GetComponent<JointPiece>();
			j.index = i;
			j.owner = gameObject;
		}

		health = Settings.playerHealth;

		slowLength = Settings.playerOnEnemyTrailSpeedLength;
		speedupLength = Settings.playerOnFriendlyTrailSpeedLength;

		speed = Settings.playerSpeed;
		rotationSpeed = Settings.playerRotSpeed;
		maxRotSpeed = Settings.playerMaxRotSpeed;

		distBetweenTrails = Settings.decayDistance;
		lastPlacedTrailPos = transform.position;

		decayCost = Settings.drainSpeedPerTrail;
		trailDecayLength = Settings.decayLength;



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
			rigidbody2D.AddTorque(-hori * rotationSpeed * (8-tailLength)/1.4f);

		//add vel
		rigidbody2D.velocity = transform.right * vert * speed;

		rigidbody2D.mass = Settings.playerMass * (8-tailLength);

		if(Input.GetButton (player_name + "_dash")){
			decayCost = Settings.drainSpeedPerDashTrail;
			dash = true;
			speed = Settings.playerDashSpeed;
		} else {
			dash = false;
			speed = Settings.playerSpeed;
			decayCost = Settings.drainSpeedPerTrail;
		}

		if(!dash && speedup && speedupEnd < Time.time){
			speedup = false;
			speed = Settings.playerSpeed;
		}

		if(slowed && slowEnd < Time.time){
			slowed = false;
			speed = Settings.playerSpeed;
		}


		//check distance to last placed trail if greater then a set value then instantiate a new
		float dist = Vector3.Distance(lastPlacedTrailPos,transform.position);
		if(dist > distBetweenTrails && fillAmount > 0){
			Transform t = null;
			int i = 1;
			while(t == null){
				t = joints[tailLength-i++].transform;
				if(tailLength-i++ == -1)break;
			}

			if(dash){
				instantTrail(t,new Vector3(Random.Range(-2f,2f),Random.Range(-2f,2f),0));
				instantTrail(t,new Vector3(Random.Range(-2f,2f),Random.Range(-2f,2f),0));
				instantTrail(t,new Vector3(Random.Range(-2f,2f),Random.Range(-2f,2f),0));
				fillAmount -= decayCost;

			}else{
				instantTrail(t);
				fillAmount -= decayCost;
			}
			lastPlacedTrailPos = sponge.transform.position;
		}



		calcFill();

		if(fillAmount < 0){
			GameHandler.GameOver();
		}

	}

	public void calcFill(){
		float curFill = 0;
		float nextFill = 0;

		JointPiece curJoint;
		JointPiece nextJoint = null;

		for(int i = tailLength-1;i>=0;i--){
				//special cases
			curJoint = joints[i].GetComponent<JointPiece>();
			if(i == 0){
				nextFill = fillAmount;
			}else{
				nextJoint = joints[i-1].GetComponent<JointPiece>();
				nextFill = nextJoint.fillAmount;
			}

			if(nextFill < Settings.partFillCapacity){
				//push to next

				//set current
				if(joints[i].tag == "Follower")
					curFill = sponge.amountFilled;
				else
					curFill = curJoint.fillAmount;

				if(curFill + nextFill > Settings.partFillCapacity){
					//if it will result in an overflow
					float overflow =  (nextFill + curFill) % Settings.partFillCapacity;

					//set the next
					if(i == 0)
						fillAmount = Settings.partFillCapacity;
					else
						nextJoint.fillAmount = Settings.partFillCapacity;


					if(joints[i].tag == "Follower")
						sponge.amountFilled = overflow;
					else
						curJoint.fillAmount = overflow;
				}else{
					//set the next
					if(i == 0)
						fillAmount = curFill + nextFill;
					else
						nextJoint.fillAmount = curFill + nextFill;


					if(joints[i].tag == "Follower")
						sponge.amountFilled = 0;
					else
						curJoint.fillAmount = 0;

				}
			}

			if(joints[i].tag == "Follower"){
				sponge.updateColor();
			}else{
				curJoint.updateColor();
			}


		}
		//update head
		updateColor();
	}


	public void updateColor(){

		Color color = spriteRenderer.color;
		color = Color.Lerp(Settings.colorEmpty[changeChannel],Settings.colorFull[changeChannel],fillAmount/Settings.partFillCapacity);
		spriteRenderer.color = color;
	}


	public void hook(JointPiece j){
		joints[tailLength] = j.gameObject;
		j.index = tailLength;
		j.hooked = true;
		j.owner = gameObject;
		joints[tailLength-1].GetComponent<HingeJoint2D>().connectedBody = j.rigidbody2D;

		HingeJoint2D curJoint = j.GetComponent<HingeJoint2D>();
		GameObject g;

		//repopulate array with any parts hanging to it
		int i = tailLength +1;
		for(;i<7;i++){
			g = curJoint.connectedBody.gameObject;
			if(g.tag == "Follower"){
				joints[i] = g;
				break;
			}

			curJoint = g.GetComponent<HingeJoint2D>();

			if(curJoint == null)
				break;

			joints[i] = curJoint.gameObject;
		}
		tailLength = i + 1;

		bool foundFollower = false;
		i = 0;
		for(;i<7;i++){

			if(joints[i] == null){
				Debug.Log(player_name + " : " + i);
				HingeJoint2D hinge = joints[i-1].GetComponent<HingeJoint2D>();

				seeker.transform.position = hinge.transform.position;
				hinge.connectedBody = seeker.rigidbody2D;
				break;
			}else if(joints[i].gameObject.tag == "Follower"){
				foundFollower = true;
				break;
			}
		}
		if(foundFollower)
			seeker.SetActive(false);


	}

	public void breakChain(int index){
		if(index != tailLength-1){
			Debug.Log("break " + index);
			HingeJoint2D j = joints[index].GetComponent<HingeJoint2D>();


			fillAmount -= 15f;

			if(joints[index+1] != null && joints[index+1].tag != "Follower"){
				JointPiece piece = joints[index+1].GetComponent<JointPiece>();
				piece.startCooldown();
			}

			for(int i = index+1;i<tailLength;i++){

				JointPiece piece = joints[i].GetComponent<JointPiece>();
				if(piece != null){
					piece.index = -1;
					piece.playSound();
				}
				joints[i] = null;
			}

			tailLength = index+1;

			cam.startShake(.5f,0.1f);

			seeker.SetActive(true);
			seeker.transform.position = j.transform.position;
			j.connectedBody = seeker.rigidbody2D;

			checkSeeker(j);

		}


	}

	private void checkSeeker(HingeJoint2D j){
		for(int i = 0;i<allBodyParts.Length;i++){
			HingeJoint2D h = allBodyParts[i].GetComponent<HingeJoint2D>();
			if(h.connectedBody == seeker && h != j){
				GameObject g = Instantiate(dummy_prefab,seeker.transform.position,Quaternion.identity) as GameObject;
				h.connectedBody = g.rigidbody2D;
			}
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
		if (other.gameObject.tag == "Joint" ) {
			JointPiece j = other.gameObject.GetComponent<JointPiece>();
			if(j.hooked && j.owner != gameObject && j.index != -1)
				j.owner.GetComponent<playerMovement>().breakChain(j.index);

		}
	}

	//instants a trail on the currentposition
	public void instantTrail(Transform trans,Vector3 offset){
		Vector3 pos = trans.position + offset;
		GameObject g = Instantiate(trail_prefab,pos,Quaternion.identity) as GameObject;
		g.transform.parent = trail_container;
		//sets how long the trail will live
		Trail t = g.GetComponent<Trail>();
		t.setOwner(gameObject);
		t.setDecayLength(trailDecayLength);

	}

	//instants a trail on the currentposition
	public void instantTrail(Transform trans){
		Vector3 pos = trans.position ;
		GameObject g = Instantiate(trail_prefab,pos,Quaternion.identity) as GameObject;
		g.transform.parent = trail_container;
		//sets how long the trail will live
		Trail t = g.GetComponent<Trail>();
		t.setOwner(gameObject);
		t.setDecayLength(trailDecayLength);

	}

}
