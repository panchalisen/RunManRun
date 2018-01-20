using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {
	
	public GameObject loadingPanel;
	public Slider loadingSlider;
	public AudioManager2 am;
	public GameObject btnMute;
	bool isMute;

	//public Text progressText;

	void Start () {
		am.introMusic.Play ();
		LoadLevel (1);
		isMute = false;
		AudioListener.pause = false;
		//btnMute.GetComponent<Image> ().sprite =  SoundOn;


	}



	public void LoadLevel(int index)
	{
		
		StartCoroutine(LoadAsynchronously (index));
	}

	IEnumerator LoadAsynchronously (int index)
	{

		yield return new WaitForSeconds (7f);

		//loadingPanel.SetActive (true);
		AsyncOperation operation = SceneManager.LoadSceneAsync (index);

		while (!operation.isDone) {
			float progress = Mathf.Clamp01 (operation.progress / 0.9f);
			loadingSlider.value = progress;
			//progressText.text = progress * 100f+"%";
			yield return null; 
		}
	}

}