using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceAudio : MonoBehaviour {

   
    public AudioClip stopShout;
    public AudioSource source;
    private EnemyAi playerSeen;
    public bool playerCanBeSeen;

    void Start()
    {
        source = GetComponent<AudioSource>();
        playerSeen = GameObject.FindGameObjectWithTag("Police").GetComponent<EnemyAi>();
    }

   

   void ShoutStop()
    {
        float volume = 1f;
        AudioClip clip = null;
        if (playerSeen.canSeePlayer)
        {
            playerCanBeSeen = true;
            clip = stopShout;
            volume = UnityEngine.Random.Range(0.3f, 0.6f);
            print("Grass: Audio Play Shout Stop");
        }

        if (clip != null)
        {
            source.PlayOneShot(clip, volume);
            //source.pitch = UnityEngine.Random.Range(0.0f, 0.6f);
        }
    }
}
