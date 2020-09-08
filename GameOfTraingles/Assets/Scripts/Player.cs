using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClip;
    [SerializeField] private AudioSource audioSource;
    private Vector3 mousePosition;
    public static Vector2 dir;
    private Rigidbody2D rb;
    public float speed;
    public float dashSpeed;
    //public float walkSpeed;
    [SerializeField] private float dashRate , fireRate;
    [SerializeField] private GameObject healthBar;
     float nextDash = 0.0f,nextFire = 0.0f;
    [SerializeField] private Animator animator;
    [SerializeField] public  Animator cameraAnimator;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Transform bulletSpawnPoint;
    bool canMove;
    [SerializeField] private int totalBulletCount;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ScoreUpdater.score = totalBulletCount;
        canMove = true;
        //walkSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreUpdater.score = totalBulletCount;
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        dir = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        dir = dir.normalized;
        transform.up = dir;
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire && totalBulletCount > 0)
        {
            nextFire = Time.time + fireRate;
            shoot();
        }

        
        move(speed);
        
    }

    void shoot() {
        
        dir = dir.normalized;
        totalBulletCount--;
        //ScoreUpdater.score--;
        GameObject b = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation) as GameObject;
        b.GetComponent<Rigidbody2D>().AddForce(bulletSpeed * dir , ForceMode2D.Impulse);
        
        
    }

    private void move(float speed)
    {


        Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown("space") && Time.time > nextDash)
        {
            nextDash = Time.time + dashRate;
            canMove = false;
            StartCoroutine(dash());



        }
        else if (canMove)
        {
            move = move.normalized * speed;
            rb.MovePosition((Vector2)transform.position + move * Time.fixedDeltaTime);

        }

    }
    
    private IEnumerator dash()
    {
        audioSource.clip = audioClip[1];
        audioSource.Play();
        var a = dir;
        animator.SetBool("Dash", true);
        cameraAnimator.SetBool("Dash", true);
        
        rb.AddForce(dashSpeed * a, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("Dash", false);
        cameraAnimator.SetBool("Dash", false);
        rb.AddForce(-dashSpeed * a, ForceMode2D.Impulse);
        canMove = true;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "PlayerBullet")
        {
            totalBulletCount++;
            ScoreUpdater.score++;
            Destroy(collision.gameObject);
            audioSource.clip = audioClip[0];
            audioSource.Play();
        }
        if (collision.tag == "Health")
        {
            Cell.health = 1f;
            StartCoroutine(powerUpAnim());
            
            healthBar.GetComponent<Slider>().value = 1f;
            Destroy(collision.gameObject);
            audioSource.clip = audioClip[0];
            audioSource.Play();
        }
        if (collision.tag == "Speed")
        {
            StartCoroutine(powerUpAnim());
            if (speed <= 100f)
            {
                speed += 10f;
            }
            Destroy(collision.gameObject);
            audioSource.clip = audioClip[0];
            audioSource.Play();
        }
        if (collision.tag == "FireRate")
        {
            StartCoroutine(powerUpAnim());
            if (fireRate >= 0.2f)
            {
                fireRate -= 0.05f;
            }
            totalBulletCount += 10;
            Destroy(collision.gameObject);
            audioSource.clip = audioClip[0];
            audioSource.Play();
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bounds")
        {
            Debug.Log("yash");
            rb.velocity = Vector3.zero;

        }
    }

    private IEnumerator  powerUpAnim() {
        animator.SetTrigger("PowerUp");
        this.GetComponent<PolygonCollider2D>().enabled = false;

        yield return new WaitForSeconds(0.1f);
        this.GetComponent<PolygonCollider2D>().enabled = true;

    }
}
