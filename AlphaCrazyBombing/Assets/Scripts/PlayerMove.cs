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

    [Header("Shoot Coolddown")]
    public float fireRate = 0.15f;
    public float canFire = 0.0f;

    [Header("Triple Shoot")]
    public GameObject tripleShootPrefab;
    public bool activateTripleShoot = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void FixedUpdate()
    {
        AffineMovement();

        GenerateLevelLimits();
        if (Input.GetMouseButton(0))
        {

            //Instantiate(laserPrefab, transform.position, transform.rotation);
            ShootBehaviour();
        }

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


    public void AffineMovement()
    {
        float translationY = Input.GetAxis("Vertical") * Speed;
        float translationX = Input.GetAxis("Horizontal") * Speed;

        movement.x = Input.GetAxis("Horizontal") * Speed;
        movement.y = Input.GetAxis("Vertical") * Speed;

        

        Vector3 positionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDirection = positionMouse - transform.position;

        if(Vector2.Distance(positionMouse,transform.position) > 3.0f)
        {
            transform.Translate(movement * Time.fixedDeltaTime);

            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;

            //transform.Rotate(0,0,angle);

            rb.rotation = angle;
        }

        
       

    }

    void ShootBehaviour()
    {
        if(Time.time > canFire)
        {

            if(activateTripleShoot == true)
            {
                //triple shoot
                Instantiate(tripleShootPrefab, transform.position, transform.rotation);
            }
            else
            {
                //singel shoot
                Instantiate(laserPrefab, transform.position, transform.rotation);
            }

            

            canFire = Time.time + fireRate;
        }
    }

    


}
