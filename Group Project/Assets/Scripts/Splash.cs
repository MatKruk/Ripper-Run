using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {

	public Image splashimg;
	public Image splashimg2;
	public Image splashimg3;
	public string loadLevel;

	IEnumerator Start()
	{
		splashimg.canvasRenderer.SetAlpha (0.0f);
		splashimg2.canvasRenderer.SetAlpha (0.0f);
		splashimg3.canvasRenderer.SetAlpha (0.0f);

		FadeInUSW ();
		yield return new WaitForSeconds (3.0f);
		FadeOutUSW ();
		yield return new WaitForSeconds (3.0f);
		FadeInLogo ();
		yield return new WaitForSeconds (3.0f);
		FadeOutLogo ();
		yield return new WaitForSeconds (3.0f);
		FadeInName ();
		yield return new WaitForSeconds (3.0f);
		FadeOutName ();
		yield return new WaitForSeconds (3.0f);
		SceneManager.LoadScene (loadLevel);
	}

	void FadeInUSW()
	{
		splashimg.CrossFadeAlpha (1.0f, 3.5f, false);
	}
	void FadeOutUSW()
	{
		splashimg.CrossFadeAlpha (0.0f, 3.5f, false);
	}

	void FadeInLogo()
	{
		splashimg2.CrossFadeAlpha (1.0f, 3.5f, false);
	}
	void FadeOutLogo()
	{
		splashimg2.CrossFadeAlpha (0.0f, 3.5f, false);
	}
	void FadeInName ()
	{
		splashimg3.CrossFadeAlpha (1.0f, 3.5f, false);
	}
	void FadeOutName()
	{
		splashimg3.CrossFadeAlpha (0.0f, 3.5f, false);
	}
}
