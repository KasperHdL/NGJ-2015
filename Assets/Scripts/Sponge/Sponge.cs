using UnityEngine;
using System.Collections;

public class Sponge : MonoBehaviour {
	//references
	public GameObject owner;

	public float amountFilled;
	public SpriteRenderer spriteRenderer;
	public int changeChannel;


	// Use this for initialization
	void Start () {
		amountFilled = Settings.partFillCapacity;
	}


	public void updateColor(){
		Color color = spriteRenderer.color;
		color = Color.Lerp(Settings.colorEmpty[changeChannel],Settings.colorFull[changeChannel],amountFilled/Settings.partFillCapacity);
		spriteRenderer.color = color;
	}

}
