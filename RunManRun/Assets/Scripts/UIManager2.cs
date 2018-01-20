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
	public GameObject pnlBottom;
	public GameObject helpPanel;
	public GameObject exitPanel;

//	public GameObject btnStart;
	public GameObject btnViewRewardedVideo;
	//public GameObject btnAdLabel;
	public GameObject btnMute;
	public GameObject btnHelp;
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
		isMute = UnityAdManager.instance.isMute;
		AudioListener.pause = isMute;
		btnMute.GetComponent<Image> ().sprite = isMute ? SoundOff : SoundOn;

		Debug.Log ("START->isMute: " + isMute+"->UnityAdManager: " + UnityAdManager.instance.isMute+"->AudioListener: " + AudioListener.pause);


		if (!PlayerPrefs.HasKey ("SCORE")) {
			initText = "SCORE: 0";
		} else {
			//Debug.Log ("PlayerPrefs.GetInt (SCORE): " + PlayerPrefs.GetInt ("SCORE"));
				initText = "SCORE: "+PlayerPrefs.GetInt ("SCORE");
		}

		/*if (level == 1) {
			//pnlStartScore.text = "BEST SCORE: " + 	PlayerPrefs.GetInt ("BESTSCORE");
			pnlStartScore.text = initText;
		} else {
			pnlStartScore.text = "SCORE: "		+	PlayerPrefs.GetInt ("SCORE");

		}*/

		pnlStartScore.text = initText;
		rewardedVideoPanel.SetActive (false);
		confirmationPanel.SetActive (false);
		helpPanel.SetActive (false);
		//pnlBottom.SetActive (false);
		UnityAdManager.instance.SetAdAdBtnLabels (level);

	}




	public void GameStart () {
		UnityAdManager.instance.SetAdAdBtnLabels (level);
		btnMute.SetActive(false);
		btnHelp.SetActive (false);
		userGuidanceText.SetActive (false);
		ZigZagPanel.GetComponent<Animator> ().Play ("MoveUp");
		//scorePanelTop.SetActive (true);
		rewardedVideoPanel.SetActive (false);	
		confirmationPanel.SetActive (false);
		//pnlBottom.SetActive (true);

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


	public void ShowHelpPanel () {
		helpPanel.SetActive (true);

	}

	public void HideHelpPanel () {
		helpPanel.SetActive (false);

	}



	public void LevelOverFaliure () {
		pnlRestartScore.text = PlayerPrefs.GetInt ("SCORE").ToString();
		pnlRestartBestScore.text = PlayerPrefs.GetInt ("BESTSCORE").ToString();;
		//scorePanelTop.SetActive (false);
		gameOverPanel.SetActive (true);
		//pnlBottom.SetActive (false);

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

	/*public void GameComplete () {
		
		Text[] gameOver =gameCompletePanel.GetComponentsInChildren<Text>();
		gameOver[5].text = PlayerPrefs.GetInt ("BESTSCORE").ToString();;
		gameOver[3].text = PlayerPrefs.GetInt ("SCORE").ToString();


		//scorePanelTop.SetActive (false);
		rewardedVideoPanel.SetActive (false);	
		confirmationPanel.SetActive (false);
		gameCompletePanel.SetActive (true);
	}*/




		public void GameOver () {

		pnlRestartScore.text = PlayerPrefs.GetInt ("SCORE").ToString();
		pnlRestartBestScore.text = PlayerPrefs.GetInt ("BESTSCORE").ToString();;
		//scorePanelTop.SetActive (false);
		gameOverPanel.SetActive (true);
		//pnlBottom.SetActive (false);
//		ZigZagPanel.GetComponent<Animator> ().Play ("GameOverPanelAnimation");

	}


	public void HideExitDialog () {

		exitPanel.SetActive (false);

	}


	public void ShowExitDialog () {

		exitPanel.SetActive (true);
	}


	public void Reset () {
		

		SceneManager.LoadScene (level);

	}



	public void Mute () {
	//	Debug.Log ("mute button clicked");
		isMute =!isMute;
		//AudioListener.volume = isMute ? 0 : 1;

		AudioListener.pause=isMute;
		UnityAdManager.instance.isMute = isMute;
		btnMute.GetComponent<Image> ().sprite = isMute ? SoundOff : SoundOn;

		//Debug.Log ("MUTE->isMute: " + isMute+"->UnityAdManager: " + UnityAdManager.instance.isMute+"->AudioListener: " + AudioListener.pause);

		
	}
	public void loadNextLevel()
	{
//		Debug.Log("loadNextLevel...current level ="+level);

		//if (level < 4) {
			SceneManager.LoadScene (level+1);
		//}

	}



	public void QuitGame()
	{
		Application.Quit();
	}
}
