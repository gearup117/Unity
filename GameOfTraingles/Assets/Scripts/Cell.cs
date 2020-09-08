using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cell : MonoBehaviour
{
    [SerializeField] GameObject healthBar;
    public static float health;
    [SerializeField] GameObject[] consumables;
    [SerializeField] private Vector2 consumableSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        health = 1;
        healthBar.GetComponent<Slider>().value = health;
        StartCoroutine(spawnConsumables());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Retry");
        }
        
        //ebug.Log("yash");   
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") {
            
            health -= collision.gameObject.GetComponent<Enemy>().damage;
            healthBar.GetComponent<Slider>().value = health;
            Destroy(collision.gameObject);
        }
    }
    IEnumerator  spawnConsumables() {

        while (health >= 0)
        {
            var a = Instantiate(consumables[Random.Range(0, consumables.Length)], transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            var direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            direction = direction.normalized;
            a.GetComponent<Rigidbody2D>().AddForce(direction * 10, ForceMode2D.Impulse);
            yield return new WaitForSeconds(Random.Range(consumableSpawnTime.x,consumableSpawnTime.y));
        }
    }
    
}
