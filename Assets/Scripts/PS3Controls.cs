using UnityEngine;
using System.Collections;

public class PS3Controls : MonoBehaviour {

	void Update () {
		int left = 0; //off
		int right = 0; //off
		if (Input.GetKey (KeyCode.A)) {
			left = 300; //amount of vibration
		}
		if (Input.GetKey (KeyCode.B)) {
			right = 300;//amount of vibration
		}
		XInputDotNetPure.GamePad.SetVibration (0, left, right);

	}

}
