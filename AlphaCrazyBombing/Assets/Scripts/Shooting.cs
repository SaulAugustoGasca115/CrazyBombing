using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
         Instantiate(bulletPrefab,firePoint.position,Quaternion.identity);
        //Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        //rb.AddForce(firePoint.up * 20.0f,ForceMode2D.Impulse);

        //bulletPrefab.transform.Translate(laser.transform.up * 20.0f * Time.deltaTime);



    }

}
