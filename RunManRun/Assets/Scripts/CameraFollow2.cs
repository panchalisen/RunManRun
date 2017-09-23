using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour {

	[SerializeField]
	Transform player;
	Vector3 offset;
	[HideInInspector] public bool gameOrLevelOver;

	[SerializeField]
	float smoothRate;


	// Use this for initialization
	void Start () {
		offset = player.position - transform.position;
		gameOrLevelOver = false;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (!gameOrLevelOver) {
			Follow ();
		}

	}

	void Follow()
	{

		Vector3 pos = transform.position;
		Vector3 targetPos = player.position - offset;

		transform.position=Vector3.Lerp (pos,targetPos,smoothRate);
	}
}
