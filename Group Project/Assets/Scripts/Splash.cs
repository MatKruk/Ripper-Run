using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {

	public Image teamLogo;
	public Image gameLogo;
	public string loadLevel;

	IEnumerator Start()
	{
		teamLogo.canvasRenderer.SetAlpha (0.0f);
		gameLogo.canvasRenderer.SetAlpha (0.0f);

		FadeInLogo ();
		yield return new WaitForSeconds (3.0f);
		FadeOutLogo ();
		yield return new WaitForSeconds (3.0f);
		FadeInGLogo ();
		yield return new WaitForSeconds (3.0f);
		FadeOutGLogo ();
		yield return new WaitForSeconds (3.0f);
		SceneManager.LoadScene (loadLevel);
	}

	//Team Logo
	void FadeInLogo()
	{
		teamLogo.CrossFadeAlpha (1.0f, 3.5f, false);
	}

	void FadeOutLogo()
	{
		teamLogo.CrossFadeAlpha (0.0f, 3.5f, false);
	}

	//Game Logo
	void FadeInGLogo()
	{
		gameLogo.CrossFadeAlpha (1.0f, 3.5f, false);
	}

	void FadeOutGLogo()
	{
		gameLogo.CrossFadeAlpha (0.0f, 3.5f, false);
	}
}
