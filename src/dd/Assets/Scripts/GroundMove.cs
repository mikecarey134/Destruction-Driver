using UnityEngine;
using System.Collections;

public class GroundMove : MonoBehaviour {

	// Use this for initialization

	Rigidbody2D player;

	void Start () {
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		
		if (player_go == null) {
			Debug.LogError("Player Tag Not Found!!!");
			return;
		}
		player = player_go.GetComponent<Rigidbody2D> ();
	
	}

	float speed = 0.8f;

	// Update is called once per frame
	void FixedUpdate () {
		/*
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;*/
		float velocity = player.velocity.x * 0.6f;
		transform.position = transform.position + Vector3.right * velocity * Time.deltaTime;

	}
}
