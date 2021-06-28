using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveTest : MonoBehaviour
{

    public float speed = 10.0f;
    public float rotationSpeed = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxisRaw("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        //transform.Translate(0,translation,0);

        transform.position = OwnMathematics.OwnTranslate(new Coordinates(transform.position),new Coordinates(transform.up),new Coordinates(0,translation,0)).ConvertToVector();

        transform.up = OwnMathematics.Rotate(new Coordinates(transform.up),rotation * Mathf.PI / 180,true).ConvertToVector();
    }
}
