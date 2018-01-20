using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LastPanelLoader : MonoBehaviour {

	public GameObject gameCompletePanel;
	public Slider loadingSlider;
	public GameObject loadingPanel;
	public GameObject exitPanel;


	// Use this for initialization
	void Start () {
		Text[] gameOver =gameCompletePanel.GetComponentsInChildren<Text>();
		gameOver[1].text = PlayerPrefs.GetInt ("SCORE").ToString();
		gameOver[3].text = PlayerPrefs.GetInt ("BESTSCORE").ToString();;

	}

	 void Update()
	{


		if (Input.GetKeyDown (KeyCode.Escape)) {
			exitPanel.SetActive (true);
			return;
		}
	}

	public void HideExitDialog()
	{
		exitPanel.SetActive (false);

	}


	public void LoadStartingLevel()
	{
		//Debug.Log ("load 0 level");
		loadingPanel.SetActive (true);
		StartCoroutine(LoadAsynchronously (0));
	}

	IEnumerator LoadAsynchronously (int index)
	{
		//loadingPanel.SetActive (true);
		AsyncOperation operation = SceneManager.LoadSceneAsync (index);

		while (!operation.isDone) {
			float progress = Mathf.Clamp01 (operation.progress / 0.9f);
			loadingSlider.value = progress;
			//progressText.text = progress * 100f+"%";
			yield return null; 
		}
	}
	public void QuitGame()
	{
		Application.Quit();
	}
}
