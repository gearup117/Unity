using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    public Grocery[] grocery;
    public Transform[] spwanPoints;
    
     void Start()
    {
       
        int noObjs = Random.Range(spwanPoints.Length/2, spwanPoints.Length);
        
        for (int i = 1; i <= noObjs; i++)
        {
            int index = Random.Range(0, spwanPoints.Length);
            if (spwanPoints[index].GetComponent<SpawnPointObj>().isTaken == false)
            {
                Instantiate(grocery[Random.Range(0, grocery.Length)].gameObject, spwanPoints[index].position, spwanPoints[index].rotation);
                spwanPoints[index].GetComponent<SpawnPointObj>().isTaken = true;

            }
            else {
                i--;
            }
        }
    }
}
