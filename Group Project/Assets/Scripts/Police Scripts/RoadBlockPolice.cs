using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoadBlockPolice : MonoBehaviour {

    private UnityEngine.AI.NavMeshAgent nav;
    private Transform playerMove;
    private GameObject player;
    private Animator PoliceAnim;
    private PlayerCamera playerHealth;
    private VictimDeadCheck victimDead;


    private bool canSeePlayer;
    public SphereCollider col;
    public float fieldOfViewAngle = 110f;
    Vector3 previousSighting;


    public float chaseSpeed;

    // Use this for initialization
    void Start () {

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
     

    }

    void Chase()
    {

        nav.speed = chaseSpeed;
        nav.SetDestination(GameObject.FindGameObjectWithTag("Police").GetComponent<EnemyAi>().previousSighting);
        PoliceAnim.Play("Run");
        transform.LookAt(playerMove);
       
        if (Vector3.Distance(transform.position, player.transform.position) <= 3)
        {
           // if (playerHealth.health == 0)
           // {
                Arrest();
           //   
           // }
           // else
           // {
           //     playerHealth.TakeDamage(1);
           // }
        }
        else if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Police").GetComponent<EnemyAi>().previousSighting) <= 3 && !GameObject.FindGameObjectWithTag("Police").GetComponent<EnemyAi>().canSeePlayer)
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
