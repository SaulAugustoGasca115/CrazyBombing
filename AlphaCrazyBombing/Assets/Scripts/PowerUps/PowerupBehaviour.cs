using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehaviour : MonoBehaviour
{

    [Header("PowerUp Attributes")]
    public float Speed = 5.0f;
    public int powerUpId;
    public  float xAxisValue = 23.0f;
    public  float yAxisValue = 14.0f;
    float randomNumX;
    float randomNumY;

    float randomNumX2;
    float randomNumY2;

    int randomFunction;


    // Start is called before the first frame update
    void Awake()
    {
        

         randomNumX = Random.Range(-xAxisValue,xAxisValue);
         randomNumY = Random.Range(-yAxisValue, yAxisValue);

         randomNumX2 = Random.Range(-19.5f, 19.5f);
         randomNumY2 = Random.Range(-10.0f, 10.0f);

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


        


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if(randomFunction == 0 || randomFunction == 2)
        {
            MoveXAxis();

        } else if(randomFunction == 1 || randomFunction == 3)
        {
            MoveYAxis();
        }


        if(transform.position.x >= 23.0f || transform.position.y <= -14.0f)
        {
            Destroy(this.gameObject);
        }



    }

    //void Movement()
    //{
    //    float positiveRandomY = Random.Range(-3.8f,3.8f);
    //    float positiveRandomX = Random.Range(-10f, 10f);


    //    if(transform.position.x > -10.0f && transform.position.x <= 10.0f)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //    else
    //    {
    //        transform.position = new Vector3(-10.0f, positiveRandomY, 0);
    //    }


    //}


    void SetXRandomPosition()
    {
        if (transform.position.x >= -xAxisValue && transform.position.x < xAxisValue)
        {
            this.transform.position = new Vector3(-xAxisValue, randomNumY2, 0);

        }
    }

    void SetYRandomPosition()
    {

        if (transform.position.y < yAxisValue && transform.position.y >= -yAxisValue)
        {
            this.transform.position = new Vector3(randomNumX2, yAxisValue, 0);
        }
    }

    void MoveXAxis()
    {
        if (transform.position.x >= -xAxisValue && transform.position.x <= xAxisValue)
        {

            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
    }

    void MoveYAxis()
    {
        if (transform.position.y <= yAxisValue && transform.position.y >= -yAxisValue)
        {
            transform.Translate(Vector3.down * Speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerMove player = other.GetComponent<PlayerMove>();

            if(player != null)
            {
                player.TripleShootPowerupOn();
               

                
            }

            Destroy(this.gameObject);

        }
    }



}
