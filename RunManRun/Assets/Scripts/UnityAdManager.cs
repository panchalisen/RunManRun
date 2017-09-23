using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdManager : MonoBehaviour {

	public static UnityAdManager instance;
	//public GameObject btnViewRewardedVideo;

	string[] arrAdBtnLabel = new string[3];
	string[] arrLabelConfirmation = new string[3];
	//int[] validLabel=new int[5];
	int level;
	int rand;
	string userMessage;

	private string gameId = "";

	void Awake () {

		DontDestroyOnLoad (this.gameObject);
		if (instance == null) {
			
			instance = this;

			StartCoroutine (InitializeAds());
		}else {
			Destroy (this.gameObject);
		}
			
	}




	// Use this for initialization
	void Start () {
		//Advertisement.Initialize ();
		SetPrefVars ();

	}


	private IEnumerator InitializeAds()
	{
		if(Advertisement.isSupported)
			Advertisement.Initialize(gameId);

		while((!Advertisement.isInitialized)||(!Advertisement.IsReady()))
		{
			yield return new WaitForSeconds(0.5f);
		}

	}

	public void SetAdAdBtnLabels(int level){
	 level = UIManager2.instance.level;

		switch (level) {
		case 1:
			AssignLabelAdBtnLevel1();
			break;

		case 2:
			AssignLabelAdBtnLevel2();
			break;

		case 3:
			AssignLabelAdBtnLevel3();
			break;

		case 4:
			AssignLabelAdBtnLevel4();
			break;
		}

		//Debug.Log ("AssignLabelAdBtnLevel-");
		//Debug.Log (arrAdBtnLabel[0]);

	}

	// Update is called once per frame
	void Update () {
		
	}

	public void SetPrefVars()
	{
		PlayerPrefs.SetInt ("LEVEL_FAILED_COUNT",0);
		//Debug.Log ("LEVEL_FAILED_COUNT.set to 0");
		PlayerPrefs.SetInt ("SCORE",0);
		Debug.Log ("SCORE.set to 0");
	}

	public void ShowNormalVideoAd () {

		if (Advertisement.IsReady ("video")) {
			Advertisement.Show ("video",new ShowOptions {resultCallback = NormalAdCallbackHandler});
		}
	}


	public void ShowRewardedVideoAd () {
		if (Advertisement.IsReady ("rewardedVideo")) {
			Advertisement.Show ("rewardedVideo",new ShowOptions {resultCallback = RewardedAdCallbackHandler});
		}

	}
	public string GetAdText () {
	 	rand= Random.Range (0, arrAdBtnLabel.Length);
//		Debug.Log (arrAdBtnLabel[rand]);
		return arrAdBtnLabel[rand];
	}



	void performAction()
	{
		switch (level) {

		case 1:
			performActionLevel1 ();
			break;
		
		case 2:
			performActionLevel2 ();
			break;

		case 3:
			performActionLevel3 ();
			break;

		case 4:
			performActionLevel4();
			break;

		}
	}

		void NormalAdCallbackHandler(ShowResult result)
		{
			switch (result) {

			case ShowResult.Finished:
				ScoreManager2.instance.incrementScore (level*10);
				ScoreManager2.instance.stopScore ();
				//userMessage = (level*10)+" points have been added";
				//UIManager2.instance.ShowConfirmationPanel (userMessage);
				break;

			case ShowResult.Skipped:
			
				
				break;

			case ShowResult.Failed:

				
				break;
			}
			//Debug.Log (userMessage);
			
		}


	void RewardedAdCallbackHandler(ShowResult result)
	{
		switch (result) {

		case ShowResult.Finished:
			
			userMessage = arrLabelConfirmation[rand];
			performAction ();
			break;

		case ShowResult.Skipped:
			
			userMessage = "No points added.You have skipped the video";
			break;

		case ShowResult.Failed:
			
			userMessage = "No points added.";
			break;
		}
		//Debug.Log (userMessage);
		UIManager2.instance.ShowConfirmationPanel (userMessage);
	}

	public void UpdateLevelFailureCount()
	{
		PlayerPrefs.SetInt ("LEVEL_FAILED_COUNT", PlayerPrefs.GetInt ("LEVEL_FAILED_COUNT") + 1);

	}



	public bool ShowRewardedVideoPanel () {
		
		if ((PlayerPrefs.GetInt ("LEVEL_FAILED_COUNT") % 2)==0) {
			if (Advertisement.IsReady ("rewardedVideo")) {
				//Debug.Log ("Ad ready");
				return true;
			} else {Debug.Log ("Ad not ready");
			}
		} 

		
		return false;
	}



	void AssignLabelAdBtnLevel1(){
		arrAdBtnLabel [0] = "Watch video to add +10 to your score";
		arrAdBtnLabel [1] = "Watch video to add +20 to your score";
		arrAdBtnLabel [2] = "Watch video to add +30 to your score";
		//arrAdBtnLabel [2] = "Watch video to add +"	+	add10	+	" Energy Ball";
		//arrAdBtnLabel [3] = "Watch video to reduce speed of man";
		//arrAdBtnLabel [4] = "Watch video to change run platform color";

		arrLabelConfirmation [0] = "+10 added to your score";
		arrLabelConfirmation [1] = "+20 added to your score";
		arrLabelConfirmation [2] = "+30 added to your score";
		//arrLabelConfirmation [2] = "+10 Energy Ball added in this run";
		//arrLabelConfirmation [3] = "Speed of man reduced in this run";
		//arrLabelConfirmation [4] = "Platform color changed in this run";

	}

	void performActionLevel1(){
		switch (rand) {
		case 0:
			ScoreManager2.instance.incrementScore (10);
			ScoreManager2.instance.stopScore ();
			break;

		case 1:
			ScoreManager2.instance.incrementScore (20);
			ScoreManager2.instance.stopScore ();
			break;

		case 2:
			ScoreManager2.instance.incrementScore (30);
			ScoreManager2.instance.stopScore ();
			break;

			/*case 2:
			GameObject.Find ("Platform1").GetComponent<PlatformSpawner2> ().addEnergyBall ();

			break;

		case 3:
			GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController2>().DecreaseSpeed();
			break;

		case 4:
			ScoreManager2.instance.incrementScore (add10);
			ScoreManager2.instance.stopScore ();
			break;*/
		}

	}

	void AssignLabelAdBtnLevel2(){

		arrAdBtnLabel [0] = "Watch video to add +40 to your score";
		arrAdBtnLabel [1] = "Watch video to add +20 to your score";
		arrAdBtnLabel [2] = "Watch video to add +30 to your score";


		arrLabelConfirmation [0] = "+40 added to your score";
		arrLabelConfirmation [1] = "+20 added to your score";
		arrLabelConfirmation [2] = "+30 added to your score";



		//arrAdBtnLabel [0] = "Watch video to increase run platform width";
		//arrAdBtnLabel [1] = "Watch video to reduce speed of man";
		//arrAdBtnLabel [2] = "Watch video to set sea as background";
		//arrAdBtnLabel [3] = "Watch video to add +20 to your score";
		//arrAdBtnLabel [4] = "Watch video to add a +20 Enery Ball";

		//arrLabelConfirmation [0] = "Run platform width increased in this run";
		//arrLabelConfirmation [1] = "Speed of man reduced in this run";
		//arrLabelConfirmation [2] = "Background set to sea in this run";
		//arrLabelConfirmation [3] = "+20 added to your score";
		//arrLabelConfirmation [4] = "+20 Energy Ball added in this run";
	}
	void performActionLevel2(){
		switch (rand) {
		case 0:
			ScoreManager2.instance.incrementScore (40);
			ScoreManager2.instance.stopScore ();
			break;

		case 1:
			ScoreManager2.instance.incrementScore (20);
			ScoreManager2.instance.stopScore ();
			break;

		case 2:
			ScoreManager2.instance.incrementScore (30);
			ScoreManager2.instance.stopScore ();
			break;

		}

	}
	void AssignLabelAdBtnLevel3(){


		arrAdBtnLabel [0] = "Watch video to add +40 to your score";
		arrAdBtnLabel [1] = "Watch video to add +50 to your score";
		arrAdBtnLabel [2] = "Watch video to add +30 to your score";


		arrLabelConfirmation [0] = "+40 added to your score";
		arrLabelConfirmation [1] = "+50 added to your score";
		arrLabelConfirmation [2] = "+30 added to your score";


		//arrAdBtnLabel [0] = "Watch video to increase platform width";
		//arrAdBtnLabel [1] = "Watch video to reduce speed of man";
		//arrAdBtnLabel [2] = "Watch video to add +30 to your score";
		//arrAdBtnLabel [3] = "Watch video to add two +20 Energy Balls";
		//arrAdBtnLabel [4] = "Watch video to add one +50 Energy Ball";

		//arrLabelConfirmation [0] = "Running platform width increased in this run";
		//arrLabelConfirmation [1] = "Speed of man reduced in this run";
		//arrLabelConfirmation [2] = "+30 added to your score";
		//arrLabelConfirmation [3] = "Two +20 Energy Balls added in this run";
		//arrLabelConfirmation [4] = "One +50 Energy Ball added in this run";

	}
	void performActionLevel3(){
		switch (rand) {
		case 0:
			ScoreManager2.instance.incrementScore (40);
			ScoreManager2.instance.stopScore ();
			break;

		case 1:
			ScoreManager2.instance.incrementScore (50);
			ScoreManager2.instance.stopScore ();
			break;

		case 2:
			ScoreManager2.instance.incrementScore (30);
			ScoreManager2.instance.stopScore ();
			break;

		}
	}
	void AssignLabelAdBtnLevel4(){

		arrAdBtnLabel [0] = "Watch video to add +40 to your score";
		arrAdBtnLabel [1] = "Watch video to add +50 to your score";
		arrAdBtnLabel [2] = "Watch video to add +60 to your score";


		arrLabelConfirmation [0] = "+40 added to your score";
		arrLabelConfirmation [1] = "+50 added to your score";
		arrLabelConfirmation [2] = "+60 added to your score";



		/*arrAdBtnLabel [0] = "Watch video to increase platform width";
		arrAdBtnLabel [1] = "Watch video to reduce speed of man";
		arrAdBtnLabel [2] = "Watch video to add +50 to your score";
		arrAdBtnLabel [3] = "Watch video to add a +100 Energy Ball";
		arrAdBtnLabel [4] = "Watch video to add three +50 Energy Balls";

		arrLabelConfirmation [0] = "Running platform width increased in this run";
		arrLabelConfirmation [1] = "Speed of man reduced in this run";
		arrLabelConfirmation [2] = "+50 added to your score";
		arrLabelConfirmation [3] = "One +100 Energy Ball added in this run";
		arrLabelConfirmation [4] = "Three +50 Energy Balls added in this run";*/
	}

	void performActionLevel4(){
		switch (rand) {
		case 0:
			ScoreManager2.instance.incrementScore (40);
			ScoreManager2.instance.stopScore ();
			break;

		case 1:
			ScoreManager2.instance.incrementScore (50);
			ScoreManager2.instance.stopScore ();
			break;

		case 2:
			ScoreManager2.instance.incrementScore (60);
			ScoreManager2.instance.stopScore ();
			break;

		}

	}



}
