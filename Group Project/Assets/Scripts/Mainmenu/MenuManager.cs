using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public Menu currentMenu;

	public void Start(){
		ShowMenu (currentMenu);
	}

	public void ShowMenu(Menu menu){

		if (currentMenu != null) 
			currentMenu.IsOpen = false;


		currentMenu = menu;
		currentMenu.IsOpen = true;
	}

    public void StartGame()
    {
        SceneManager.LoadScene("Cinematic_Whitechapel", LoadSceneMode.Single);
    }


	public void Exit()
	{
		Application.Quit();
	}


}


