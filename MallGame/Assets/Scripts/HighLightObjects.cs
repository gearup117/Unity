using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLightObjects : MonoBehaviour
{
    public  bool isMouseOver;
    private  Vector3 scale;
    public bool isPickedUp;
    // Start is called before the first frame update
    void Start()
    {
        isMouseOver = false;
        scale = gameObject.transform.localScale;
        isPickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPickedUp)
        {
            if (isMouseOver)
            {
                gameObject.transform.localScale = scale * 1.5f;
            }
            else
            {
                gameObject.transform.localScale = scale;
            }
        }
        else {
            gameObject.transform.localScale = scale / 2;
        }
    }
    public  void highLight() {
        
        
    }
}
