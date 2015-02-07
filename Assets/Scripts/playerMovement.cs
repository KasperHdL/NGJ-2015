using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public string name;

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
				if (Input.GetKey (KeyCode.A)) {
			transform.Rotate (-rotationSpeed, 0, 0);
						Debug.Log (transform.rotation.y);
				}
				if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (rotationSpeed, 0, 0);
						Debug.Log (transform.rotation.y);
				}
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
		void OnTriggerEnter(Collider other){
				if (other.gameObject.tag == "Wall") {
						transform.Rotate (0, 180, 0);
			OnJointBreak();
				}
		}

	void OnJointBreak() {
		}
		}
=======
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Wall"){
			transform.Rotate(0,180,0);
		}
	}
}
>>>>>>> ac8f9c31bc499c7e6fc4302b8edd1e1e35f62774
