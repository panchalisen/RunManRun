using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerExit(Collider col)
	{


		if(col.gameObject.tag=="Player")
		{
			Destroy (transform.gameObject,1f);

			//Invoke ("FallDown",0.5f);
		}
	}

	/*void FallDown () {
		
		if ((GameObject.Find ("PlatformSpawner").GetComponent<PlatformSpawner> ().platformCount % 5) == 0) {

			GetComponent<Rigidbody> ().useGravity = true;
			GetComponent<Rigidbody> ().isKinematic = false;
		}
		Destroy (transform.gameObject,2f);

	}*/
}