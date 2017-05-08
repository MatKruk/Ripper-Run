using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEditor.SceneManagement;

public class PlayCutscene : MonoBehaviour {

	//Raw Image to Show Video Images
	public RawImage image;
	//Video To Play
	public VideoClip videoToPlay;
	
	private VideoPlayer videoPlayer;
	private VideoSource videoSource;
	
	// Use this for initialization
	void Start()
	{
		Application.runInBackground = true;
		// Coroutine to play cutscene
		StartCoroutine(playVideo());
		// Corouting to load the level after a timer
		StartCoroutine (WaitAndLoad (9.5f, "Map_AI"));
	}
	
	IEnumerator playVideo()
	{
		//Add VideoPlayer to the GameObject
		videoPlayer = gameObject.AddComponent<VideoPlayer>();

		videoPlayer.playOnAwake = true;
	
		videoPlayer.source = VideoSource.VideoClip;

		videoPlayer.clip = videoToPlay;
		videoPlayer.Prepare();
		
		//Wait until video is prepared
		WaitForSeconds waitTime = new WaitForSeconds(1);
		while (!videoPlayer.isPrepared)
		{
			//Prepare/Wait for 5 sceonds only
			yield return waitTime;
			//Break out of the while loop after 1 seconds wait
			break;
		}
	
		//Assign the Texture from Video to RawImage to be displayed
		image.texture = videoPlayer.texture;
	
		//Play the cutscene
		videoPlayer.Play();

	}

	// Coroutine to load the scene after video is done
	private IEnumerator WaitAndLoad(float value, string scene){
		yield return new WaitForSeconds (value);
		EditorSceneManager.LoadScene (scene);	
	}
	
	void Update () {
		// Check for input that interrupts the cutscene and loads the game.
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetButton ("joystickX") && videoPlayer.isPlaying) {
			videoPlayer.Stop ();
			EditorSceneManager.LoadScene ("Map_AI");
		}
	}
	
}
