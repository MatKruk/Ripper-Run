using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPoliceIcon : MonoBehaviour {

	public Transform character;

	void FixedUpdate () {

		this.transform.position = new Vector3 (character.position.x, this.transform.position.y, character.position.z);

	}
}
