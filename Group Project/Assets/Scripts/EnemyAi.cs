using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour
{

	private UnityEngine.AI.NavMeshAgent nav;
    private Transform playerMove;
	private GameObject player;
	private Animator anim;
	public SphereCollider col; 
    public enum State
    {
        PATROL,
        CHASE,
        INVESTIGATE
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
    public float chaseSpeed = 2.0f;


    // Variables for Investigate 

    private float investigateTimer;
    public float investigateWait = 10;

    // Variables for Sight
	public float fieldOfViewAngle = 110f;
	public bool canSeePlayer;
	public Vector3 lastSight;



	//public float heightMultiplier;
    //public float sightDist = 10;
    
    

    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

        playerMove = GameObject.FindGameObjectWithTag("Player").transform;
		player = GameObject.FindGameObjectWithTag("Player");

        nav.updatePosition = true;
        nav.updateRotation = true;


        state = EnemyAi.State.PATROL;

        alive = true;

        //heightMultiplier = 1.7f;

        StartCoroutine("FSM");
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
        //nav.SetDestination(lastSight);

        if (investigateTimer < investigateWait)
        {
            investigateTimer += Time.deltaTime;
        }
        else
        {
            investigateTimer = 0;
			// Will have a wander for a time period but for now it goes to patrol
            state = EnemyAi.State.PATROL;
        }
    }

    void Chase()
    {
        nav.speed = chaseSpeed;

        nav.SetDestination(lastSight);

        if(Vector3.Distance(transform.position, lastSight) <= 3 && !canSeePlayer)
        {
            state = EnemyAi.State.INVESTIGATE;
            print("asda");
        }

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
						//transform.LookAt (playerMove);
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
