using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager2 : MonoBehaviour {

	public static UIManager2 instance;

	public GameObject ZigZagPanel;
	public GameObject gameOverPanel;
	//public GameObject scorePanelTop1;
	public GameObject rewardedVideoPanel;
	public GameObject confirmationPanel;
	public GameObject gameCompletePanel;

	public GameObject btnStart;
	public GameObject btnViewRewardedVideo;
	//public GameObject btnAdLabel;
	public GameObject btnMute;
	//public GameObject bg1,bg2,bg3;
	public Sprite SoundOn;
	public Sprite SoundOff;

	public Text pnlStartScore;
	public Text pnlRestartScore;
	public Text pnlRestartBestScore;
	public Text scoreTextTop;
	public GameObject userGuidanceText;

	bool isMute;
	public int level;
	string initText;
	void Awake () {
		if (instance == null) {
			instance = this;

			//Debug.Log("Awake...current level ="+level); //awake always called on level reload
		}
	}

	// Use this for initialization
	void Start () {

		//Debug.Log ("isMute: " + isMute);
		if (!PlayerPrefs.HasKey ("BESTSCORE")) {
			initText = "BEST SCORE: 0";
		} else {

			//if(PlayerPrefs.GetInt ("SCORE")>0)
				//initText = "SCORE: "+PlayerPrefs.GetInt ("SCORE");
			//else
				initText = "BEST SCORE: "+PlayerPrefs.GetInt ("BESTSCORE");
		}

		if (level == 1) {
			//pnlStartScore.text = "BEST SCORE: " + 	PlayerPrefs.GetInt ("BESTSCORE");
			pnlStartScore.text = initText;
		} else {
			pnlStartScore.text = "SCORE: "		+	PlayerPrefs.GetInt ("SCORE");

		}
	rewardedVideoPanel.SetActive (false);
		confirmationPanel.SetActive (false);
		UnityAdManager.instance.SetAdAdBtnLabels (level);
		resetVars ();
	}



	void resetVars()
	{
		
		isMute = false;

	}

	public void GameStart () {
		UnityAdManager.instance.SetAdAdBtnLabels (level);
		btnStart.SetActive (false);
		btnMute.SetActive (false);
		userGuidanceText.SetActive (false);
		ZigZagPanel.GetComponent<Animator> ().Play ("MoveUp");
		//scorePanelTop.SetActive (true);
		rewardedVideoPanel.SetActive (false);	
		confirmationPanel.SetActive (false);

	}


	public void updateScore1()
	{
		scoreTextTop.text = "SCORE: "+ScoreManager2.instance.score;
	}


	public void ShowConfirmationPanel (string message) {
		//rewardedVideoPanel.SetActive (false);	
		confirmationPanel.SetActive (true);
		confirmationPanel.GetComponentInChildren<Text> ().text = message;

	}

	public void HideConfirmationPanel (string message) {


	}



	public void LevelOverFaliure () {
		pnlRestartScore.text = PlayerPrefs.GetInt ("SCORE").ToString();
		pnlRestartBestScore.text = PlayerPrefs.GetInt ("BESTSCORE").ToString();;
		//scorePanelTop.SetActive (false);
		gameOverPanel.SetActive (true);

		//Debug.Log ("LEVEL_FAILED_COUNT-"+PlayerPrefs.GetInt ("LEVEL_FAILED_COUNT"));


		if (UnityAdManager.instance.ShowRewardedVideoPanel ()) {
			rewardedVideoPanel.SetActive (true);

			Text labelAd =rewardedVideoPanel.GetComponentInChildren<Text>();
			labelAd.text = UnityAdManager.instance.GetAdText ();
		}

	}

	public void ShowRewardedVideoOnClick () {
		//Debug.Log ("ShowRewardedVideoOnClick UIManager");
		UnityAdManager.instance.ShowRewardedVideoAd ();
	}

	public void GameComplete () {
		
		Text[] gameOver =gameCompletePanel.GetComponentsInChildren<Text>();
		gameOver[5].text = PlayerPrefs.GetInt ("BESTSCORE").ToString();;
		gameOver[3].text = PlayerPrefs.GetInt ("SCORE").ToString();


		//scorePanelTop.SetActive (false);
		rewardedVideoPanel.SetActive (false);	
		confirmationPanel.SetActive (false);
		gameCompletePanel.SetActive (true);
	}

		public void GameOver () {

		pnlRestartScore.text = PlayerPrefs.GetInt ("SCORE").ToString();
		pnlRestartBestScore.text = PlayerPrefs.GetInt ("BESTSCORE").ToString();;
		//scorePanelTop.SetActive (false);
		gameOverPanel.SetActive (true);
//		ZigZagPanel.GetComponent<Animator> ().Play ("GameOverPanelAnimation");

	}


	public void Reset () {
		
		resetVars ();
		SceneManager.LoadScene (level-1);

	}




	public void Mute () {
	//	Debug.Log ("mute button clicked");
		isMute =!isMute;
		AudioListener.volume = isMute ? 0 : 1;
		btnMute.GetComponent<Image> ().sprite = isMute ? SoundOff : SoundOn;
		Debug.Log ("-isMute: " + isMute);
		/*if (isMute)
			btnMute.GetComponent<Image> ().sprite = SoundOff;
		else
			btnMute .GetComponent<Image> ().sprite = SoundOn;*/
		
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

	public void QuitGame()
	{
		Application.Quit();
	}
}
