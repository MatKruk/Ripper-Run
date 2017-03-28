using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
	private DetectHit victim;
    public BoxCollider col;
    private GameObject player;
    // Use this for initialization
    void Start ()
    {
        col = GetComponent<BoxCollider>();
        victim = GameObject.FindGameObjectWithTag("Victim").GetComponent<DetectHit> ();
        player = GameObject.FindGameObjectWithTag("Player");

    }

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col)
	{
<<<<<<< HEAD
        if (col.gameObject == player)
        {
            if (victim.isDead == true)
            {
                GameObject.Find("Jack").SendMessage("finish");
                SceneManager.LoadScene("Win_Scene", LoadSceneMode.Single);
                //print ("This works");
            }
        }
=======
		if (other.tag == "Player") {
			if (victim.isDead == true) {
				GameObject.Find ("Jack").SendMessage ("finish");
				SceneManager.LoadScene ("Win_Scene", LoadSceneMode.Single);
				//print ("This works");
			}
		} //else
			//Debug.Log ("Not Player: " + other.name);
>>>>>>> refs/remotes/origin/master
	}
}

