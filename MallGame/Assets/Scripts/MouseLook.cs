using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 100f;
    [SerializeField] GameObject playerBody;
    float xRotation,yRotation;
    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        if (Input.GetMouseButton(1))
        {
            //transform.localRotation = Quaternion.Euler(transform.rotation.x, -170f, 0f);
            //transform.Rotate(transform.rotation.x, -170f, transform.rotation.z);
            freeRotate(mouseX,mouseY);
           
        }
        else {
           
            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.transform.Rotate(new Vector3(0, 1f * mouseX, 0));

        }
       
        
    }
    void freeRotate(float mouseX,float mouseY) {
        //xRotation -= transform.rotation.x + mouseY;

       // xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        //yRotation  +=  mouseX;
        //yRotation = Mathf.Clamp(yRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, -170f, 0f);
    }
}
