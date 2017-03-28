using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
	private DetectHit victim;
<<<<<<< HEAD
	// Use this for initialization
	void Start () {
		//victim = GameObject.FindGameObjectWithTag("Victim").GetComponent<DetectHit> ();
	}
=======
    public BoxCollider col;
    private GameObject player;
    // Use this for initialization
    void Start ()
    {
        col = GetComponent<BoxCollider>();
        victim = GameObject.FindGameObjectWithTag("Victim").GetComponent<DetectHit> ();
        player = GameObject.FindGameObjectWithTag("Player");

    }
>>>>>>> refs/remotes/origin/master

	// Update is called once per frame
	void Update () {
		victim = GameObject.FindGameObjectWithTag("Victim").GetComponent<DetectHit> ();
	
	}

	void OnTriggerEnter(Collider other)
	{

    if (other.tag == "Player")
        {
			if (victim.isDead == true)
            {
				GameObject.Find ("Jack").SendMessage ("finish");
				SceneManager.LoadScene ("Win_Scene", LoadSceneMode.Single);
				//print ("This works");
			}
		} //else
			//Debug.Log ("Not Player: " + other.name);

	}
}

