using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent nav;
    private Transform player;
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
         nav.updateUpAxis = false;
       // nav.updateRotation = false;
       
        
    }
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(player.position);
    }
}
