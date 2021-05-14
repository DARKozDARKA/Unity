using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuild : MonoBehaviour
{
    // Start is called before the first frame update
    private bool Flag = false;
    float FirstCoordX;
    float FirstCoordY;
    int column;
    int row;
    UnityEngine.Transform me;
    public GameObject[] Objects;
    public float lol;
    public bool Reverse = false;
    Vector3 MousePosition;

    // Update is called once per frame
    public void Attack() 
    {
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Instantiate(Objects[0], new Vector2(MousePosition.x, MousePosition.y), Quaternion.identity);
    }

    private void Start()
    {
        me = GetComponent<Transform>();
        var me2 = GetComponent<SpriteRenderer>();

        Flag = true;
        FirstCoordX = me.position.x;
        FirstCoordY = me.position.y;
        me2.enabled = false;


        for (int i = 0; i < 17; i++)
        {
            if (i % 2 == 0)
            {
                for (int k = 0; k < 4; k++)
                {
                    Instantiate(Objects[0], new Vector2(FirstCoordX + k * 4.02f, FirstCoordY + i*2.02f), Quaternion.identity);
                }
            }
            else
            {
                for (int k = 0; k < 5; k++)
                {
                    Instantiate(Objects[0], new Vector2((FirstCoordX + k * 4.02f) - 2f, FirstCoordY + i*2.02f), Quaternion.identity);
                }
            }
            
            if (i == 16)
            {
                Instantiate(Objects[1], new Vector2(FirstCoordX + lol, FirstCoordY + i * 2.02f), Quaternion.identity);
                if (Reverse is false)
                {
                    Instantiate(Objects[2], new Vector2(FirstCoordX + lol + 31, FirstCoordY + i * 2.02f - 7), Quaternion.identity);
                }
                else
                {
                    Instantiate(Objects[3], new Vector2(FirstCoordX + lol - 57, FirstCoordY + i * 2.02f - 16), Quaternion.identity);
                }
                

            }

            
        }



        
    }

    void Update()
    {
        me = GetComponent<Transform>();
        InvokeRepeating("Attack", 1000f, 50f);

    }






}
