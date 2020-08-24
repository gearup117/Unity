using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    float xRotation, yRotation;
    [SerializeField] float mouseSensitivity = 100f;
    public GameObject body;
    [SerializeField] CharacterController controller;
    [SerializeField] Transform groundCheck ;
    public float jumpHeight = 3f;
    public LayerMask GroundMask ;
    public float groundRadius = 0.4f;
    public float gravity = -9.81f;
    bool isGrounded, isCollided;
    Vector3 velocity;
    public float speed, sprint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
        look();
        applyGravity();
        

    }
    
    private void look() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane playerPlane = new Plane(Vector3.up, Vector3.zero);
        float hitDist;
        if (playerPlane.Raycast(ray,out hitDist)) {
            Vector3 pointToLookAt = ray.GetPoint(hitDist);
            Debug.DrawLine(ray.origin, pointToLookAt,Color.blue);
            body.transform.LookAt(new Vector3(pointToLookAt.x,transform.position.y,pointToLookAt.z));
        }

    }

    private void move()
    {
        float tempSpeed;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            tempSpeed = sprint;

        }
        else
        {
            tempSpeed = speed;
        }

        controller.Move(move * tempSpeed * Time.deltaTime);
    }

   

    private void applyGravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, GroundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    //jump
    private void jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //Physics formula for jump
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        //Gizmos.DrawWireCube(colliderCheck.position, new Vector3(1.5f, 1f, 1.5f));
    }
}
