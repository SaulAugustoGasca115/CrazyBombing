using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnMathematics
{
    //Normal Calculations

    //función para obtener el cuadrado de un número
    public static float Square(float value)
    {
        return value * value;
    }


    //función para obtener la la distancia
    public static float GetDistance(Coordinates vector1,Coordinates vector2)
    {
        float distance = Square(vector1.x - vector2.x) + Square(vector1.y - vector2.y) + Square(vector1.z - vector2.z);

        return Mathf.Sqrt(distance);
    }


    //función para obtener la normal
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


    //función para obtener el producto punto 
    public static float DotProduct(Coordinates vector1,Coordinates vector2)
    {
        float product = (vector1.x * vector2.x) + (vector1.y * vector2.y) + (vector1.z * vector2.z);

        return product;
    }


    //función para obtener el ángulo del producto punto
    public static float GetAngle(Coordinates vector1,Coordinates vector2)
    {
        float dotDivided = DotProduct(vector1,vector2) / (GetDistance(new Coordinates(0,0,0),vector1) * GetDistance(new Coordinates(0,0,0),vector2)); //radians: to degress * 180/ PI


        return Mathf.Acos(dotDivided);
    }

    //función para obtener la rotación en radianes
    public static Coordinates Rotate(Coordinates vector,float angle,bool clockwise) // in radians
    {
        if(clockwise)
        {
            angle = 2 * Mathf.PI - angle; // 2 * Pi = 360 grados 
        }


        float xValue = vector.x * Mathf.Cos(angle) - vector.y * Mathf.Sin(angle);

        float yValue = vector.x * Mathf.Sin(angle) + vector.y * Mathf.Cos(angle);

        return new Coordinates(xValue,yValue,0.0f);
    }

    //función para crear mi propio translate
    public static Coordinates OwnTranslate(Coordinates position,Coordinates facing,Coordinates vector)
    {

        if(GetDistance(new Coordinates(0,0,0),vector) <= 0)
        {
            return position;
        }

        float angle = GetAngle(vector,facing);

        float worldAngle = GetAngle(vector,new Coordinates(0,1,0));

        bool clockwise = false;

        if(GetCrossProduct(vector,facing).z < 0)
        {
            clockwise = true;
        }

        vector = Rotate(vector,angle + worldAngle,clockwise);

        float xValue = position.x + vector.x;
        float yValue = position.y + vector.y;
        float zValue = position.z + vector.z;

        return new Coordinates(xValue, yValue, zValue);
    }


    public static Coordinates GetCrossProduct(Coordinates vector1,Coordinates vector2)
    {
        float xVaue = vector1.y * vector2.z - vector1.z * vector2.y;
        float yValue = vector1.z * vector2.x - vector1.x * vector2.z;
        float zValue = vector1.x * vector2.y - vector1.y * vector2.x;

        return new Coordinates(xVaue,yValue,zValue);
    }



}
