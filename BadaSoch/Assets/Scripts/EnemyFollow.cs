using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public float health;
    public NavMeshAgent navMesh;
    public Animator anim;
    bool canWalk;
    // Start is called before the first frame update
    void Start()
    {
        canWalk = false;
        Invoke("walk", Random.Range(3f, 5f));
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            navMesh.speed = 0;
            anim.SetBool("Death", true);
            Invoke("death", 2f);
        }
        
        if (canWalk && health > 0) {
            var player = GameObject.FindGameObjectWithTag("Player").transform;
            navMesh.SetDestination(player.position);
        }

    }

    void walk() {
        canWalk = true;
        anim.SetBool("Walk", true);
    }
    void death()
    {
        
        Destroy(this.gameObject);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet") {
            Destroy(collision.gameObject);
            health -= 1f;
            
        }
    }
}
