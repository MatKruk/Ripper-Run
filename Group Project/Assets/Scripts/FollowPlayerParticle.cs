using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerParticle : MonoBehaviour {


	public Transform Player;
	private GameObject PlayerRotation;

	void FixedUpdate () {

		this.transform.position = new Vector3 (Player.position.x, this.transform.position.y, Player.position.z);
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);

	}
}