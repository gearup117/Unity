using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public Vector3 pointToLookAt;
    public Animator anim;
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
        
        look();
        if (!Input.GetMouseButton(0))
        {
            move();
        }
        jump();
        
        shoot();
        applyGravity();
        

    }
    private void shoot() {
        
        anim.SetBool("shoot",Input.GetMouseButton(0));

    }
    private void look() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane playerPlane = new Plane(Vector3.up, Vector3.zero);
        float hitDist;
        if (playerPlane.Raycast(ray, out hitDist))
        {
            pointToLookAt = ray.GetPoint(hitDist);
            Debug.DrawLine(ray.origin, pointToLookAt, Color.blue);
            body.transform.LookAt(new Vector3(pointToLookAt.x, transform.position.y, pointToLookAt.z));
        }


    }

    private void move()
    {
        float tempSpeed;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        animate(x,z);
        Vector3 move =(transform.right) * x + ( transform.forward) * z;
        
        
        
        Debug.Log(x);

        

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) &&  (Input.GetKey(KeyCode.LeftShift)))
        {
            //runleft
            if (Input.GetKey(KeyCode.A)) {
                body.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            //run top
            if (Input.GetKey(KeyCode.W))
            {
                body.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            //run right
            if (Input.GetKey(KeyCode.D))
            {
                body.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            //run down
            if (Input.GetKey(KeyCode.S))
            {
                body.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            anim.SetBool("run", true);
            anim.SetFloat("vertical", 0);
            anim.SetFloat("horizontal", 0);
            tempSpeed = sprint;
            

        }
        else
        {
            anim.SetBool("run", false);
            tempSpeed = speed;
            
        }
        controller.Move(move * tempSpeed * Time.deltaTime);


    }

    private void animate(float x,float z) {
        anim.SetFloat("vertical", z);
        anim.SetFloat("horizontal", x);
        ///Pseudo code
        Vector3 Dir = pointToLookAt - transform.position;
        //IDk how this works
        if (Dir.x < 0 && (Dir.x < -Dir.z))
        {

            anim.SetFloat("vertical", -x);
            anim.SetFloat("horizontal", -z);
        }
        else
        if (Dir.x > 0 && (Dir.x > -Dir.z))
        {
            anim.SetFloat("vertical", x);
            anim.SetFloat("horizontal", z);
        }


        else
        {
            if (Dir.z > 0)
            {
                anim.SetFloat("vertical", z);
                anim.SetFloat("horizontal", x);
            }
            else
             if (Dir.z < 0)
            {
                anim.SetFloat("vertical", -z);
                anim.SetFloat("horizontal", -x);
            }
        }
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
