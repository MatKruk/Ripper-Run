using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimDeadCheck : MonoBehaviour {

    private DetectHit victimDead;
    public GameObject[] Victims;
    public bool deadVic;



    // Use this for initialization
    void Start ()
    {
        victimDead = GameObject.FindGameObjectWithTag("Victim").GetComponent<DetectHit>();
        //deadVic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (victimDead.isDead)
            {
                deadVic = true;
            }
        else deadVic = false;

            //
            //     for (int i = 0; i <= Victims.Length; i++)
            //     {
            //         print("CHeck Vic = i");
            //         if (victimDead.isDead)
            //         {
            //             deadVic = true;
            //         }
            //         else deadVic = false;
            //     }
            //
    }
}
