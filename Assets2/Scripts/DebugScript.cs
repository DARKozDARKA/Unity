using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    public int MyColor;
    private bool Active = false;
    void OnMouseUp()
    {



        CreateObjects target = (CreateObjects)FindObjectOfType(typeof(CreateObjects));
        CreateObjects script2 = target.GetComponent<CreateObjects>();
        
        if (MyColor == 0 & Active is false)
        {
            script2.Player1 = true;
            Active = true;
        }
        if (MyColor == 0 & Active is true)
        {
            script2.Player1 = false;
            Active = false;
        }

        if (MyColor == 1 & Active is false)
        {
            script2.Player2 = true;
            Active = true;
        }
        if (MyColor == 1 & Active is true)
        {
            script2.Player2 = false;
            Active = false;
        }

        if (MyColor == 2 & Active is false)
        {
            script2.Player3 = true;
            Active = true;
        }
        if (MyColor == 2 & Active is true)
        {
            script2.Player3 = false;
            Active = false;
        }

        if (MyColor == 3 & Active is false)
        {
            script2.Player4 = true;
            Active = true;
        }
        if (MyColor == 3 & Active is true)
        {
            script2.Player4 = false;
            Active = false;
        }













    }
}
