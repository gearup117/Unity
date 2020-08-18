using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Attached On UI
public class PickList : MonoBehaviour
{
    public PickUp pickUp;
    public Sprite[] pickAbleList;
    private Image image;
    private bool hasGot;
    // Start is called before the first frame update
    void Start()
    {
        hasGot = false;
        image = gameObject.GetComponent<Image>();
        image.sprite = pickAbleList[Random.Range(0, pickAbleList.Length)];
       // Debug.Log(image.sprite.name);

    }

    // Update is called once per frame
    void Update()
    {
        if (pickUp.playerHas.Contains(image.sprite.name) && hasGot == false)
        {
            //Inrcemnets the var noOfItemsPicked in PickUp
            pickUp.noItemPickedUp += 1;
            //Changes the aplha value after Picking
            var tempColor = image.color;
            tempColor.a = 0.2f;
            image.color = tempColor;
            
            hasGot = true;

        }

    }
}
