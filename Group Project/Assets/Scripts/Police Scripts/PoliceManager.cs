using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceManager : MonoBehaviour {
    public GameObject police;
    private PlayerCamera playerHealth;
    public Transform[] spawnPoints;
    public GameObject player;
   
    public float spawnRoadBlock; 

    public float RoadBlockTimer;
    public float RoadBlockStart = 10f;
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
            if (RoadBlockTimer >= 10)
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
        
        //if(spawnRoadBlock >= 6)
      //  {
            Instantiate(police, spawnPos, spawnPoints[0].rotation);
       // }
        
     

        


    }
}
