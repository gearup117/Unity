using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    public GameObject gate;
    public Timer timer;
    public GameObject gameOverOverLay;
    public LoadScene loadScene;
    [SerializeField] CharacterController controller;
    [SerializeField] Transform groundCheck,colliderCheck;
    public float jumpHeight = 3f;
   public LayerMask GroundMask,EnemyMask,GateMask;
    public float groundRadius = 0.4f;
    public float gravity = -9.81f;
    bool isGrounded,isCollided;
    Vector3 velocity;
    public float speed,sprint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
        //jump();
        applyGravity();
        checkCollision();
        
    }

    private void move() {
        float tempSpeed;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            tempSpeed = sprint;
            
        }
        else {
            tempSpeed = speed;
        }
        
        controller.Move(move * tempSpeed * Time.deltaTime);
    }
    public void checkCollision() {
        //checks collision with enemy
        isCollided = Physics.CheckBox(colliderCheck.position, new Vector3(1.5f, 1f, 1.5f),Quaternion.Euler(0,0,0),EnemyMask);
        if (isCollided) {
            retry();
        }
        //Checks collision with gate
        isCollided = Physics.CheckBox(colliderCheck.position, new Vector3(1.5f, 1f, 1.5f), Quaternion.Euler(0, 0, 0), GateMask);
        if (isCollided) {
            timer.reachedGate = true;
            retry();
        }
    }
    public void retry() {
        timer.pauseTimer = true;
        gameOverOverLay.active = true;
        gate.GetComponent<TextMeshProUGUI>().text = "";
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //Pauses the Game
        Time.timeScale = 0;
        
    }
    
    private void applyGravity() {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, GroundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    //jump
    private void jump() {
        if (Input.GetButtonDown("Jump") && isGrounded) {
            //Physics formula for jump
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        Gizmos.DrawWireCube(colliderCheck.position, new Vector3(1.5f, 1f, 1.5f));
    }
    
}
