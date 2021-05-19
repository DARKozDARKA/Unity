using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


static class RandomExtensions
{
    public static void Shuffle<T>(this System.Random rng, T[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            int k = rng.Next(n--);
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }
}

public class CreateObjects : MonoBehaviour
{
    public MainObject[,] MainObjects = new MainObject[8, 8];
    public GameObject[] Objects;
    public Sprite[] spriteArray;
    public SpriteRenderer spriteRenderer;
    public int[] RandomMoves = Enumerable.Range(0, 3).ToArray();
    public int DefaultX = -42; // Место начала строительства
    public int DefaultY = -24; // Место начала строительства
    public int DefaultN = 8;   // Кол-во стобцов и колонн 
    public int DefaultL = 7;   // Расстояние между объектами
    public int j = 0;
    public int PlayersINT, PlayersINT_old;
    public int NegativeJ = 2;
    public bool Player1, Player2, Player3, Player4 = true;

    private Vector2 MainVector;
    private int[] CheckList;
    private int[] PCount = new int[4];
    private int[] PCount2;
    public List<int> DeletedPlayers = new List<int>();
    private int old_j = 10;
    private int I_check;
    private int Max_J = 3;

    





    public class MainObject


    {
        public int Mass = 0;

        public Vector2 MainVector;
        public GameObject[] Objects;
        GameObject CurrentEntity;
        SpriteRenderer SpriteRend;
        Color MyColor = Color.white;
        Color MyDefautColor1, MyDefautColor2, MyDefautColor3, MyDefautColor4;
        public int i, k, DefaultN;
        MainObject[,] MainObjects2;
        public int PlayerN, PlayerN_Extra;
        Sprite[] spriteArray;


        public MainObject(Vector2 Vector_, ref GameObject[] Objects_, int i_, int k_, ref MainObject[,] MainObjects, int DefaultN_, Sprite[] spriteArray_)
        {
            MainVector = Vector_;
            Objects = Objects_;
            i = i_;
            k = k_;
            MainObjects2 = MainObjects;
            DefaultN = DefaultN_;
            spriteArray = spriteArray_;



        }

        public void DrawFunction()
        {
            CurrentEntity = Instantiate(Objects[0], MainVector, Quaternion.identity);
            SpriteRend = CurrentEntity.GetComponent<SpriteRenderer>();
            SpriteRend.color = Color.white;
            SpriteRend.sprite = spriteArray[3];

        }

        public void IncrementMass()
        {


            if (Mass == 0)
            {
                Mass++;
                SpriteRend.color = MyDefautColor1;
                SpriteRend.sprite = spriteArray[0];
            }

            else if (Mass == 1)
            {
                Mass++;
                SpriteRend.color = MyDefautColor2;
                SpriteRend.sprite = spriteArray[1];
            }

            else if (Mass == 2)
            {
                Mass++;
                SpriteRend.color = MyDefautColor3;
                SpriteRend.sprite = spriteArray[2];

            }

            else
            {
                Mass = 0;
                SpriteRend.color = Color.white;
                SpriteRend.sprite = spriteArray[3];
                PlayerN_Extra = PlayerN;
                PlayerN = 0;
                

                if (k != DefaultN - 1) {
                    MainObjects2[i, k + 1].IncrementEnemyMass(PlayerN_Extra, MyDefautColor1, MyDefautColor2, MyDefautColor3, MyDefautColor4);
                }
                if (k != 0)
                {
                    MainObjects2[i, k - 1].IncrementEnemyMass(PlayerN_Extra, MyDefautColor1, MyDefautColor2, MyDefautColor3, MyDefautColor4);
                }
                if (i != 0)
                {
                    MainObjects2[i - 1, k].IncrementEnemyMass(PlayerN_Extra, MyDefautColor1, MyDefautColor2, MyDefautColor3, MyDefautColor4);
                }
                if (i != DefaultN - 1)
                {
                    MainObjects2[i + 1, k].IncrementEnemyMass(PlayerN_Extra, MyDefautColor1, MyDefautColor2, MyDefautColor3, MyDefautColor4);
                }
                

            }
        }


