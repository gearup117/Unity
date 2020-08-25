using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public int patrolPointIndex;
    public float viewRadius;
    bool sawPlayer,reachedDest;
    public Transform[] patrolPoints;
    public LayerMask playerMask;
    public GameObject blood,bloodPoint;
    public float health;
    public NavMeshAgent navMesh;
    public Animator anim;
    bool canWalk;
    // Start is called before the first frame update
    void Start()
    {
        patrolPointIndex = Random.Range(0, patrolPoints.Length);
        
        canWalk = false;
        Invoke("walk", Random.Range(3f, 5f));
    }
    void walk()
    {
        patrol();
        canWalk = true;
        anim.SetBool("Walk", true);
    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            
            navMesh.speed = 0;
            
            anim.SetBool("Death", true);
            Invoke("death", 2f);
        }

        if (sawPlayer == false)
        {
            sawPlayer = Physics.CheckSphere(transform.position, viewRadius, playerMask);
        }
        
        if (canWalk && health > 0)
        {
            
            if (sawPlayer)
            {
                sawPlayer = true;
                var player = GameObject.FindGameObjectWithTag("Player").transform;
                navMesh.speed = 4f;
                navMesh.SetDestination(player.position);
            }
            else
            {
                patrol();
            }
        }
        

    }
    void setNewPatrolPoint() {
        patrolPointIndex = Random.Range(0, patrolPoints.Length);
    }
    void patrol() {
        if (transform.position.x == patrolPoints[patrolPointIndex].position.x && transform.position.z == patrolPoints[patrolPointIndex].position.z)
        {
            Debug.Log("Reached");
            setNewPatrolPoint();

        }
        navMesh.SetDestination(patrolPoints[patrolPointIndex].position);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewRadius);
        //Gizmos.DrawWireCube(colliderCheck.position, new Vector3(1.5f, 1f, 1.5f));
    }
    
    
    void death()
    {
        
        Destroy(this.gameObject);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet") {
            Destroy(collision.gameObject);
            Instantiate(blood, bloodPoint.transform.position,bloodPoint.transform.rotation);
            health -= 1f;
            
        }
    }
}
