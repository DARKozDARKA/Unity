using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBall : MonoBehaviour
{

    public float Rotation_X;
    public float Rotation_Y;
    int secret;
    Vector2 Vector;
    // Start is called before the first frame update
    void Start()
    {
        Vector = Random.insideUnitCircle;
        Vector.x = Vector.x * 5000 * Random.Range(1,10) * 0.5f;
        Vector.y = Vector.y * 5000 * Random.Range(1, 10) * 0.5f;


        GetComponent<Rigidbody2D>().AddForce(Vector, 0);
    }

    // Update is called once per frame
}
