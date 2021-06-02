using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinates : MonoBehaviour
{
    [Header("Coordinates Values")]
    public float x;
    public float y;
    public float z;

    public Coordinates(float x,float y,float z)
    {
        this.x = x;
        this.y = y;
        this.z = -1;
    }


    public Coordinates(Vector3 vector)
    {
        this.x = vector.x;
        this.y = vector.y;
        this.z = vector.z;
    }


    public Vector3 ConvertToVector()
    {
        return new Vector3(x, y, z);
    }



}
