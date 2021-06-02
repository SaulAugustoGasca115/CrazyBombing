using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnMathematics
{
    //Normal Calculations
    public static float Square(float value)
    {
        return value * value;
    }

    public static float GetDistance(Coordinates vector1,Coordinates vector2)
    {
        float distance = Square(vector1.x - vector2.x) + Square(vector1.y - vector2.y) + Square(vector1.z - vector2.z);

        return Mathf.Sqrt(distance);
    }

    public static Coordinates GetNormal(Coordinates vector)
    {
        //float xValue = vector.x / GetDistance(new Coordinates(0,0,0),new Coordinates());
        //float yValue = vector.y / GetDistance(new Coordinates(0, 0, 0), new Coordinates(vector));
        //float zValue = vector.z / GetDistance(new Coordinates(0,0,0),new Coordinates(vector));

        float length = GetDistance(new Coordinates(0,0,0),vector);

        vector.x /= length;
        vector.y /= length;
        vector.z /= length;


        return vector;
    }

}
