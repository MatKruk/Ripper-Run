using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
	private DetectHit victim;
	// Use this for initialization
	void Start () {
		victim = GameObject.FindGameObjectWithTag("Victim").GetComponent<DetectHit> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other)
	{
		if (victim.isDead == true) 
		{
			GameObject.Find("Jack").SendMessage("finish");
			SceneManager.LoadScene ("Win_Scene", LoadSceneMode.Single);
			print ("This works");
		}
	}
}

