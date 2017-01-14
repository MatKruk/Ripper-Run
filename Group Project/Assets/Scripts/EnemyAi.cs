using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour
{

	private UnityEngine.AI.NavMeshAgent nav;
    private Transform playerMove;
	private GameObject player;
	private Animator PoliceAnim;
	public SphereCollider col;

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
    public float patrolSpeed = 2.0f;
    public float patrolWaitTime = 2.0f;
    public float patrolTimer;

    // Variables for Chase
    public float chaseSpeed = 4.0f;


    // Variables for Investigate 
    public float investigateTimer;
    public float investigateWait;
    private float maxHeadingChange = 30;
    private float heading;
    Vector3 targetRotation;
    public Vector3 wandPoint;


    // Variables for Sight
    public float fieldOfViewAngle = 110f;
	public bool canSeePlayer;
	public Vector3 lastSight;

    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

        playerMove = GameObject.FindGameObjectWithTag("Player").transform;
		player = GameObject.FindGameObjectWithTag("Player");

        PoliceAnim = GetComponent<Animator>();

        nav.updatePosition = true;
        nav.updateRotation = true;


        state = EnemyAi.State.PATROL;

        alive = true;

        StartCoroutine("FSM");
        PoliceAnim.Play("idle");

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
                PoliceAnim.SetBool("Idle", true);
                PoliceAnim.SetBool("Walk", false);
                PoliceAnim.SetBool("Running", false);
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
                PoliceAnim.SetBool("Idle", false);
                PoliceAnim.SetBool("Walk", true);
                PoliceAnim.SetBool("Running", false);
                patrolTimer = 0;
               
             
            }
        }
       
    }

    void Investigate()
    {
       

        if (investigateTimer < investigateWait)
        {
            //transform.LookAt(lastSight);
            //nav.SetDestination(lastSight);

            Vector3 wandPoint = new Vector3 (Random.Range(0.0f, 10.0f), 0, Random.Range(0.0f, 10.0f));

            //wandPoint += transform.position;
            Vector3 lookDirection = this.transform.position - transform.position;
			float angle = Vector3.Angle (lookDirection, transform.forward);

            nav.SetDestination(wandPoint);

            investigateTimer += Time.deltaTime;
           

            /*
            var floor = transform.eulerAngles.y - maxHeadingChange;
            var ceil = transform.eulerAngles.y - maxHeadingChange;
            heading = Random.Range(floor, ceil);
            targetRotation = new Vector3(0, heading, 0);

            nav.SetDestination(targetRotation);
            */
            PoliceAnim.SetBool("Idle", false);
            PoliceAnim.SetBool("Walk", true);
            PoliceAnim.SetBool("Running", false);
        }
        else
        {
            investigateTimer = 0;
            state = EnemyAi.State.PATROL;
        }
    }

    void Chase()
    {
        nav.speed = chaseSpeed;

        nav.SetDestination(lastSight);
        //nav.destination = player.transform.position;
        PoliceAnim.SetBool("Idle", false);
        PoliceAnim.SetBool("Walk", false);
        PoliceAnim.SetBool("Running", true);
        if (Vector3.Distance(transform.position, lastSight) <= 3 && !canSeePlayer)
        {
            state = EnemyAi.State.INVESTIGATE;
            print("asda");
        }
    
    }

    void Arrest()
    {
        


    }


    void OnTriggerStay(Collider other)
	{
		if (other.gameObject == player) {
			canSeePlayer = false;

			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle (direction, transform.forward);

			if (angle < fieldOfViewAngle * 0.5f) {
				RaycastHit hit;

				if (Physics.Raycast (transform.position + transform.up, direction.normalized, out hit, col.radius)) {
					if (hit.collider.gameObject == player) {
						canSeePlayer = true;
						state = EnemyAi.State.CHASE;
						transform.LookAt (playerMove);
						lastSight = player.transform.position;
					}
				}
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
