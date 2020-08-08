using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Color redColor,blueColor;
    private Color currentColor;
    public Light light;
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
        currentColor = redColor;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentColor == redColor)
        {
            currentColor = blueColor;
            
        }
        else {
            currentColor = redColor;
            
        }
        light.color = currentColor;
        nav.SetDestination(player.position);
       // light.color = Color.Lerp(light.color, currentColor, 1);
        
    }
}
