using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [Header("Player Attributes")]
    [SerializeField]
    private float Speed = 8.0f;
    private float rotationSpeed = 30.0f;
    public GameObject laserPrefab;
    public Vector2 movement;
    public Rigidbody2D rb;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //GenerateLevelLimits();
        if (Input.GetMouseButton(0))
        {
            //GameObject laserObject = Instantiate(laserPrefab,transform.position + transform.up, Quaternion.identity) as GameObject;

            //laserObject.transform.SetParent(transform);

            Instantiate(laserPrefab, transform.position, transform.rotation);
        }
    }

    private void FixedUpdate()
    {
        OtherMovement();
        //Movement();

        //if(Input.GetMouseButton(0))
        //{
        //    Shoot();
        //    //Instantiate(laserPrefab, transform.position + new Vector3(0, 1.66f, 0), Quaternion.identity);
        //    // GameObject obj = Instantiate(laserPrefab, firePoint.position, Quaternion.identity);

        //    //obj.transform.SetParent(transform);
        //}
    }

    void Movement()
    {
        float translation = Input.GetAxis("Vertical") * Speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.fixedDeltaTime;
        rotation *= Time.fixedDeltaTime;


        

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x,mousePosition.y - transform.position.y);


        transform.up = direction;

        transform.Translate(new Vector3(0,translation,0));


    }


    void GenerateLevelLimits()
    {
        if(transform.position.x < -9.8f)
        {
            transform.position = new Vector3(9.8f,transform.position.y,0);

        }else if(transform.position.x > 9.8f)
        {
            transform.position = new Vector3(-9.8f,transform.position.y,0);

        }else if(transform.position.y < -5.9f)
        {
            transform.position = new Vector3(transform.position.x,5.9f,0);
        }
        else if (transform.position.y > 5.9f)
        {
            transform.position = new Vector3(transform.position.x, -5.9f, 0);
        }
    }


    public void OtherMovement()
    {
        float translationY = Input.GetAxis("Vertical") * Speed;
        float translationX = Input.GetAxis("Horizontal") * Speed;

        movement.x = Input.GetAxis("Horizontal") * Speed;
        movement.y = Input.GetAxis("Vertical") * Speed;

        transform.Translate(movement * Time.fixedDeltaTime);

        Vector3 positionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDirection = positionMouse - transform.position;

        float angle = Mathf.Atan2(lookDirection.y,lookDirection.x) * Mathf.Rad2Deg - 90.0f;

        //transform.Rotate(0,0,angle);

        rb.rotation = angle;
       

    }

    void Shoot()
    {
        GameObject laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation) as GameObject;
        laser.GetComponent<Rigidbody2D>();

        //transform.Translate(laser.transform.up * Speed * Time.fixedDeltaTime);

        rb.AddForce(firePoint.up * 20.0f,ForceMode2D.Impulse);
    }


}
