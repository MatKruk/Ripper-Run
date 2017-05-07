using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour {

	[SerializeField] Camera firstPerson = null;
	[SerializeField] Camera thirdPerson = null;
	[SerializeField] Camera backCamera = null;
	[SerializeField] Camera fullMapCam = null;
	private bool switchCam = false;
	private bool backCam = false;
	private int x = 0;
	private int i = 0;

	// Use this for initialization
	void Start () 
	{
		firstPerson.GetComponent<Camera>().enabled = true;
		thirdPerson.GetComponent<Camera>().enabled = false;
		backCamera.GetComponent<Camera>().enabled = false;

		fullMapCam.GetComponent<Camera>().enabled = false;
	}

	// Update is called once per frame
	void Update () 
	{
		// Input to toggle full screen map on and off ----------
		//
		if (Input.GetKeyDown ("m") && i == 0) {
			fullMapCam.GetComponent<Camera> ().enabled = true;
			i = 1;
		}
		else if (Input.GetKeyDown ("m") && i == 1) {
			fullMapCam.GetComponent<Camera> ().enabled = false;
			i = 0;
		}
		//------------------------------------------------------	
		if(Input.GetKeyDown("e") || Input.GetButton("3rdPerson"))
		{
			switchCam = !switchCam;
			backCam = false;
		}
		if (Input.GetKeyDown("f") || Input.GetButton ("BackCam"))
		{
			switchCam = false;
			backCam = true;
		}
			
		if(switchCam == true)
		{
			firstPerson.GetComponent<Camera>().enabled = false;
			thirdPerson.GetComponent<Camera>().enabled = true;
			backCamera.GetComponent<Camera>().enabled = false;

		}
		else if(backCam == true)
		{
			firstPerson.GetComponent<Camera>().enabled = false;
			thirdPerson.GetComponent<Camera>().enabled = false;
			backCamera.GetComponent<Camera>().enabled = true;
		}
		else
		{
			firstPerson.GetComponent<Camera>().enabled = true;
			thirdPerson.GetComponent<Camera>().enabled = false;
			backCamera.GetComponent<Camera>().enabled = false;
		}
	}
}
