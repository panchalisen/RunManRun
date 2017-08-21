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
	//public GameObject bg1,bg2,bg3;


	public Text pnlStartScore;
	public Text pnlRestartScore;
	public Text pnlRestartBestScore;
	public Text scoreTextTop;
	public GameObject userGuidanceText;

	bool isMute;
	public int level;

	void Awake () {
		if (instance == null) {
			instance = this;
			//Debug.Log("Awake...current level ="+level);
		}
	}

	// Use this for initialization
	void Start () {
		if (level == 1) {
			pnlStartScore.text = "BEST SCORE: " + 	PlayerPrefs.GetInt ("BESTSCORE");
		} else {
			pnlStartScore.text = "SCORE: "		+	PlayerPrefs.GetInt ("SCORE");

		}
			

		resetVars ();
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


	public void LevelOverFaliure () {
		pnlRestartScore.text = PlayerPrefs.GetInt ("SCORE").ToString();
		pnlRestartBestScore.text = PlayerPrefs.GetInt ("BESTSCORE").ToString();;
		scorePanelTop.SetActive (false);
		gameOverPanel.SetActive (true);
	}


		public void GameOver () {

		pnlRestartScore.text = PlayerPrefs.GetInt ("SCORE").ToString();
		pnlRestartBestScore.text = PlayerPrefs.GetInt ("BESTSCORE").ToString();;
		scorePanelTop.SetActive (false);
		gameOverPanel.SetActive (true);
//		ZigZagPanel.GetComponent<Animator> ().Play ("GameOverPanelAnimation");

	}


	public void Reset () {
		resetVars ();
		SceneManager.LoadScene (level-1);

	}




	public void Mute () {
		isMute =!isMute;
		AudioListener.volume = isMute ? 0 : 1;


	}
	public void loadNextLevel()
	{
//		Debug.Log("loadNextLevel...current level ="+level);

		if (level < 4) {
			SceneManager.LoadScene (level);
		}

	}


	// Update is called once per frame
	void Update () {

	}


}
