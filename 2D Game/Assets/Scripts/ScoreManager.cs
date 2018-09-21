using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

		public static int Score;
	

		Text ScoreText1;

		// Use this for initialization
		void Start () {
			ScoreText1 = GetComponent<Text>();

			Score = 0
		}

		void Update () {
			if (Score < 0)
				Score = 0;

			ScoreText1.text = " " + Score;
		}
		
	}
}
