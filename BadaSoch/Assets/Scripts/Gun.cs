using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    
    public Animator anim;
    public TextMeshProUGUI bulletNoText,totalMagzine;
    public Transform gunPoint;
    public int bulletNo;
    public int totalBullet;
    public GameObject bullet;
    float shotCounter;
    public float timeBetweenShots;
    // Start is called before the first frame update
    void Start()
    {
        bulletNoText.text = bulletNo.ToString();
        totalMagzine.text = totalBullet.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && Time.time >= shotCounter && bulletNo >0 && !anim.GetBool("reload") ) {
            shotCounter = Time.time + timeBetweenShots;
            bulletNo--;
            bulletNoText.text = bulletNo.ToString();
            var a = Instantiate(bullet.gameObject, new Vector3(gunPoint.position.x +Random.Range(-0.2f,0.2f),gunPoint.position.y,gunPoint.position.z), gunPoint.rotation);
        }
        if (bulletNo <= 0 || Input.GetKeyDown(KeyCode.R)) {
            anim.SetBool("run", false);
            anim.SetFloat("vertical", 0f);
            anim.SetFloat("horizontal", 0f);
            anim.SetBool("reload", true);
            
            Invoke("resetMagzine", 2f);
        }
       
        
    }
    void resetMagzine() {
        var usedBullet = 30 - bulletNo;

        totalBullet = totalBullet - (30 - bulletNo);
        totalMagzine.text = totalBullet.ToString();
        bulletNo = 30;
        bulletNoText.text = bulletNo.ToString();
        anim.SetBool("reload", false);
    }
}
