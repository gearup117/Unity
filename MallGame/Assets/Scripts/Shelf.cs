using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    public Grocery grocery;
    public Transform[] spwanPoints;
    
     void Start()
    {
       
        int noObjs = Random.Range(1, spwanPoints.Length+1);
        
        for (int i = 1; i <= noObjs; i++)
        {
            int index = Random.Range(0, spwanPoints.Length);
            Instantiate(grocery.gameObject, spwanPoints[index].position, spwanPoints[index].rotation);
        }
    }
}
