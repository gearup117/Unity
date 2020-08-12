using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Attacked On Player
public class PickUp : MonoBehaviour
{
    //Go to Gare UI text
    public GameObject tm,gate;
    public int noItemPickedUp = 0;
    public Transform[] dropPoint;
    public float pickUpDis;
    public float scaleAmount;
    public LayerMask PickAble;
    GameObject selected = null;
    private bool isPickedUp;
    public List<string> playerHas = new List<string>();
    void Update()
    { 
        //Displays the Go to Text  
        if (noItemPickedUp == 11) {
            tm.active = true;
            gate.active = true;
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //Debug.DrawRay(transform.position, Vector3.forward * 20 ,Color.green);
        if (Physics.Raycast(ray, out hit, pickUpDis, PickAble))
        {
            selected = hit.transform.gameObject;

            selected.GetComponent<HighLightObjects>().isMouseOver = true;
            //scaleRef = selected.transform.localScale;
            var obj = hit.transform;
           
            //Hovering of mouse over the object
            //obj.localScale = new Vector3(scaleAmount, scaleAmount, scaleAmount);
            if (Input.GetMouseButtonDown(0)) {
                selected.GetComponent<HighLightObjects>().isPickedUp = true;
                //Adds to picked up list
                playerHas.Add(selected.tag);
                
                   pickUp(selected);
            }
            
            
        }
        else {
            //Resets the obj
            if (selected && !isPickedUp) {

                selected.GetComponent<HighLightObjects>().isMouseOver = false;
               // Debug.Log(scaleRef);
               // selected.transform.localScale = new Vector3(1,1,1);
            }   
        }
        
        Debug.DrawRay(ray.origin, Vector3.forward * pickUpDis, Color.green);



    }
    void pickUp(GameObject obj) {
        
        obj.GetComponent<CapsuleCollider>().enabled = false;
        
        obj.transform.SetParent(gameObject.transform);
        obj.transform.position = dropPoint[Random.Range(0,dropPoint.Length)].position;
        //obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}
