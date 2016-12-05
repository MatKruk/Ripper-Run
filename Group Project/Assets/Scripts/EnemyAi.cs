using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent nav;
    private Transform player;
    public GameObject enemy;
	Animator anim;

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
    public float patrolSpeed = 0.5f;
    public float patrolWaitTime = 1f;
    public float patrolTimer;

    // Variables for Chase
    public float chaseSpeed = 1f;


    // Variables for Investigate 

    private float investigateTimer;
    public float investigateWait = 10;

    // Variables for Sight
    public float heightMultiplier;
    public float sightDist = 10;

    public Vector3 lastSight;
    public bool canSee;

    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

        player = GameObject.FindGameObjectWithTag("Player").transform;

        nav.updatePosition = true;
        nav.updateRotation = true;


        state = EnemyAi.State.PATROL;

        alive = true;

        heightMultiplier = 1.7f;

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

        if(Vector3.Distance(transform.position, lastSight) <= 3 && !canSee)
        {
            state = EnemyAi.State.INVESTIGATE;
            print("asda");
        }

    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, transform.forward * sightDist, Color.blue);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (transform.forward + transform.right).normalized * sightDist, Color.blue);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (transform.forward - transform.right).normalized * sightDist, Color.blue);

        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, transform.forward, out hit, sightDist))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                state = EnemyAi.State.CHASE;
                transform.LookAt(player);
                lastSight = player.transform.position;
                canSee = true;
            }
            else
            {
                canSee = false;
            }

        }

        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (transform.forward + transform.right).normalized, out hit, sightDist))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                state = EnemyAi.State.CHASE;
                transform.LookAt(player);
                lastSight = player.transform.position;
                canSee = true;
            }
            else
            {
                canSee = false;
            }


        }

        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (transform.forward - transform.right).normalized, out hit, sightDist))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                state = EnemyAi.State.CHASE;
                transform.LookAt(player);
                lastSight = player.transform.position;
                canSee = true;
            }
            else
            {
                canSee = false;
            }



        }

    }

}
