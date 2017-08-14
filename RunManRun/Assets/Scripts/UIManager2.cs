using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager2 : MonoBehaviour {

	public static UIManager2 instance;

	public GameObject ZigZagPanel;
	public GameObject gameOverPanel;
	public GameObject scorePanelTop;
	public GameObject btnStart;
	public GameObject bg1,bg2,bg3;

	public Text score;
	public Text highScore1;
	public Text highScore2;
	public Text scoreTextTop;
	public GameObject userGuidanceText;

	bool isMute;

	void Awake () {
		if (instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {

		bg1.SetActive (false);
		bg2.SetActive (false);
		bg3.SetActive (false);


		int rand= Random.Range (0, 3);

		if (rand == 0) {
			bg1.SetActive (true);	
			destroyBg2 ();
			destroyBg3 ();
		}
		else if(rand == 1)
		{
			bg2.SetActive (true);
			destroyBg1 ();
			destroyBg3 ();
		}
		else
		{
			bg3.SetActive (true);
			destroyBg1 ();
			destroyBg2 ();
		}



		highScore1.text = "Best Score: "+PlayerPrefs.GetInt ("highScore");
		resetVars ();
	}

	void destroyBg1()
	{

		foreach (Transform child in bg1.transform) {
			GameObject.DestroyImmediate(child.gameObject);
		}
	}
	void destroyBg2()
	{

		foreach (Transform child in bg2.transform) {
			GameObject.DestroyImmediate(child.gameObject);
		}
	}
	void destroyBg3()
	{

		foreach (Transform child in bg3.transform) {
			GameObject.DestroyImmediate(child.gameObject);
		}
	}


	void resetVars()
	{
		isMute = false;
	}

	public void GameStart () {

		btnStart.SetActive (false);
		userGuidanceText.SetActive (false);
		ZigZagPanel.GetComponent<Animator> ().Play ("MoveUp");
		scorePanelTop.SetActive (true);

	}

	public void updateScore()
	{
		scoreTextTop.text = "SCORE: "+ScoreManager2.instance.score;
	}


	public void GameOver () {
		score.text = PlayerPrefs.GetInt ("score").ToString();
		highScore2.text = PlayerPrefs.GetInt ("highScore").ToString();;
		scorePanelTop.SetActive (false);
		gameOverPanel.SetActive (true);
		ZigZagPanel.GetComponent<Animator> ().Play ("GameOverPanelAnimation");

	}


	public void Reset () {
		SceneManager.LoadScene (0);
		resetVars ();
	}

	public void Mute () {
		isMute =!isMute;
		AudioListener.volume = isMute ? 0 : 1;


	}



	// Update is called once per frame
	void Update () {

	}


}
