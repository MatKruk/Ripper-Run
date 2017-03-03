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
	
}
