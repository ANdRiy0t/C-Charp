﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//asdfasdfsdfsfdas

namespace TIcTAcToe_Адаптив
{
    public partial class Form1 : Form
    {

        static int sizePlayMap = 13;
        // це поле яке показує скільки обьєктів має бути в ряд щоб виграти
        static int countCubeInLineFowWin = 6;
        // Масив карти
        char[,] map = new char[sizePlayMap, sizePlayMap];
        List<PictureBox> pictureBoxes = new List<PictureBox>();

        char dataWhichAddToMassiveForPlayer = 'X', dataWhichAddToMassiveForBOT = 'O';
        static int startPossitionForLeftSide = 10, startPossitionForTopSide = 10;
        static sbyte sizeButton = 35;

        bool WIN = false;

        Random rand = new Random();

        // Масив в якому галочки ставлятся якщо для прикладу є 3 в ряд а WinIN = 3
        byte[] ChekingForWin = new byte[countCubeInLineFowWin];

        byte x = 0, y = 0;

        string HID = "Player", bot = "BOT", player = "Player";

        public Form1()
        {
            InitializeComponent();
            CreateMAP();


            TIMER.Interval += 900;
            TIMER.Tick += new EventHandler(TIMER_Tick);
        }

        public void CreateMAP()
        {
            for (int i = 0; i < sizePlayMap; i++)
            {
                for (int b = 0; b < sizePlayMap; b++)
                {
                    PictureBox pic = new PictureBox();

                    pic.Name = i.ToString() + "_" + b.ToString();
                    pic.Size = new Size(sizeButton, sizeButton);
                    pic.Location = new Point(startPossitionForLeftSide, startPossitionForTopSide);
                    pic.BackColor = Color.LightGray;
                    pic.Click += new EventHandler(OnClick);

                    pictureBoxes.Add(pic);
                    // Завдяки Controls додаєтся на екран цей PicBox
                    this.Controls.Add(pic);
                    // зразу змінюємо наступні дані для локації наступного picbox
                    startPossitionForLeftSide += sizeButton + 5;
                }
                startPossitionForLeftSide = 10;
                startPossitionForTopSide += sizeButton + 5;
            }

        }

        private void OnClick(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;

            if (HID == "BOT" || pic.BackColor == Color.Green || pic.BackColor == Color.Red)
            {
                return;
            }
            TakeLocation(pic, ref x, ref y);

            //    Image imageToe = Image.FromFile(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "toe.png"));

            int formulForSearchPictureBoxInList = (x - 1) * sizePlayMap + y + sizePlayMap;
            map[x, y] = dataWhichAddToMassiveForPlayer;
            pictureBoxes[formulForSearchPictureBoxInList].BackColor = Color.Green;
            //     pictureBoxes[formulForSearchPictureBoxInList].SizeMode = PictureBoxSizeMode.Zoom;
            //      pictureBoxes[formulForSearchPictureBoxInList].Image = imageToe;

            //pictureBoxes[(x - 1) * N + y + N].AutoSize = true;
            //pictureBoxes[(x - 1) * N + y + N].Size = pictureBoxes[(x - 1) * N + y + N].Image.Size;
            HID = "BOT";
            ChekinWinGameOrNot(dataWhichAddToMassiveForPlayer);
            TIMER.Start();

        }

        private void Level1_CheckedChanged(object sender, EventArgs e)
        {
            Level1_RANDOM();
        }

        private void TIMER_Tick(object sender, EventArgs e)
        {
            TIMER.Stop();

            Level1_RANDOM();
        }

        // Даний метод визначає Позицїю квадратика на який нажали, Воно працює елементарно назва любого PictureBox Складаєтся з 2 цифр які задані  нижнім піжкресленням
        // В методі записуются дані в String з перевіркою чи цей символ не є '_' потім парсить дані з string в byte
        private void TakeLocation(PictureBox pic, ref byte x, ref byte y)
        {
            char[] arr = pic.Name.ToCharArray();

            string result1 = string.Empty, result2 = string.Empty;

            bool HelpBool = false;
            foreach (char helpChar in arr)
            {
                _ = helpChar == '_' ? HelpBool = true : HelpBool;
                if (HelpBool)
                    _ = helpChar != '_' ? result2 += helpChar.ToString() : helpChar.ToString();
                else
                    result1 += helpChar.ToString();
            }

            x = Byte.Parse(result1);
            y = Byte.Parse(result2);
        }







        /// <summary>
        ///                                                                 WIN
        /// </summary>


        private void ChekinWinGameOrNot(char PlayerOrBot)
        {
            CheckingWinInRow(PlayerOrBot);
            ChekingWinInLine(PlayerOrBot);
            ChekingWinInRightDown(PlayerOrBot);
            ChekingWinInLeftDown(PlayerOrBot);
        }

        private void CheckingWinInRow(char PlayerOrBot)
        {
            int variableForWin = 0;
            for (int i = 0; i < sizePlayMap; i++)
            {
                for (int j = 0; j < sizePlayMap; j++)
                {
                    //if (pictureBoxes[i].BackColor == )
                    if (map[i, j] == PlayerOrBot)
                        variableForWin++;
                    else
                        variableForWin = 0;

                    if (variableForWin == countCubeInLineFowWin)
                    {
                        MessageBox.Show($"Win: {PlayerOrBot}");
                        WIN = true;
                        
                    }
                }
            }
        }

