using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown : MonoBehaviour {


	void OnTriggerEnter(Collider col)
	{
		

	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "Player") {
			//Debug.Log ("----pl-");

				Invoke ("FallDown1", 0.3f);

			
		}
	}

	void FallDown1 () {

		GetComponentInParent<Rigidbody> ().useGravity = true;
		GetComponentInParent<Rigidbody> ().isKinematic = false;
		Destroy (transform.gameObject,1f);

	}
}
