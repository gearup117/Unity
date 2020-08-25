using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform gunPoint;

    public GameObject bullet;
    float shotCounter;
    public float timeBetweenShots;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= shotCounter ) {
            shotCounter = Time.time + timeBetweenShots;
            var a = Instantiate(bullet.gameObject, new Vector3(gunPoint.position.x +Random.Range(-0.2f,0.2f),gunPoint.position.y,gunPoint.position.z), gunPoint.rotation);
        }
    }
}
