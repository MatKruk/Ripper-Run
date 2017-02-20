using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour {

	[SerializeField] Camera firstPerson;
	[SerializeField] Camera thirdPerson;
	[SerializeField] Camera backCamera;
	private bool switchCam = false;
	private bool backCam = false;

	// Use this for initialization
	void Start () 
	{
		firstPerson.GetComponent<Camera>().enabled = true;
		thirdPerson.GetComponent<Camera>().enabled = false;
		backCamera.GetComponent<Camera>().enabled = false;
	}

	// Update is called once per frame
	void Update () 
	{       
		if(Input.GetKeyDown("e"))
		{
			switchCam = !switchCam;
			backCam = false;
		}
		if (Input.GetKeyDown("f"))
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