        private void IncrementEnemyMass(int PlayerN_, Color DefaultColor1_, Color DefaultColor2_, Color DefaultColor3_, Color DefaultColor4_)
        {
            MyDefautColor1 = DefaultColor1_;
            MyDefautColor2 = DefaultColor2_;
            MyDefautColor3 = DefaultColor3_;
            MyDefautColor4 = DefaultColor4_;
            PlayerN = PlayerN_;

            if (Mass == 0)
            {
                Mass++;
                SpriteRend.color = MyDefautColor1;
                SpriteRend.sprite = spriteArray[0];

            }

            else if (Mass == 1)
            {
                Mass++;
                SpriteRend.color = MyDefautColor2;
                SpriteRend.sprite = spriteArray[1];
            }

            else if (Mass == 2)
            {
                Mass++;
                SpriteRend.color = MyDefautColor3;
                SpriteRend.sprite = spriteArray[2];
            }

            else
            {
                Mass = 0;
                SpriteRend.color = Color.white;
                SpriteRend.sprite = spriteArray[3];
                PlayerN_Extra = PlayerN;
                PlayerN = 0;

                if (k != DefaultN - 1)
                {
                    MainObjects2[i, k + 1].IncrementEnemyMass(PlayerN_Extra, MyDefautColor1, MyDefautColor2, MyDefautColor3, MyDefautColor4);
                }
                if (k != 0)
                {
                    MainObjects2[i, k - 1].IncrementEnemyMass(PlayerN_Extra, MyDefautColor1, MyDefautColor2, MyDefautColor3, MyDefautColor4);
                }
                if (i != 0)
                {
                    MainObjects2[i - 1, k].IncrementEnemyMass(PlayerN_Extra, MyDefautColor1, MyDefautColor2, MyDefautColor3, MyDefautColor4);
                }
                if (i != DefaultN - 1)
                {
                    MainObjects2[i + 1, k].IncrementEnemyMass(PlayerN_Extra, MyDefautColor1, MyDefautColor2, MyDefautColor3, MyDefautColor4);
                }
                
                

            }
        }





        public void CreatePoint(int PlayerN_)
        {

            PlayerN = PlayerN_;

            if (PlayerN == 0)
            {

                MyDefautColor1 = Color.black;
                MyDefautColor1.b = 0.8f;
                MyDefautColor2 = Color.black;
                MyDefautColor2.b = 0.9f;
                MyDefautColor3 = Color.black;
                MyDefautColor3.b = 1f;

            }
            else if (PlayerN == 1)
            {

                MyDefautColor1 = Color.black;
                MyDefautColor1.r = 0.8f;
                MyDefautColor2 = Color.black;
                MyDefautColor2.r = 0.9f;
                MyDefautColor3 = Color.black;
                MyDefautColor3.r = 1f;



            }

            else if (PlayerN == 2)
            {

                MyDefautColor1 = Color.black;
                MyDefautColor1.g = 0.8f;
                MyDefautColor2 = Color.black;
                MyDefautColor2.g = 0.9f;
                MyDefautColor3 = Color.black;
                MyDefautColor3.g = 1f;


            }

            else
            {
                MyDefautColor1 = Color.black;
                MyDefautColor1.r = 0.8f;
                MyDefautColor1.b = 0.8f;
                MyDefautColor2 = Color.black;
                MyDefautColor2.r = 0.9f;
                MyDefautColor2.b = 0.9f;
                MyDefautColor3 = Color.black;
                MyDefautColor3.r = 1f;
                MyDefautColor3.b = 1f;


            }

            MyColor = MyDefautColor3;
            SpriteRend.sprite = spriteArray[2];
            Mass = 3;
            SpriteRend.color = MyColor;
        }

        public void TurnCheck(int j, int[] RandomMoves)
        {
            if (PlayerN == RandomMoves[j])
            {
                if (SpriteRend.sprite == spriteArray[0])
                {
                    SpriteRend.sprite = spriteArray[4];
                }
                else if (SpriteRend.sprite == spriteArray[1])
                {
                    SpriteRend.sprite = spriteArray[5];
                }
                else if (SpriteRend.sprite == spriteArray[2])
                {
                    SpriteRend.sprite = spriteArray[6];
                }
            }
            else
            {
                if (SpriteRend.sprite == spriteArray[4])
                {
                    SpriteRend.sprite = spriteArray[0];
                }
                else if (SpriteRend.sprite == spriteArray[5])
                {
                    SpriteRend.sprite = spriteArray[1];
                }
                else if (SpriteRend.sprite == spriteArray[6])
                {
                    SpriteRend.sprite = spriteArray[2];
                }
            }
        }

