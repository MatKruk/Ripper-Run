using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

[RequireComponent (typeof(AudioSource))]

public class PlayCutscene : MonoBehaviour {

	public MovieTexture movie;
	private AudioSource audio;

	void Start () {
		GetComponent<RawImage> ().texture = movie as MovieTexture;
		audio = GetComponent<AudioSource> ();
		movie.Stop ();
		movie.Play ();
		StartCoroutine (WaitAndLoad (9f, "Map_AI"));		
	}

	private IEnumerator WaitAndLoad(float value, string scene){
		yield return new WaitForSeconds (value);
		EditorSceneManager.LoadScene (scene);	
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetButton ("joystickX") && movie.isPlaying) {
			movie.Stop ();
			EditorSceneManager.LoadScene ("Map_AI");
		}
	}
}
