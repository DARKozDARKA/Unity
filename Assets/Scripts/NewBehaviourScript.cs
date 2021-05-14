using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewBehaviourScript : MonoBehaviour
{

    public int speedX = 50;
    public int speedY = 0;
    double Rotation_X, Rotation_Y, angleY;
    int secret;
    bool Flag = false;
    public GameObject[] Objects;
    Vector2 Vector;

    void Start()
    {

        // Найти объект по имени
        GameObject go = GameObject.Find("BoomCannon");


        // взять его компонент где лежит скорость
        Transform trans = go.GetComponent<Transform>();
        // взять переменную скорости
        float angleY = trans.rotation.eulerAngles.z;

        Rotation_X = Helper.Cos(Convert.ToDouble(angleY));
        Rotation_Y = Helper.Sin(Convert.ToDouble(angleY));
        Vector.x = (float)Rotation_X * 20000;
        Vector.y = (float)Rotation_Y * 20000;



        GetComponent<Rigidbody2D>().AddForce(Vector, 0);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (Flag is false)
        {
            Flag = true;
            var me = GetComponent<Transform>().position;

            System.Random rnd = new System.Random();
            int value = rnd.Next(-3, 3);

            me.x += value;
            me.y += value;
            Instantiate(Objects[1], me, Quaternion.identity);
            value = rnd.Next(-3, 3);
            me.x += value;
            me.y += value;
            Instantiate(Objects[1], me, Quaternion.identity);
            value = rnd.Next(-3, 3);
            me.x += value;
            me.y += value;
            Instantiate(Objects[1], me, Quaternion.identity);
            me.x += value;
            me.y += value;
            Instantiate(Objects[1], me, Quaternion.identity);
            me.x += value;
            me.y += value;
            Instantiate(Objects[1], me, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }

}