        private void ChekingWinInLine(char PlayerOrBot)
        {
            int variableForWin = 0;
            for (int i = 0; i < sizePlayMap; i++)
            {
                for (int j = 0; j < sizePlayMap; j++)
                {
                    //if (pictureBoxes[i].BackColor == )
                    if (map[j, i] == PlayerOrBot)
                        variableForWin++;
                    else
                        variableForWin = 0;

                    if (variableForWin == countCubeInLineFowWin)
                    {
                        MessageBox.Show($"Win: {PlayerOrBot}");
                        WIN = true;
                    }
                }
            }
        }

        private void ChekingWinInRightDown(char PlayerOrBot)
        {
            int variableForWin = 0;
            for(int i = 0; i <= sizePlayMap - countCubeInLineFowWin; i++)
            {
                for(int j = 0; j <= sizePlayMap - countCubeInLineFowWin; j++)
                {
                    int tempI = i, tempJ = j;
                    for (int k = 0; k <= countCubeInLineFowWin-1; k++)
                    {
                        if (map[tempI, tempJ] == PlayerOrBot)
                        {
                            variableForWin++;
                            tempI++;
                            tempJ++;
                        }
                        
                    }
                    if (variableForWin == countCubeInLineFowWin) 
                    { 
                        MessageBox.Show($"Win: {PlayerOrBot}");
                        WIN = true;
                    }
                    else
                        variableForWin = 0;
                }
            }
        }
        //left down в розробці

        private void ChekingWinInLeftDown(char PlayerOrBot)
        {
            int variableForWin = 0;
            for (int i = sizePlayMap-1;
                i >= countCubeInLineFowWin - 1;
                i--)
            {
                for (int j = 0; j <= sizePlayMap - countCubeInLineFowWin; j++)
                {
                    int tempI = i, tempJ = j;
                    for (int k = 0; k <= countCubeInLineFowWin-1; k++)
                    {
                        if (map[i, j] == PlayerOrBot)
                        {
                            variableForWin++;
                            i--;
                            j++;
                        }

                    }
                    if (variableForWin == countCubeInLineFowWin)
                    {
                        MessageBox.Show($"Win: {PlayerOrBot}");
                        WIN = true;
                    }
                        
                    else
                        variableForWin = 0;
                }
            }
        }


        private void ClearMap(bool Win)
        {
            if (!Win)
            {
                return;
            }
            pictureBoxes.Clear();
            for (int i = 0; i < sizePlayMap; i++)
            {
                for (int j = 0; j < sizePlayMap; j++)
                {
                    map[i, j] = '\0';
                }
            }
        }


        

        //    ___     __   _______           
        //    -  -  -    -    |
        //    ---   -    -    |
        //    -  -  -    -    |
        //    ---     --      |



        private void Level1_RANDOM()
        {
            if (HID == player)
            {
                return;
            }
            int random = rand.Next(sizePlayMap * sizePlayMap);

            ChekinWinGameOrNot(dataWhichAddToMassiveForBOT);

            if (pictureBoxes[random].BackColor == Color.LightGray)
            {
                TakeLocation(pictureBoxes[random], ref x, ref y);
                pictureBoxes[random].BackColor = Color.Red;
                map[x, y] = dataWhichAddToMassiveForBOT;
                HID = player;
                return;
            }
            else
                //HID = "Player";
                Level1_RANDOM();

            


            //GC.Collect();
        }

        private void Level2_DEFENCE()
        {

            List<List<Pair<int, Pair<int, int>>>> a = new List<List<Pair<int, Pair<int, int>>>>;

            ////
            //int countForWinPlayer = 0;

            //for (int i = 0; i < sizePlayMap; i++)
            //{
            //    for(int b = 0; b < sizePlayMap; b++)
            //    {
            //        if (map[b, i] == dataWhichAddToMassiveForPlayer)
            //            countForWinPlayer++;
            //        else
            //            countForWinPlayer = 0;

            //        if(i != 0)
            //        {
            //         //   if (map[b,i])
            //        }

            //        if(countForWinPlayer == countCubeInLineFowWin - 2)
            //        {

            //        }
            //    }
            //} 
            //if (WIN) return;
            //ChekinWinGameOrNot(dataWhichAddToMassiveForBOT);
            ////перевіряємо одну клітинку на N клітинок вправо вниз і вниз вправо
            ////створюємо масив з назвами Right, Down, RightDown в які додаємо клітинку якщо вона ворожа
            ////далі перевіряємо в якому масиві найбільше елементів і ставимо випадково клітинку в пусту якщо їх більше одної
            ////продумати вниз вліво
            ////x  
            ////масив в якому два масиви в яких є Nsize-N+1 масивів в яких ще 3 масиви
            //int variableForWin = 0;

            //char[,] Right = new char[sizePlayMap - countCubeInLineFowWin + 1, 4];
            //char[,] Left = new char[sizePlayMap - countCubeInLineFowWin + 1, 4];
            
            //for (int i = 0; i < sizePlayMap; i++)
            //{
            //    for (int j = 0; j < sizePlayMap; j++)
            //    {
            //        if (map[i, j] == dataWhichAddToMassiveForBOT)
            //            variableForWin++;
            //        else
            //            variableForWin = 0;

                    
            //    }
            //}

        }

        private void Level3_ATTACK()
        {
            
        }

        public class Pair<T1, T2>
        {
            public T1 First
            {
                get;
                set;
            }
            public T2 Second
            {
                get;
                set;
            }
            public Pair(T1 first, T2 second)
            {
                First = first;
                Second = second;
            }
        }
    }
}