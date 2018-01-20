using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour {

	int level;

	// Use this for initialization
	void Start () {
		level = UIManager2.instance.level;
	}



	void OnTriggerExit(Collider col)
	{
		Debug.Log ("----pl-");


			if (col.gameObject.tag == "Player") {

			if (level == 4)
				Invoke ("FallDown", 0.5f);
			else 
				Destroy (transform.gameObject, 1f);

				//Invoke ("FallDown",0.5f);

		}
	}

	void FallDown () {
		
		/*	if ((GameObject.Find ("PlatformSpawner").GetComponent<PlatformSpawner> ().platformCount % 5) == 0) {

			GetComponent<Rigidbody> ().useGravity = true;
			GetComponent<Rigidbody> ().isKinematic = false;
		}*/
		GetComponent<Rigidbody> ().useGravity = true;
		Destroy (transform.gameObject,1f);

	}
}