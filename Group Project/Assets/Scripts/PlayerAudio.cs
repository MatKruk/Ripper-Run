using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {

	public AudioClip[] stepsounds = new AudioClip[0];
	public AudioSource source;
	//private Animator anim;

	void Start()
	{
		source = GetComponent<AudioSource> ();
		//anim = GetComponent<Animator> ();
	}

	void WalkingFootStepLeft() 
	{
		float volume = 1.0f;
		//float pitch = 1.0f;
		AudioClip clip = null;
		RaycastHit hit = new RaycastHit ();
		if (Physics.Raycast (transform.position, Vector3.down, out hit, 1.5f)) 
		{
			string tag = hit.collider.gameObject.tag;
			if (tag == "Ground") 
			{
				clip = stepsounds [0];
				volume = UnityEngine.Random.Range (0.2f, 0.4f);
				print ("Ground: Audio Play");
			} 
			else if (tag == "Water") 
			{
				clip = stepsounds [1];
				volume = UnityEngine.Random.Range (0.2f, 0.4f);
				print ("Water: Audio Play");
			} 
			else if (tag == "Grass") 
			{
				clip = stepsounds [2];
				volume = UnityEngine.Random.Range (0.2f, 0.4f);
				print ("Grass: Audio Play");
			}
		}
		if (clip != null) 
		{
			source.PlayOneShot (clip, volume);
			//source.pitch = UnityEngine.Random.Range(0.0f, 0.6f);
		}

	}

	void WalkingFootStepRight() 
	{
		float volume = 1.0f;
		//float pitch = 1.0f;
		AudioClip clip = null;
		RaycastHit hit = new RaycastHit ();
		if (Physics.Raycast (transform.position, Vector3.down, out hit, 1.5f)) 
		{
			string tag = hit.collider.gameObject.tag;
			if (tag == "Ground") 
			{
				clip = stepsounds [0];
				volume = UnityEngine.Random.Range (0.2f, 0.4f);
				print ("Ground: Audio Play");
			} 
			else if (tag == "Water") 
			{
				clip = stepsounds [1];
				volume = UnityEngine.Random.Range (0.2f, 0.4f);
				print ("Water: Audio Play");
			}
			else if (tag == "Grass") 
			{
				clip = stepsounds [2];
				volume = UnityEngine.Random.Range (0.2f, 0.4f);
				print ("Grass: Audio Play");
			}
		}
		if (clip != null) 
		{
			source.PlayOneShot (clip, volume);
		}

	}


}