using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerIcon : MonoBehaviour {

	public Transform player;
	private GameObject PlayerRotation;

	//CameraMouseLook cameraMouseLook;

	//void Start () {

		//player = GameObject.FindGameObjectsWithTag ("Player").transform;
		//PlayerRotation = GameObject.Find("Player").transform;

		//cameraMouseLook = PlayerRotation.GetComponent<CameraMouseLook> ();

	
	//}
	
	// Update is called once per frame
	void FixedUpdate () {

		//float xRot = 0;
		//Vector2 yRot;// = PlayerRotation.rotation.y * 360;
		//float zRot = 0;
		//yRot = cameraMouseLook.mouseLook;// = yRot;
		this.transform.position = new Vector3 (player.position.x, this.transform.position.y, player.position.z);
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x, player.eulerAngles.y, transform.eulerAngles.z);
		//this.transform.rotation = new Quaternion (xRot, player.rotation.y, zRot, 1);
		//this.transform.rotation = new Quaternion (xRot, yRot, zRot, 1);

	}
}
