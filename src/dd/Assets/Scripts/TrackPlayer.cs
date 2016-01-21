using UnityEngine;
using System.Collections;

public class TrackPlayer : MonoBehaviour {

	public Transform player;
	public float ofsetX;
	// Use this for initialization
	void Start () {
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");

		if (player_go == null) {
			Debug.LogError("Player Tag Not Found!!!");
			return;
		}
		player = player_go.transform;
		ofsetX = transform.position.x - player.position.x;
	}
	
	// Update is called once per frame
	void Update () {

		if (player != null) {
			Vector3 pos = transform.position;
			pos.x = player.position.x +ofsetX;
			transform.position = pos;

		}
	}
}