        public int[] NumberCheck()
        {
            if (Mass != 0)
            {
                return new int[] { 1, PlayerN };
                
            }
            else
            {
                return new int[] {0, PlayerN};
            }
        }




    }





    // Start is called before the first frame update

    public void ChangeArray(ref int[] MyArray, int k)
    {
        int l = 1;
        int[] NewArray = new int[(MyArray.Length - 1)];
        if (k == 0)
        {

            for (int i = 0; i < MyArray.Length - 1; i++)
            {
                NewArray[i] = MyArray[i + 1];

            }

        }

        else if (k == MyArray.Length - 1)
        {
            for (int i = 0; i < MyArray.Length - 1; i++)
            {
                NewArray[i] = MyArray[i];
            }
        }

        else
        {
            k++;
            for (int i = 0; i < k; i++)
            {
                l = i;
                NewArray[i] = MyArray[i];

            }

            for (int i = l; i < MyArray.Length - 1; i++)
            {
                NewArray[i] = MyArray[i + 1];
            }
        }
        MyArray = NewArray;
    }

    void Start()
    {
        var rng = new System.Random();
        rng.Shuffle(RandomMoves);
        //RandomMoves = new int[]{0,3,2,1};
        


        
        MainVector.x = DefaultX;

        for (int i = 0; i < DefaultN; i++)
        {
            MainVector.x += DefaultL;
            MainVector.y = DefaultY;
            for (int k = 0; k < DefaultN; k ++)
            {
                MainVector.y += DefaultL;
                MainObjects[i, k] = new MainObject(MainVector, ref Objects, i, k, ref MainObjects, DefaultN, spriteArray);


            }

                
        }




        for (int i = 0; i < DefaultN; i++)
        {
            for (int k = 0; k < DefaultN; k++)
            {
                MainObjects[i, k].DrawFunction();
            }
        }

        if (Player1 is true)
        {
            MainObjects[1, 6].CreatePoint(0);
            if (Player2 is true)
            {
                MainObjects[6, 1].CreatePoint(1);
            }
            if (Player3 is true)
            {
                MainObjects[1, 1].CreatePoint(2);
            }
            if (Player4 is true)
            {
                MainObjects[6, 6].CreatePoint(3);
            }
        }




            PlayersINT = 4;
        PlayersINT_old = 4;






    }

    private void Update()
    {




        if (j != old_j)
        {
            for (int i = 0; i < PCount.Length; i++)
            {
                PCount[i] = 0;
            }

            
            for (int i = 0; i < DefaultN; i++)
            {
                for (int k = 0; k < DefaultN; k++)
                {
                    MainObjects[i, k].TurnCheck(j, RandomMoves);
                    CheckList = MainObjects[i, k].NumberCheck();
                    if (CheckList[0] != 0)
                    {
                        PCount[CheckList[1]]++;
                    }

                }
            }
            PlayersINT = 4;
            DeletedPlayers.Clear();
            I_check = 0;
            foreach (var element in PCount)
            {
                if (element == 0)
                {
                    
                    PlayersINT -= 1;
                    DeletedPlayers.Add(I_check);



                }
                I_check++;


            }
            if (PlayersINT != PlayersINT_old)
            {

                
                PlayersINT_old = PlayersINT;
                for (int i = 0; i < DeletedPlayers.Count; i++)
                {
                    for (int g = 0; g < RandomMoves.Length; g++)
                    {
                        if (RandomMoves[g] == DeletedPlayers[i])
                        {

                            ChangeArray(ref RandomMoves, g);
                            NegativeJ -= 1;
                            if (j == Max_J)
                            {
                                j = 0;
                                
                            }

                            Max_J -= 1;

                            for (int r = 0; r < DefaultN; r++)
                            {
                                for (int k = 0; k < DefaultN; k++)
                                {
                                    MainObjects[r, k].TurnCheck(j, RandomMoves);
                                    if (CheckList[0] != 0)
                                    {
                                        PCount[CheckList[1]]++;
                                    }

                                }
                            }

                        }
                    }
                }
               
            }



        }
        old_j = j;
    }



}


