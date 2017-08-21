using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager2 : MonoBehaviour {

	public static ScoreManager2 instance;
	public  int score;
	public int bestScore;
	int level;

	void Awake () {
		if (instance == null) {
			instance = this;
		}
	}


	// Use this for initialization
	void Start () {
		

		level = UIManager2.instance.level;

		if (level == 1) {
			
			score = 0;

			if (!PlayerPrefs.HasKey ("SCORE")) {
				PlayerPrefs.SetInt ("SCORE", score);
			} 
		
		} else {
			score = PlayerPrefs.GetInt ("SCORE");
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public void incrementScore ()
	{
		score += 1;
	}
	public void incrementScoreEnergyBall1 ()
	{
		score += 10;
	}
	public void incrementScoreEnergyBall2 ()
	{
		score += 20;
	}
	public void incrementScoreEnergyBall3 ()//********check enerygyballs
	{
		score += 30;
	}

	/*public void startScore ()
	{
		InvokeRepeating ("incrementScore",0.1f,0.5f);
	}*/




	public void stopScore()
	{
		//Debug.Log ("stopScore - should come here only at Level4");
		//CancelInvoke ("incrementScore");
		PlayerPrefs.SetInt ("SCORE",score);

		if (PlayerPrefs.HasKey ("BESTSCORE")) {
			if(score>PlayerPrefs.GetInt ("BESTSCORE"))
			{
				PlayerPrefs.SetInt ("BESTSCORE",score);
			}
		} 
		else {

			PlayerPrefs.SetInt ("BESTSCORE",score);
		}
	}

}
