using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour {

	public Transform pause;
	public Transform camera;
	public string loadLevel;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Pause ();
		}

	}

	public void Pause()
	{
		if (pause.gameObject.activeInHierarchy == false) 
		{
			pause.gameObject.SetActive (true);
			Time.timeScale = 0;
			camera.GetComponent<CameraMouseLook> ().enabled = false;
		} 
		else 
		{
			pause.gameObject.SetActive (false);
			Time.timeScale = 1;
			camera.GetComponent<CameraMouseLook> ().enabled = true;
		}
	}

	public void Quit()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene (loadLevel);
		//Application.Quit();
	}
}
