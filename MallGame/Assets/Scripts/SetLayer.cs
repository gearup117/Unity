﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLayer : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        gameObject.layer = 11;
        Debug.Log(LayerMask.LayerToName(gameObject.layer));
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
