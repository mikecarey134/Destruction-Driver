using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

	float data_max_height = 0.49f;
	float data_min_height = -2.1f;


	void Start(){
		GameObject[] obstacles = GameObject.FindGameObjectsWithTag ("Obstacle");

		foreach (GameObject obstacle in obstacles) {
		
			Vector3 pos = obstacle.transform.position;
			pos.y = Random.Range(data_min_height,data_max_height);
			obstacle.transform.position = pos;
		} 
	
	
	}


	void OnTriggerEnter2D(Collider2D collider)
	{	
	
		float multiplier = 13.5f;

		//Debug.Log ("Triggered" + collider.name);

		float widthX =((BoxCollider2D)collider).size.x;

		Vector3 pos = collider.transform.position;

		pos.x += widthX * multiplier ;

		if (collider.tag == "Obstacle") {

			pos.y = Random.Range(data_min_height,data_max_height);
		
		}
		collider.transform.position = pos;


	}
}
