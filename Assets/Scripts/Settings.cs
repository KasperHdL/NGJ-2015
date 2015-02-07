using UnityEngine;
using System.Collections;

public static class Settings{

	//------|  Player  |------\\
		public static float playerHealth = 10f;

		public static float playerSpeed = 10f;
		public static float playerDashSpeed = 15f;
		public static float playerRotSpeed = 100f;

		public static float playerOnEnemyTrailSpeed = 5f;
		public static float playerOnEnemyTrailSpeedLength = 1f;

		public static float playerOnFriendlyTrailSpeed = 15f;
		public static float playerOnFriendlyTrailSpeedLength = 1f;

		public static float drainSpeedPerTrail = 1f;
		public static float drainSpeedPerDashTrail = 1.5f;

	//------|  Tail/Sponge/Follower  |------\\
		public static int followSpeed = 20;
		public static int chainLength = 2;

		public static float spongeCapacity = 100;


	//------|  Trail  |------\\
		public static float decayLength = 2f;
		public static float decayDistance = .7f;



	//------|  Refiller  |------\\

		public static float refillSpeed = 5f;

	//------|    |------\\

}
