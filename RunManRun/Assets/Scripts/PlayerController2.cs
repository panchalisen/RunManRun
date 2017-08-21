using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour {

	Rigidbody rb;
	Animator anim;
 float speed;


	bool started;
	Vector3 target_point;
	Vector3 currentLoc;
	//Vector3 prevLoc;
	//bool gameOver;
	public AudioManager2 am;
	int level;
	void Awake()
	{
		rb = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {


		level = UIManager2.instance.level;
		//speed = 9f;
		started = false;

		switch (level) {
		case 1:
			speed = 10f;
			break;

		case 2:
			speed = 11f;
			break;

		case 3:
			speed = 12f;
			break;

		case 4:
			speed = 13f;
			break;
		}


		//rb.velocity = Vector3.forward * speed;
		if (am.bgMusic.isPlaying) {
			am.bgMusic.Stop();
		}
	
			
	}


	//Vector3 moveDirection;




	// Update is called once per frame
	void Update () {

	//	moveDirection = Vector3.zero;
		//prevLoc = transform.position;



		if (!Physics.Raycast (transform.position, Vector3.down, 1f)) {
			//gameOver = true;
			rb.velocity = new Vector3 (0, -25f, 0);
			Camera.main.GetComponent <CameraFollow2> ().gameOver = true;	
			GameManager2.instance.LevelCompleteFail();
			am.bgMusic.Stop ();
		}




		//if ((GameObject.Find ("PlatformSpawner").GetComponent<PlatformSpawner2> ().platformCount % 10) == 0) {
			//speed += 0.025f;
		//}


				if (Input.GetMouseButtonDown (0)) {



			if (!started) {
				am.bgMusic.Play();
				anim.SetTrigger ("goRun");
				rb.velocity = new Vector3 (0,0,speed);
				//rb.velocity = Vector3.forward * speed;	
				started = true;
				Debug.Log ("level- "+level+";speed- "+speed);
				GameManager2.instance.GameStart ();
			} 
			else {
				//ScoreManager.instance.incrementScore ();
				UIManager2.instance.updateScore ();
				SwitchDirection ();
			}

		}




	}

	void SwitchDirection () {


		if (rb.velocity.z > 0) {
			rb.velocity = new Vector3 (speed, 0,0);	
			transform.rotation = Quaternion.LookRotation(rb.velocity);
		}
		else if (rb.velocity.x > 0) {
			rb.velocity = new Vector3 (0,0,speed);	
			transform.rotation = Quaternion.LookRotation(rb.velocity);
		}
	}

	void OnTriggerEnter (Collider col) {

		if (col.gameObject.tag == "EB1") {

			am.audioCollision1.Play ();
			Destroy (col.gameObject);
			ScoreManager2.instance.incrementScoreEnergyBall1 ();


		}
		if (col.gameObject.tag == "EB2") {

			am.audioCollision2.Play ();
			Destroy (col.gameObject);
			ScoreManager2.instance.incrementScoreEnergyBall2 ();


		}
		if (col.gameObject.tag == "EB3") {

			am.audioCollision3.Play ();
			Destroy (col.gameObject);
			ScoreManager2.instance.incrementScoreEnergyBall3 ();


		}
		if (col.gameObject.tag == "PLATFORMEND") {

			anim.SetTrigger ("goRun");
			rb.velocity = new Vector3 (0,0,0);


			if (level < 4) {
				GameManager2.instance.LevelCompleteSuccess ();//*stiill problem if u remove this line
			} else if (level == 4) {
				GameManager2.instance.GameOver ();
			}
				

		}
		UIManager2.instance.updateScore ();
	}


}







