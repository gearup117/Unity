using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twinkel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private SpriteRenderer sr;
    float minLerp = 0;
    float maxLerp = 255;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sr.color = new Color(255, 255, 255, 0);
    }
}
