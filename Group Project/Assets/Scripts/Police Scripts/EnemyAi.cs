using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAi : MonoBehaviour
{

    private UnityEngine.AI.NavMeshAgent nav;
    private Transform playerMove;
    private GameObject player;
    private Animator PoliceAnim;
    private PlayerCamera playerHealth;
    private VictimDeadCheck victimDead;
    private AudioSource Source;
    public AudioClip stopShout;
	 


    public enum State
    {
        PATROL,
        CHASE,
        INVESTIGATE,
        ARREST
    }

    public State state;
    private bool alive;


    //variables for Patrol
    public Transform[] wayPoints;
    private int wayPointId = 0;
    public float patrolSpeed;
    public float patrolWaitTime;
    public float patrolTimer;



    // Variables for Chase
<<<<<<< HEAD
    public static float chaseSpeed;
=======
    public float chaseSpeed;
    public bool isChasing;
>>>>>>> refs/remotes/origin/master

    // Variables for Search
    private float posSeconds;
    private float posSecondsTimer = 5f;
    private Vector3 pastPos;
    public Vector3 playerPos3SecFromNow;

    // Variables for Investigate 
    public float investigateTimer;
    public float investigateWait;
    private Vector3 playerPos;
    private Transform searchPoint;
   // private int searchIndex = 0;


    // Variables for Sight
    private SphereCollider col;
    public float fieldOfViewAngle = 110f;
    public bool canSeePlayer;
    public Vector3 previousSighting;

    //Variables for Shout
    private float shoutTimer;
    private float shoutStart = 10f;



    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        col = GetComponent<SphereCollider>();
        playerMove = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerCamera>();

        victimDead = GameObject.FindGameObjectWithTag("Police").GetComponent<VictimDeadCheck>(); 

        PoliceAnim = GetComponent<Animator>();
        Source = GetComponent<AudioSource>();
        

        nav.updatePosition = true;
        nav.updateRotation = true;

        state = EnemyAi.State.PATROL;

        alive = true;

        StartCoroutine("FSM");
        // StartCoroutine(Search());
         PoliceAnim.Play("idle");
        
    }

    void Update()
    {
        StartCoroutine(Search());
        posSeconds += Time.deltaTime;

        if (posSeconds >= posSecondsTimer)
        {
            pastPos = player.transform.position;
            posSeconds = 0f;
        }

        if(canSeePlayer)
        {
            Sound();
        }
    }
   

    IEnumerator FSM()
    {
        while (alive)
        {
            switch (state)
            {
                case State.PATROL:
                    Patrol();
                    break;
                case State.CHASE:
                    Chase();
                    break;
                case State.INVESTIGATE:
                    Investigate();
                    break;
                case State.ARREST:
                    Arrest();
                    break;
            }
            yield return null;

        }
    }

    void Patrol()
    {

        nav.speed = patrolSpeed;

        nav.destination = wayPoints[wayPointId].position;

        PoliceAnim.Play("Walk");

        if (Vector3.Distance(transform.position, wayPoints[wayPointId].transform.position) <= 1)
        {

            if (patrolTimer < patrolWaitTime)
            {
                patrolTimer += Time.deltaTime;
                transform.Rotate(0, Time.deltaTime * 90f, 0);
                PoliceAnim.Play("idle");

            }
            else
            {
                if (wayPointId == wayPoints.Length - 1)
                {
                    wayPointId = 0;
                }
                else
                {
                    wayPointId++;

                }

                patrolTimer = 0;


            }
        }

    }

    void Investigate()
    {
       
      investigateTimer += Time.deltaTime;

      print("doing search");
      PoliceAnim.Play("Walk");
      nav.destination = playerPos3SecFromNow;


      if (investigateTimer >= investigateWait)
       {
          print("doing Nothing");
          state = EnemyAi.State.PATROL;
       }
    }

    void Chase()
    {
                
        nav.speed = chaseSpeed;
        nav.SetDestination(previousSighting);
        PoliceAnim.Play("Run");
        isChasing = true;
        
        if (Vector3.Distance(transform.position, player.transform.position) <= 3)
            {

                state = EnemyAi.State.ARREST;
                isChasing = false;
            }
        else if (Vector3.Distance(transform.position, previousSighting) <= 3 && !canSeePlayer)
            {
                state = EnemyAi.State.INVESTIGATE;
                print("asda");
                isChasing = false;

            }

    }

    void Arrest()
    {

        SceneManager.LoadScene("Arrest_Scene", LoadSceneMode.Single);

    }

    void Sound()
    {
        AudioClip clip = null;
        clip = stopShout;
        
        shoutTimer += Time.deltaTime;
        if(shoutTimer >= shoutStart )
        {
            Source.PlayOneShot(clip);
       }
        
    }

    IEnumerator Search()
    {
        while (canSeePlayer)
        {
            Vector3 sighting = previousSighting - transform.position;

            Vector3 currentPos = player.transform.position;

            playerPos3SecFromNow = currentPos + (sighting - pastPos);

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
                    if (hit.collider.gameObject == player && victimDead.deadVic)
                    {
                        
                        
                        canSeePlayer = true;
                        transform.LookAt(player.transform);
                        previousSighting = player.transform.position;
                        state = EnemyAi.State.CHASE;
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







    // void FixedUpdate()
    // {
    //     RaycastHit hit;
    //     Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, transform.forward * sightDist, Color.blue);
    //     Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (transform.forward + transform.right).normalized * sightDist, Color.blue);
    //     Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (transform.forward - transform.right).normalized * sightDist, Color.blue);
    //
    //     if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, transform.forward, out hit, sightDist))
    //     {
    //         if (hit.collider.gameObject.tag == "Player")
    //         {
    //             state = EnemyAi.State.CHASE;
    //             transform.LookAt(player);
    //             lastSight = player.transform.position;
    //             canSee = true;
    //         }
    //         else
    //         {
    //             canSee = false;
    //         }
    //
    //     }
    //
    //     if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (transform.forward + transform.right).normalized, out hit, sightDist))
    //     {
    //         if (hit.collider.gameObject.tag == "Player")
    //         {
    //             state = EnemyAi.State.CHASE;
    //             transform.LookAt(player);
    //             lastSight = player.transform.position;
    //             canSee = true;
    //         }
    //         else
    //         {
    //             canSee = false;
    //         }
    //
    //
    //     }
    //
    //     if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (transform.forward - transform.right).normalized, out hit, sightDist))
    //     {
    //         if (hit.collider.gameObject.tag == "Player")
    //         {
    //             state = EnemyAi.State.CHASE;
    //             transform.LookAt(player);
    //             lastSight = player.transform.position;
    //             canSee = true;
    //         }
    //         else
    //         {
    //             canSee = false;
    //         }
    //
    //
    //
    //     }
    //
    // }

}
