using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class OnClick : MonoBehaviour
{
    CreateObjects.MainObject Me;
    public int j;
    public int[] MyArray;
    // Start is called before the first frame update
    public Sprite Sprite1, Sprite2, Sprite3;
    bool Flag2 = false;
    int[] MyArray2 = new int[] {0, 1, 2, 3, 4, 5, 6 };

    private void Start()
    {
        CreateObjects target = (CreateObjects)FindObjectOfType(typeof(CreateObjects));
        CreateObjects script2 = target.GetComponent<CreateObjects>();
        int DefaultX = script2.DefaultX + 7;
        int DefaultY = script2.DefaultY + 7;
        int DefaultN = script2.DefaultN;
        int DefaultL = script2.DefaultL;
        var MainObjects = script2.MainObjects;
        







        var me_trans = GetComponent <Transform>();

        for (int i = 0; i < DefaultN; i++)
        {
            for (int k = 0; k < DefaultN; k++)
            { 
                if (me_trans.position.x == DefaultX + DefaultL*i & me_trans.position.y == DefaultY + DefaultL * k)
                {
                    Me = MainObjects[i, k];
                }


            }


        }


    }


    void OnMouseUp()
    {

        

        CreateObjects target = (CreateObjects)FindObjectOfType(typeof(CreateObjects));
        CreateObjects script2 = target.GetComponent<CreateObjects>();

        if (Me.Mass != 0 & Me.PlayerN == script2.RandomMoves[script2.j]) 
        {
            Me.IncrementMass();
            if (script2.j <= script2.NegativeJ)
            {
                script2.j++;
            }
            else
            {
                script2.j = 0;
            }











        }
        
    }
}
