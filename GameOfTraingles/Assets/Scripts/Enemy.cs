using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClip;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject target;
    [SerializeField] private float Rotatespeed;
    public static  float  moveSpeed;
    [SerializeField] private float hitCount;
    [SerializeField] private GameObject bulletSpawn;
    [SerializeField] private int noOfBulletSpawn;
    private float health;
    
    public  float damage;
    public float tempDamage;
    [SerializeField] GameObject particleSystem;
    // Start is called before the first frame update
    private void Awake()
    {
        Rotatespeed = Random.RandomRange(-30, 30);
       
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(timeAfterAwake());
        health = 1f;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.RotateAround(target.transform.position, new Vector3(0,0,1), Rotatespeed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        if (health <= 0) {
           
            while (noOfBulletSpawn > 0)
            {
                Instantiate(particleSystem, transform.position, transform.rotation);
                var a = Instantiate(bulletSpawn, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                a.transform.localScale = new Vector3(3f, 3f, 0);
                noOfBulletSpawn--;
            }
           // StartCoroutine(playDestroySound());
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "PlayerBullet") {
            health = health - (1 / hitCount);
            
            Destroy(collision.gameObject);
        }
    }
    IEnumerator timeAfterAwake() {
        yield return new WaitForSeconds(2f);
        damage = tempDamage;
        //Debug.Log(tempDamage);
    }
    IEnumerator playDestroySound() {
        audioSource.clip = audioClip[0];
        audioSource.Play();
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
