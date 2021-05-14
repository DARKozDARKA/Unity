using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallBeh2 : MonoBehaviour
{

    public int speedX = 50;
    public int speedY = 0;
    double Rotation_X, Rotation_Y, angleY;
    int secret;
    Vector2 Vector;
    void Start()
    {

        // Найти объект по имени
        GameObject go = GameObject.Find("BoomCannon2 Variant");


        // взять его компонент где лежит скорость
        Transform trans = go.GetComponent<Transform>();
        // взять переменную скорости
        float angleY = trans.rotation.eulerAngles.z;

        Rotation_X = Helper.Cos(Convert.ToDouble(angleY));
        Rotation_Y = Helper.Sin(Convert.ToDouble(angleY));
        Vector.x = (float)Rotation_X * 10000;
        Vector.y = (float)Rotation_Y * 10000;



        GetComponent<Rigidbody2D>().AddForce(Vector, 0);

    }


}

