using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;



public static class Helper
{
    public static double Sin(double degrees) => Math.Sin(degrees * Math.PI / 180.0);
    public static double Cos(double degrees) => Math.Cos(degrees * Math.PI / 180.0);
    public static double Tan(double degrees) => Math.Tan(degrees * Math.PI / 180.0);
}
public class BoomCannon : MonoBehaviour
{
    public GameObject[] Objects;

    double Rotation_X, Rotation_Y, angleY;
    public Vector2 Vector;
    public bool Reverse = false;
    public bool Second = false;
    int rotate = 10;
    private bool Flag = false;
    private bool Flag2 = false;
    public float timeRemaining = 0f;
    int secret = 13;



    // Start is called before the first frame update
    // Update is called once per frame

    void Update()

        
    {


        if (Reverse is false)
        {
            
 

            var me = GetComponent<Transform>();
            if (me.rotation[2] >= 0.1f)
            {
                rotate = -10;
            }
            if ((me.rotation[2] <= -0.15f))
            {
                rotate = 10;
            }







            transform.Rotate(new Vector3(0, 0, rotate) * Time.deltaTime);
            angleY = transform.rotation.eulerAngles.z;
            Rotation_X = Helper.Cos(Convert.ToDouble(angleY));
            Rotation_Y = Helper.Sin(Convert.ToDouble(angleY));

            



            if (timeRemaining <= 0f)
            {
                timeRemaining = 4f;
                Vector.x = (float)Rotation_X;
                Vector.y = (float)Rotation_Y;
                Instantiate(Objects[0], new Vector2(me.position.x + 16, me.position.y + Vector.y * 15), Quaternion.identity);
            }
            else
            {
                timeRemaining -= Time.deltaTime;
            }

        }

        else
        {

            if (Second is true & Flag2 is false)
            {
                timeRemaining = 1f;
                Flag2 = true;
                secret = 13;
            }


            if (Flag == false)
            {
                rotate = -10;
                Flag = true;
            }


            var me = GetComponent<Transform>();
            
            if ((me.rotation[3] >= 0.1f) & (me.rotation[2] >= 0f))
            {
                rotate = secret;
            }
            if ((me.rotation[3] >= 0.1f & me.rotation[2] < 0f))
            {
                rotate = - secret;
                
            }

            transform.Rotate(new Vector3(0, 0, rotate) * Time.deltaTime);

            angleY = transform.rotation.eulerAngles.z;
            Rotation_X = Helper.Cos(Convert.ToDouble(angleY));
            Rotation_Y = Helper.Sin(Convert.ToDouble(angleY));


            if (timeRemaining <= 0f)
            {
                timeRemaining = 3f;
                Vector.x = (float)Rotation_X;
                Vector.y = (float)Rotation_Y;
                Instantiate(Objects[0], new Vector2(me.position.x - 12, me.position.y + Vector.y * 15), Quaternion.identity);
            }
            else
            {
                timeRemaining -= Time.deltaTime;
            }

  
        }
        



    }

}


