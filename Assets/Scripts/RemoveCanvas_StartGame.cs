using UnityEngine;
using System.Collections;

public class RemoveCanvas_StartGame : MonoBehaviour {
	
	public void StartGame(){
		if(Input.GetKey (KeyCode.Space)){
				gameObject.SetActive (false); //deleting
		}
}
}
