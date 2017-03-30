using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnVictim : MonoBehaviour {

	public GameObject enemy;                // The enemy prefab to be spawned.
	public float spawnTime = 3f;            // How long between each spawn.
	public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
	public Transform ui;

	void OnTriggerEnter(Collider other)
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		if  (other.tag == "Player")
		{
			if (ui.gameObject.activeInHierarchy == false) 
			{
				ui.gameObject.SetActive (true);
				InvokeRepeating ("Spawn", spawnTime, spawnTime);
				enemy.gameObject.SetActive (true);
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (ui.gameObject.activeInHierarchy == true) 
		{
			ui.gameObject.SetActive (false);
			//Cancels after exit
			CancelInvoke ("Spawn");

			Destroy (gameObject);
		}
	}


	void Spawn ()
	{

		// Find a random index between zero and one less than the number of spawn points.
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

	}
}
