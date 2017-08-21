using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour {

	public static GameManager2 instance;
	public bool gameOver;


	void Awake () {
		if (instance == null) {
			instance = this;
		}
	}
	// Use this for initialization
	void Start () {
		gameOver = false;
	}

	// Update is called once per frame
	void Update () {

	}

	public void GameStart () {

		UIManager2.instance.GameStart ();

		GameObject.Find ("PlatformSpawner").GetComponent<PlatformSpawner2>().startSpawning();
	}

	public void LevelCompleteSuccess() {
		ScoreManager2.instance.stopScore ();
		UIManager2.instance.loadNextLevel ();
	}

	public void LevelCompleteFail() {
		UIManager2.instance.LevelOverFaliure ();

	}


	public void GameOver () {
		UIManager2.instance.GameOver ();
		ScoreManager2.instance.stopScore ();
		gameOver = true;
	}


}
