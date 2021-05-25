using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaseMovement : MonoBehaviour
{

    [Header("Laser Attributes")]
    [SerializeField]
    private float Speed = 15.0f;
    //public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LaserMovement();
    }

    void LaserMovement()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);


        if(transform.position.y > 5.65f)
        {
            Destroy(this.gameObject);
        }

    }

}
