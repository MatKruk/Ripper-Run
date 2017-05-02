using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoadPolice : MonoBehaviour {
    private UnityEngine.AI.NavMeshAgent nav;
    private Transform playerMove;
    private GameObject player;
    private Animator PoliceAnim;
    private PlayerCamera playerHealth;
    private VictimDeadCheck victimDead;


    private float posSeconds;
    private float posSecondsTimer = 5f;
    private Vector3 pastPos;
    public Vector3 playerPos3SecFromNow;

    public float investigateTimer;
    public float investigateWait;


    private bool canSeePlayer;
    public SphereCollider col;
    public float fieldOfViewAngle = 110f;
    Vector3 previousSighting;
    private Vector3 playerPos;

    public float chaseSpeed;
    // Use this for initialization
    void Start ()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        playerMove = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerCamera>();

        victimDead = GameObject.FindGameObjectWithTag("Police").GetComponent<VictimDeadCheck>();

        PoliceAnim = GetComponent<Animator>();

        transform.LookAt(player.transform);
    }
	
	// Update is called once per frame
	void Update ()
    {
        StartCoroutine(Search());
        posSeconds += Time.deltaTime;

        if (posSeconds >= posSecondsTimer)
        {
            pastPos = player.transform.position;
            posSeconds = 0f;
        }
    }

    void Chase()
    {

        nav.speed = chaseSpeed;
        nav.SetDestination(previousSighting);
        PoliceAnim.Play("Run");
        transform.LookAt(playerMove);

        if (Vector3.Distance(transform.position, player.transform.position) <= 3)
        {
           
            Arrest();
          
        }

        else if (Vector3.Distance(transform.position, previousSighting) <= 3 && !canSeePlayer)

        {
            Investigate();
        }

    }
    void Arrest()
    {

        SceneManager.LoadScene("Arrest_Scene", LoadSceneMode.Single);
        Destroy(gameObject);

    }

    void Investigate()
    {
        investigateTimer += Time.deltaTime;

        print("doing search");
        PoliceAnim.Play("Walk");



        //NavMeshHit hit;

        nav.destination = playerPos3SecFromNow;



        if (investigateTimer >= investigateWait)
        {
            print("Cant Find Jack going to patrol");
            Destroy(gameObject);
        }
    }

    IEnumerator Search()
    {
        while (canSeePlayer)
        {
            Vector3 sightingPlayer = previousSighting - transform.position;

            playerPos = player.transform.position;

            playerPos3SecFromNow = playerPos + pastPos;

            //previousSighting


            yield return new WaitForSeconds(1);

        }
    }


    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            canSeePlayer = false;

            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            if (angle < fieldOfViewAngle * 0.5f)
            {
                RaycastHit hit;

                if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius))
                {
                    if (hit.collider.gameObject == player && GameObject.FindGameObjectWithTag("Police").GetComponent<VictimDeadCheck>().deadVic)
                    {
                        canSeePlayer = true;
                        transform.LookAt(player.transform);
                        previousSighting = player.transform.position;
                        Chase();
                    }
                }

                //Hearing
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
            canSeePlayer = false;
    }
}
