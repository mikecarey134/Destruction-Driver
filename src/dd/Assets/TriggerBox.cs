using UnityEngine;
using System.Collections;

public class TriggerBox : MonoBehaviour {

	GameObject sp;
	GameObject box;
	// Use this for initialization
	void Start () {
		sp = GameObject.Find ("sp");
	    box = GameObject.Find ("box");
		if (sp == null)
			Debug.LogError ("GameObject sp Not Found!");
		
		box.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Player") {
			box.SetActive (false);
			Fall ();

		}

	}


	public void Fall()
	{
		int chance = Random.Range (1,10);

		if (chance >= 7) {
			
			box.transform.position = sp.transform.position;
			box.SetActive (true);

			Debug.Log ("Box Fell Chance:" + chance);
		}



	}
}
