using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour {

	public Text text1;
	public Text text2;
	public Button btn;
	public Text btnText;
	public Button btn1;
	public Text btnText2;
	// Use this for initialization
	IEnumerator Start() 
	{
		//Set Invisible
		text1.canvasRenderer.SetAlpha (0.0f);
		text2.canvasRenderer.SetAlpha (0.0f);
		btn.image.canvasRenderer.SetAlpha (0.0f);
		btnText.canvasRenderer.SetAlpha (0.0f);
		btn1.image.canvasRenderer.SetAlpha (0.0f);
		btnText2.canvasRenderer.SetAlpha (0.0f);

		//Wait and then Fade in using alpha
		yield return new WaitForSeconds (2.0f);
		FadeInText ();
		yield return new WaitForSeconds (2.0f);
		FadeInText2 ();
		yield return new WaitForSeconds (2.0f);
		FadeInButtons ();

	}
	//Text for Night and Victim Number
	void FadeInText()
	{
		//Alpha from 0.0f to 1.0f fades in over 3.5 seconds
		text1.CrossFadeAlpha (1.0f, 3.5f, false);
	}
	void FadeInText2()
	{
		text2.CrossFadeAlpha (1.0f, 3.5f, false);
	}
	//Buttons to continue to main or next level
	void FadeInButtons()
	{
		btn.image.CrossFadeAlpha (1.0f, 3.5f, false);
		btnText.CrossFadeAlpha (1.0f, 3.5f, false);
		btn1.image.CrossFadeAlpha (1.0f, 3.5f, false);
		btnText2.CrossFadeAlpha (1.0f, 3.5f, false);
	}
}
