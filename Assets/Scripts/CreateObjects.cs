using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjects : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Objects; 

    // Update is called once per frame
    void Update()
    {
        Vector3 MousePosition;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            Instantiate(Objects[0], new Vector2(MousePosition.x, MousePosition.y), Quaternion.identity);
        }
        
    }
}
