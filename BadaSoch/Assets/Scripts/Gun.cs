using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    PlayerMovement playerMovement;
    public Animator anim;
    public TextMeshProUGUI bulletNoText,totalMagzine;
    public Transform gunPoint;
    public int bulletNo;
    public int totalBullet;
    public GameObject bullet;
    public Transform crossHair;
    float shotCounter;
    public float timeBetweenShots;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = gameObject.GetComponentInParent<PlayerMovement>();
        bulletNoText.text = bulletNo.ToString();
        totalMagzine.text = totalBullet.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
        setCrossHair();
        //shoot
        if (Input.GetMouseButton(0) && Time.time >= shotCounter && bulletNo >0 &&  !anim.GetBool("reload") ) {
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
            
            Invoke("reload", 2f);
        }
       
        
    }
    private void shoot()
    {

        if (!anim.GetBool("reload"))
        {
            anim.SetBool("shoot", Input.GetMouseButton(0));
        }
        if (Input.GetMouseButtonUp(0) || bulletNo <=0) {
            anim.SetBool("shoot", false);
        }

    }
    void reload() {
        if (totalBullet > 0)
        {
            var usedBullet = 30 - bulletNo;

            totalBullet = totalBullet - (30 - bulletNo);


            totalMagzine.text = totalBullet.ToString();
            bulletNo = 30;
            bulletNoText.text = bulletNo.ToString();
        }

        else
        {
            totalMagzine.text = "0";
        }
            
            anim.SetBool("reload", false);
        
    }
    void setCrossHair() {
        float x = Mathf.Clamp(playerMovement.pointToLookAt.x, crossHair.position.x - 5, crossHair.position.x+ 5);
        float z = Mathf.Clamp(playerMovement.pointToLookAt.z, crossHair.position.z - 5, crossHair.position.z + 5);
        crossHair.position = new Vector3(x, crossHair.position.y, z);
    }
    
}
