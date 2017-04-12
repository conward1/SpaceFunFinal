using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

	private bool loadNextScene = false;
	private int sceneIndex = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (loadNextScene) 
		{
			//StopAllCoroutines ();
			Debug.Log ("Loading next scene");
			SceneManager.LoadScene (sceneIndex, LoadSceneMode.Single);
		}	
	}

	void OnMouseDown()
	{
		if(gameObject.CompareTag("start"))
		{
			sceneIndex = 2;
			loadNextScene = true;
			PlayerPrefs.SetInt ("level", 0);
		}
		if (gameObject.CompareTag ("continue")) 
		{
			//figure out how to load a level
			if (PlayerPrefs.GetInt ("level") != 0 && PlayerPrefs.GetInt ("level") != 12) {
				sceneIndex = PlayerPrefs.GetInt ("level");
				loadNextScene = true;
			} 
			else
			{
				sceneIndex = 2;
				loadNextScene = true;
				PlayerPrefs.SetInt ("level", 0);
			}
		}
	}
}
