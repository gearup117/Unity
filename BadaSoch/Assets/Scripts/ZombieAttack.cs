using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAttack : MonoBehaviour
{
    Vector2 enemyPosi;
    //public NavMesh navMesh;
    // Start is called before the first frame update
    void Start()
    {
        enemyPosi = new Vector2(transform.position.x, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        var player = GameObject.FindGameObjectWithTag("Player").transform;
        var dist = new Vector2(enemyPosi.x - player.position.x,enemyPosi.y - player.position.z);
        //if(Mathf.Abs(dist))
        
    }
}
