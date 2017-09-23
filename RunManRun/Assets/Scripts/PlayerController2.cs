using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController2 : MonoBehaviour {

	Rigidbody rb;
	Animator anim;
 	public float speed;
	bool started;
	Vector3 target_point;
	Vector3 currentLoc;
	//Vector3 prevLoc;
	//bool gameOver;
	public AudioManager2 am;
	int level;
	//public int levelFailedCount;

	public GameObject particle1;
	public GameObject particle2;
	public GameObject particle3;
	public GameObject particle4;

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
	public void DecreaseSpeed()
	{
		speed -= 2f;
	}



	// Update is called once per frame
	void Update () {



		if (Application.platform == RuntimePlatform.Android) {


			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {

				int pointerId = Input.GetTouch (0).fingerId;


				if (!started) {

					if (!EventSystem.current.IsPointerOverGameObject(pointerId)) {
						//Debug.Log ("click NOT on button");
						am.bgMusic.Play ();
						anim.SetTrigger ("goRun");
						rb.velocity = new Vector3 (0, 0, speed);
						started = true;
						//Debug.Log ("level- "+level+";speed- "+speed);
						GameManager2.instance.GameStart ();
					} else {
						//Debug.Log ("click on button");
					}

				} else {
					//ScoreManager.instance.incrementScore ();
					//UIManager2.instance.updateScore ();
					SwitchDirection ();
				}

			}

		} else {


			if (Input.GetMouseButtonDown (0)) {



				if (!started) {
					

					if (!EventSystem.current.IsPointerOverGameObject()) {
						
						am.bgMusic.Play ();
						anim.SetTrigger ("goRun");
						rb.velocity = new Vector3 (0, 0, speed);
						started = true;
						//Debug.Log ("level- "+level+";speed- "+speed);
						GameManager2.instance.GameStart ();
					} else {
						//Debug.Log ("click on button");
					}

				} else {
					

					//ScoreManager.instance.incrementScore ();
					//*******UIManager2.instance.updateScore ();
					SwitchDirection ();
				}

			}


		}
	



		if (started) {

			if (!Physics.Raycast (transform.position, Vector3.down, 1f)&&(!Camera.main.GetComponent <CameraFollow2> ().gameOrLevelOver)) {
				
				//gameOver = true;
				rb.velocity = new Vector3 (0, -25f, 0);
				Camera.main.GetComponent <CameraFollow2> ().gameOrLevelOver = true;	

				am.bgMusic.Stop ();
				started = false;
				//levelFailedCount += 1;
				GameManager2.instance.LevelCompleteFail ();
				//level failed count
				return;
			}

		}





			//if ((GameObject.Find ("PlatformSpawner").GetComponent<PlatformSpawner2> ().platformCount % 10) == 0) {
			//speed += 0.025f;
			//}


			

	


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
			GameObject part = Instantiate (particle1,col.gameObject.transform.position,Quaternion.identity) as GameObject;
			Destroy (col.gameObject);
			Destroy (part, 1f);
			ScoreManager2.instance.incrementScoreEnergyBall1 ();


		}
		else if (col.gameObject.tag == "EB2") {

			am.audioCollision2.Play ();
			GameObject part = Instantiate (particle2,col.gameObject.transform.position,Quaternion.identity) as GameObject;
			Destroy (col.gameObject);
			Destroy (part, 1f);
			ScoreManager2.instance.incrementScoreEnergyBall2 ();


		}
		else if (col.gameObject.tag == "EB3") {

			am.audioCollision3.Play ();
			GameObject part = Instantiate (particle3,col.gameObject.transform.position,Quaternion.identity) as GameObject;
			Destroy (col.gameObject);
			Destroy (part, 1f);
			ScoreManager2.instance.incrementScoreEnergyBall3 ();


		}
		else if (col.gameObject.tag == "EB4") {

			am.audioCollision2.Play ();
			GameObject part = Instantiate (particle4,col.gameObject.transform.position,Quaternion.identity) as GameObject;
			Destroy (col.gameObject);
			Destroy (part, 1f);
			ScoreManager2.instance.incrementScoreEnergyBall4 ();


		}
		else if (col.gameObject.tag == "PLATFORMEND") {

			anim.SetTrigger ("goRun");
			rb.velocity = new Vector3 (0,0,0);


			if (level < 4) {
				GameManager2.instance.LevelCompleteSuccess ();//*stiill problem if u remove this line
			} else if (level == 4) {
				GameManager2.instance.GameComplete ();
			}
				

		}


		//******UIManager2.instance.updateScore ();
	}


}







