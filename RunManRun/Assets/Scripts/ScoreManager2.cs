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
		Debug.Log ("----------Level "+level+" Starts----------");
		if (level == 1) {
			
			score = 0;

			if (!PlayerPrefs.HasKey ("SCORE")) {
				PlayerPrefs.SetInt ("SCORE", score);
			} 
		
		} else {
			score = PlayerPrefs.GetInt ("SCORE");
		}
	}

	public void resetPref ()
	{
		PlayerPrefs.DeleteKey ("SCORE");
		Debug.Log ("score key removed");
	}


	// Update is called once per frame
	void Update () {

	}

	public void incrementScore (int count)
	{
		score += count;
	}

	public void incrementScoreEnergyBall1 ()
	{
		
		score += 20;
		Debug.Log ("score (+20)-"+ScoreManager2.instance.score);
	}
	public void incrementScoreEnergyBall2 ()//********check enerygyballs
	{
		
		score += 30;
		Debug.Log ("score (+30)-"+ScoreManager2.instance.score);
	}
	public void incrementScoreEnergyBall3 ()//********check enerygyballs
	{

		score += 50;
		Debug.Log ("score (+50)-"+ScoreManager2.instance.score);
	}
	public void incrementScoreEnergyBall4 ()
	{
		score += 100;
		Debug.Log ("score (+100)-"+ScoreManager2.instance.score);
	}
	/*public void startScore ()
	{
		InvokeRepeating ("incrementScore",0.1f,0.5f);
	}*/




	public void stopScore()
	{
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
