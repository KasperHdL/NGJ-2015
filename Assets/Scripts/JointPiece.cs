using UnityEngine;
using System.Collections;

public class JointPiece : MonoBehaviour {

	public GameObject owner;
	public int index;

	public bool hooked = true;

	//part fill

	public float fillAmount;
	public SpriteRenderer spriteRenderer;
	public int changeChannel;



	//joint lock
	public bool jointOnCooldown = false;
	private float jointCooldownEnd;
	private float jointCooldownLength;


	// Use this for initialization
	void Start () {
		fillAmount = Settings.partFillCapacity;
		jointCooldownLength = Settings.jointCooldownLength;
	}

	void Update(){
		if(jointOnCooldown && jointCooldownEnd < Time.time){
			hooked = false;
			jointOnCooldown = false;
		}
	}

	public void startCooldown(){
		hooked = true;
		jointOnCooldown = true;
		jointCooldownEnd = Time.time + jointCooldownLength;
	}



	public void updateColor(){
		Color color = spriteRenderer.color;
		color = Color.Lerp(Settings.colorEmpty[changeChannel],Settings.colorFull[changeChannel],fillAmount/Settings.partFillCapacity);
		spriteRenderer.color = color;
	}

	public void playSound()          //function for playing a sound from the sound array
	{

		audio.Play ();

	}
}
