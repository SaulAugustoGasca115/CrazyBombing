using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [Header("Player Attributes")]
    [SerializeField]
    public float Speed = 8.0f;
    public float rotationSpeed = 30.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        GenerateLevelLimits();
    }

    void Movement()
    {
        float translation = Input.GetAxis("Vertical") * Speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;


        

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


}
