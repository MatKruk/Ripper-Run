using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceAudio : MonoBehaviour {

   
    public AudioClip stopShout;
    public AudioSource source;
    private EnemyAi playerSeen;
    public bool playerCanBeSeen;
    public bool deadVictim;
    private VictimDeadCheck victimDead;


    void Start()
    {
        source = GetComponent<AudioSource>();
        playerSeen = GameObject.FindGameObjectWithTag("Police").GetComponent<EnemyAi>();
        victimDead = GameObject.FindGameObjectWithTag("Police").GetComponent<VictimDeadCheck>();
    }

   

   void ShoutStop()
    {
        float volume = 1f;
        AudioClip clip = null;

        if (victimDead.deadVic)
        {
            //  playerCanBeSeen = true;
            deadVictim = true;
            clip = stopShout;
            volume = UnityEngine.Random.Range(0.3f, 0.6f);
            source.PlayOneShot(clip);
            print("Grass: Audio Play Shout Stop");
        }
       // if (/*playerCanBeSeen == true &&*/ deadVictim == true)
       // {
       //     clip = stopShout;
       //     volume = UnityEngine.Random.Range(0.3f, 0.6f);
       //     source.PlayOneShot(clip, volume);
       //     print("Grass: Audio Play Shout Stop");
       // }
       //     if (clip != null)
       // {
       //     
       //     //source.pitch = UnityEngine.Random.Range(0.0f, 0.6f);
       // }
    }
}
