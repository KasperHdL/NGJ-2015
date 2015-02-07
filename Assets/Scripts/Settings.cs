using UnityEngine;
using System.Collections;

public static class Settings{

	//------|  Player  |------\\
		public static float playerHealth = 10;

		public static float playerSpeed = 10;
		public static float playerRotSpeed = 10;

		public static float slowedPlayerSpeed = 5;
		public static float slowedPlayerRotSpeed = 5;

		public static float drainSpeedPerTrail = 1f;

	//------|  Tail/Sponge/Follower  |------\\
		public static int followSpeed = 20;
		public static int chainLength = 2;

		public static float spongeCapacity = 100;


	//------|  Trail  |------\\
		public static float decayLength = 2f;
		public static float decayDistance = 1f;

		public static float slowLength = 1f;


	//------|  Refiller  |------\\

		public static float refillSpeed = 10f;

	//------|    |------\\

}
