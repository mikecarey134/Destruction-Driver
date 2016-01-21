using UnityEngine;
using System.Collections;

public class PlayerBot : MonoBehaviour {

	private Vector3 velocity = Vector3.zero;
	//public Vector3 gravity;
	//public Vector3 jetVelocity;
	//public float max_speed = 5.0f;

	float jet_speed = 100f;
	float forward_speed = 1.0f;


	public bool god=false;
	bool isJet = false;
	bool isDead = false;
	private AudioSource thrust;
	private AudioSource explode;
	private Animator anim;
	float death_cooldown;


	// Use this for initialization
	void Start () {
		//get the component from the player game object in order to use the sound
		thrust = GameObject.FindGameObjectWithTag ("Thrust").GetComponent<AudioSource> ();
		explode = GameObject.FindGameObjectWithTag ("Explode").GetComponent<AudioSource> ();
		anim = GetComponentInChildren<Animator> ();



	}

	// Update is called once per frame
	void Update(){


		if (isDead) {
			death_cooldown -= Time.deltaTime;
			if(death_cooldown<=0)
			{
				if(Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButtonDown(0))
				{
					Application.LoadLevel(Application.loadedLevel);
				}
			}	
		
		}
		anim.SetBool("isJet",false);

		if(Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButtonDown(0))
		{
			isJet = true;
			thrust.Play();//play thrust sound
			anim.SetBool("isJet",true);
		}
	
	
	}

	//Do psysics engine updates here
	void FixedUpdate () {

		GetComponent<Rigidbody2D> ().AddForce (Vector2.right * forward_speed);

		if (isJet) {

			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jet_speed);

			isJet = false;

		}

		/*if (GetComponent<Rigidbody2D> ().velocity.y < 0) {
			float angle = Mathf.Lerp(0,-90, -GetComponent<Rigidbody2D> ().velocity.y/2f);
			transform.rotation = Quaternion.Euler(0,0,angle);

		}*/


		/*velocity.x = forward_speed;//setup the speed at which the bot travels across the screen
		velocity += gravity *Time.deltaTime;

		if (isJet) {
			isJet = false;
			if(velocity.y <0)
			{
				velocity.y = 0;
			}
			velocity += jetVelocity;
		}
		velocity = Vector3.ClampMagnitude(velocity,max_speed);

		//rigidbody2D.AddForce (velocity);
		//transform.position += velocity * Time.deltaTime;

		//after a jet make the bot go into a downward angle
		float angle = 0;
		if(velocity.y <0)
		{
			angle = Mathf.Lerp (0, -90,-velocity.y /max_speed);
		}

		transform.rotation = Quaternion.Euler (0, 0, angle);*/	
	}



	void OnCollisionEnter2D(Collision2D collision)
	{
		if (god)
			return;

		anim.SetBool ("death", true);
		if (!isDead) {
			explode.Play ();
		}
		isDead = true;

	}

}
