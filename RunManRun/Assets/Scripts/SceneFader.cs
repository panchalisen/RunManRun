using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour {


	public Image black;
	public Animator anim;
	public int level;
	public Text bestScoreText;

	// Use this for initialization
	void Start () {

		var tempColor = black.color;
		tempColor.a = 1;
		black.color = tempColor;
		string initText;

		if (!PlayerPrefs.HasKey ("BESTSCORE")) {
			initText = "BEST SCORE: 0";
		} else {

			//if(PlayerPrefs.GetInt ("SCORE")>0)
			//initText = "SCORE: "+PlayerPrefs.GetInt ("SCORE");
			//else
			initText = "BEST SCORE: "+PlayerPrefs.GetInt ("BESTSCORE");
		}

		bestScoreText.text = initText;

	}

	// Update is called once per frame
	void Update () {

		//if (level == 0)
		//	StartCoroutine (Fading ());
	}

	IEnumerator Fading()
	{

		//Debug.Log ("level-"+level);
		yield return new WaitForSeconds (4f);
		anim.SetBool ("boolFade",true);
		anim.Play ("SceneFadeOut");
		//Debug.Log ("waiting for 1f");
		//yield return new WaitForSeconds (1f);
		//Debug.Log ("gg");

		//yield return new WaitUntil (()=>black.color.a==1);//(Animation.clip.length);
		Debug.Log ("Loading level1");
		SceneManager.LoadScene("level1");
		Debug.Log ("--------------Loaded level1");

		//black.gameObject.SetActive (false);;
	}
}
