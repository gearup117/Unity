using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickList : MonoBehaviour
{
    public Sprite[] pickAbleList;
    // Start is called before the first frame update
    void Start()
    {
        var image = gameObject.GetComponent<Image>();
        image.sprite = pickAbleList[Random.Range(0, pickAbleList.Length)];
        Debug.Log(image.sprite.name);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
