using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerIcon : MonoBehaviour {

	public Transform character;
	private GameObject PlayerRotation;

	void FixedUpdate () {

		this.transform.position = new Vector3 (character.position.x, this.transform.position.y, character.position.z);
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x, character.eulerAngles.y, transform.eulerAngles.z);

	}
}
