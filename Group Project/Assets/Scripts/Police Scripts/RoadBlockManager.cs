using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlockManager : MonoBehaviour {
    public GameObject Police;
    private PlayerCamera playerHealth;

    public GameObject player;
    public Transform spawnRotation;

    public float spawnRoadBlock;

    public float RoadBlockTimer;
    public float RoadBlockStart;

    // Use this for initialization
    void Start ()
    {
        playerHealth = player.GetComponent<PlayerCamera>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (GameObject.FindGameObjectWithTag("Police").GetComponent<EnemyAi>().isChasing)
        {
            RoadBlockTimer += Time.deltaTime;
            if (RoadBlockTimer >= RoadBlockStart)
            {
                print("Spawn road block");
                Spawn();

                RoadBlockTimer = 0;
            }


        }
    }

    void Spawn()
    {

        spawnRoadBlock = Random.Range(20, 50);
        Vector3 playerDirection = player.transform.forward;
        Vector3 playerPos = player.transform.position;
        Vector3 spawnPos = playerPos + playerDirection * spawnRoadBlock;

        Instantiate(Police, spawnPos, spawnRotation.rotation);
        

    }
}
