using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float pickUpDis;
    public float scaleAmount;
    public LayerMask PickAble;
    GameObject selected = null;
   // Vector3 scaleRef = new Vector3(0.1f,0.1f,0.1f);
    // Update is called once per frame

    void Update()
    {
         
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //Debug.DrawRay(transform.position, Vector3.forward * 20 ,Color.green);
        if (Physics.Raycast(ray, out hit, pickUpDis, PickAble))
        {
            selected = hit.transform.gameObject;
            //scaleRef = selected.transform.localScale;
            var obj = hit.transform;
           
            obj.localScale = new Vector3(scaleAmount, scaleAmount, scaleAmount);
            // Debug.Log(hit.transform.gameObject.name);
            
        }
        else {
            if (selected) {

               // Debug.Log(scaleRef);
                selected.transform.localScale = new Vector3(1,1,1);
            }   
        }
        
        Debug.DrawRay(ray.origin, Vector3.forward * pickUpDis, Color.green);



    }
}
