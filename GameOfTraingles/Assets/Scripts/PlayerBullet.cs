﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Rotate(new Vector3(0, 0, 20));
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bounds")
        {
            Destroy(gameObject);
        }
    }
}
