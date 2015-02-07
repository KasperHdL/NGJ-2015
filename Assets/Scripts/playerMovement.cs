using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerMovement : MonoBehaviour {

	//used to refer to input keys
	public string player_name;

	public static int health = 50;

	public Slider slider;

	public static float rotationSpeed = 5;
	public static float speed = 5;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//player movement
		float hori = Input.GetAxis(name + "_hori");
		transform.Rotate (hori * rotationSpeed, 0, 0);

		rigidbody2D.velocity = transform.forward * speed;
		slider.value = health;

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
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Wall"){
			transform.Rotate(0,180,0);
		}
	}
}