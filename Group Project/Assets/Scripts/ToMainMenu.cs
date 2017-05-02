using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainMenu : MonoBehaviour {

	void Start()
	{
		Cursor.lockState = CursorLockMode.None;
	}


	public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }

	public void NextLevel()
	{
		SceneManager.LoadScene("Level2", LoadSceneMode.Single);
	}

	public void Retry()
	{
		//Add Night 2 Details here..
		SceneManager.LoadScene ("Map_AI", LoadSceneMode.Single);
	}
	
}
