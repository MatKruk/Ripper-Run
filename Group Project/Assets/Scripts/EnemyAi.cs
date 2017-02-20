using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{

	private UnityEngine.AI.NavMeshAgent nav;
    private Transform playerMove;
	private GameObject player;
	private Animator PoliceAnim;
    private DetectHit victimDead;
    public AudioClip ShoutStop;
	

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
    public float chaseSpeed;


    // Variables for Investigate 
    public float investigateTimer;
    public float investigateWait;
    private Vector3 playerPos;


    // Variables for Sight
    private SphereCollider col;
    public float fieldOfViewAngle = 110f;
    public bool canSeePlayer;
    public Vector3 previousSighting;



    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        col = GetComponent<SphereCollider>();
        playerMove = GameObject.FindGameObjectWithTag("Player").transform;
		player = GameObject.FindGameObjectWithTag("Player");
        victimDead = GameObject.FindGameObjectWithTag("Victim").GetComponent<DetectHit>();
        PoliceAnim = GetComponent<Animator>();
        

        nav.updatePosition = true;
        nav.updateRotation = true;

        state = EnemyAi.State.PATROL;

        alive = true;

        StartCoroutine("FSM");
       // PoliceAnim.Play("idle");

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

       
        if (Vector3.Distance(transform.position, wayPoints[wayPointId].transform.position) <= 1)
        {
            
            if (patrolTimer < patrolWaitTime)
            {
                patrolTimer += Time.deltaTime;

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
        

        if (investigateTimer < investigateWait)
            {
                investigateTimer += Time.deltaTime;

               // transform.LookAt(playerMove.position);
                nav.SetDestination(previousSighting);
            // Vector3 Search = transform.position + transform.forward;
            // nav.SetDestination(Search);


        }
        
    }

    void Chase()
    {
        nav.speed = chaseSpeed;
        playerPos = player.transform.position;
        nav.SetDestination(previousSighting);
        //nav.destination = player.transform.position;
       // Vector3 pos = playerMove.forward;
       // pos *= 5;
       // pos += playerMove.position;

       //transform.position = pos;

        if (Vector3.Distance(transform.position, previousSighting) <= 3 && !canSeePlayer)
        {
            state = EnemyAi.State.INVESTIGATE;
            print("asda");
        }
        else if(Vector3.Distance(transform.position, playerPos) == 5) 
        {
            
        }
    
    }

    void Arrest()
    {
        


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
                    if (hit.collider.gameObject == player && victimDead.isDead)
                    {
                        print("Play Sound");
                        GetComponent<AudioSource>().PlayOneShot(ShoutStop);
                        
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
