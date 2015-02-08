using UnityEngine;
using System.Collections;

public static class Settings{

	//------|  Player  |------\\
		public static float playerHealth = 10f;

		public static float playerSpeed = 10f;

		public static float playerRotSpeed = 30f;
		public static float playerMaxRotSpeed = 350f;

		public static float playerDashSpeed = 150f;

		public static float playerOnEnemyTrailSpeed = 7f;
		public static float playerOnEnemyTrailSpeedLength = .5f;

		public static float playerOnFriendlyTrailSpeed = 15f;
		public static float playerOnFriendlyTrailSpeedLength = 1f;

		public static float drainSpeedPerTrail = .1f;
		public static float drainSpeedPerDashTrail = 1.3f;

		public static Color[] colorFull = {new Color(1f,0f,0f,1f),new Color(0f,0f,1f,1f)};
		public static Color[] colorEmpty = {new Color(.2f,0f,0f,1f),new Color(0f,0f,0.2f,1f)};

		public static float playerMass = 20f;


	//------|  Tail/Sponge/Follower  |------\\
		public static int followSpeed = 20;
		public static int chainLength = 2;

		public static float partFillCapacity = 30f;


	//------|  Trail  |------\\
		public static float decayLength = 2f;
		public static float decayDistance = 1f;

		public static float jointCooldownLength = 1f;

	//------|  Refiller  |------\\

		public static float refillSpeed = 5f;

	//------|  Camera  |------\\
		public static float shakeAmt = 0.5f;
		public static float shakeDuration = 2f;

	//------|  Wall  |------\\
		public static float wallPushForce = 90f;

}
