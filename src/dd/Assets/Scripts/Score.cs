using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	static int score = 0;
	static int high_score = 0;
	Text text;
	Text hs_text;

	static public void AddPoint(){
		++score;

		if (score > high_score) {
			high_score = score;
		}

	}
	// Use this for initialization
	void Start () {
		score = 0;
		text = GameObject.FindGameObjectWithTag ("Score").GetComponentInChildren<Text> ();
		hs_text = GameObject.FindGameObjectWithTag ("HighScore").GetComponentInChildren<Text> ();


		high_score = PlayerPrefs.GetInt ("HighScore",0);

	}
	
	// Update is called once per frame
	void Update () {
		if (text == null)
			return;

		text.text = "[Score:" + score + "]";
		hs_text.text = "[High Score:"+ high_score + "]";
	}

	void OnDestroy(){
		PlayerPrefs.SetInt ("HighScore", high_score);
	}


}
