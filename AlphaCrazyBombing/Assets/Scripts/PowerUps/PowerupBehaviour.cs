using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehaviour : MonoBehaviour
{

    [Header("PowerUp Attributes")]
    public float Speed = 5.0f;
    public int powerUpId;
    public const float xAxisVAalue = -10.0f;
    public const float yAxisValue = 6.6f;
    float randomNumX;
    float randomNumY;

    float randomNumX2;
    float randomNumY2;

    int randomFunction;


    // Start is called before the first frame update
    void Awake()
    {
        //Movement();

        //Movement();

         randomNumX = Random.Range(-10.0f, 10.0f);
         randomNumY = Random.Range(-6.6f, 6.6f);

         randomNumX2 = Random.Range(-7.5f, 7.5f);
         randomNumY2 = Random.Range(-3.7f, 3.7f);

        transform.position = new Vector3(randomNumX,randomNumY,0);

        randomFunction = Random.Range(0,3);

        switch(randomFunction)
        {
            case 0:
                SetXRandomPosition();
                break;
            case 1:
                SetYRandomPosition();
                break;
            case 2:
                SetXRandomPosition();
                break;
            case 3:
                SetYRandomPosition();
                break;
        }


        //if (transform.position.x > -10.0f && transform.position.x <= 10.0f && transform.position.y > )
        //{
        //    this.transform.position = new Vector3(xAxisVAalue, randomNumY2, 0);

        //}

        //if (transform.position.y < 6.6f && transform.position.y >= -6.6f)
        //{
        //    this.transform.position = new Vector3(randomNumX2, yAxisValue, 0);
        //}


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Movement();
        //transform.Translate(Vector3.right * Speed * Time.deltaTime);

        //if (transform.position.x < 10.0f)
        //{
        //    transform.Translate(Vector3.right * Speed * Time.deltaTime);
        //}

        //if (transform.position.y > -6.6f)
        //{
        //    transform.Translate(Vector3.down * Speed * Time.deltaTime);
        //}

        if(randomFunction == 0 || randomFunction == 2)
        {
            MoveXAxis();

        } else if(randomFunction == 1 || randomFunction == 3)
        {
            transform.Translate(Vector3.down * Speed * Time.deltaTime);
        }


    }

    void Movement()
    {
        float positiveRandomY = Random.Range(-3.8f,3.8f);
        float positiveRandomX = Random.Range(-10f, 10f);


        //if(transform.position.y > -6.8f)
        //{
        //    transform.Translate(Vector3.down * Speed * Time.deltaTime);

        //} 


        //if (transform.position.x < 10.0f)
        //{
        //    transform.position = new Vector3(-10.0f, positiveRandomY, 0);
        //    transform.position += new Vector3(1, 0, 0) * Speed * Time.deltaTime;

        //}


        //transform.position += new Vector3(1, 0, 0) * Speed * Time.deltaTime;

        if(transform.position.x > -10.0f && transform.position.x <= 10.0f)
        {
            Destroy(this.gameObject);
        }
        else
        {
            transform.position = new Vector3(-10.0f, positiveRandomY, 0);
        }


    }


    void SetXRandomPosition()
    {
        if (transform.position.x > -10.0f && transform.position.x <= 10.0f)
        {
            this.transform.position = new Vector3(xAxisVAalue, randomNumY2, 0);

        }
    }

    void SetYRandomPosition()
    {

        if (transform.position.y < 6.6f && transform.position.y >= -6.6f)
        {
            this.transform.position = new Vector3(randomNumX2, yAxisValue, 0);
        }
    }

    void MoveXAxis()
    {
        if (transform.position.x >= -10.0f && transform.position.x <= 10.0f)
        {

            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
    }

}
