using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    public PlayerMovement crossHair;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.position = new Vector3(crossHair.pointToLookAt.x, transform.position.y, crossHair.pointToLookAt.z);
        var a = new Vector2(crossHair.pointToLookAt.x, crossHair.pointToLookAt.z);
        a.Normalize();
        gameObject.transform.position = new Vector3(player.transform.position.x + 2, 4, player.transform.position.z + 2) * a; 
    }
}
