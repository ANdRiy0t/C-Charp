using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using Timer = System.Threading.Timer;

namespace НоваГраХзЩоВийде
{
    public partial class Form1 : Form
    {
        private int _hight = 430;
        private int _weight = 430;
        private int SizeOfSide = 30;
        private string BOT = "X", player = "O";
        private int Win = 0, номерХоду = 0,NumBotHid = 0;
        public string[,] GameMassive = new string[11, 11];
        private int Defend = 0,  a = 0;
        private int peremogaBota = 0, DiagoneWin_BotMechanics = 0, WerticalWin_BotMechanics=0;
        List<PictureBox> ALLX = new List<PictureBox>();

        public Form1()
        {
                
            InitializeComponent();
            generetion_map();
            allX();

        }
        private void allX() 
        {//      0              1              2             3               4                 5             6            7               8                 9           10             
            ALLX.Add(Xx00); ALLX.Add(XX1); ALLX.Add(XX2); ALLX.Add(XX3); ALLX.Add(XX4); ALLX.Add(XX5); ALLX.Add(XX6); ALLX.Add(XX7); ALLX.Add(XX8); ALLX.Add(XX9); ALLX.Add(XX10);
           //    11               12               13             14              15                 16         17                 18               19             20            21
            ALLX.Add(Xx01); ALLX.Add(XX11); ALLX.Add(XX12); ALLX.Add(XX13); ALLX.Add(XX14); ALLX.Add(XX15); ALLX.Add(XX16); ALLX.Add(XX17); ALLX.Add(XX18); ALLX.Add(XX19); ALLX.Add(XX110);
            //    22                23           24                 25              26          27               28               29               30               31             32
            ALLX.Add(Xx02); ALLX.Add(XX21); ALLX.Add(XX22); ALLX.Add(XX23); ALLX.Add(XX24); ALLX.Add(XX25); ALLX.Add(XX26); ALLX.Add(XX27); ALLX.Add(XX28); ALLX.Add(XX29); ALLX.Add(XX210);
            //    33            34                 35             36               37            38              39              40            41                 42               43          
            ALLX.Add(Y3X); ALLX.Add(XX31); ALLX.Add(XX32); ALLX.Add(XX33); ALLX.Add(XX34); ALLX.Add(XX35); ALLX.Add(XX36); ALLX.Add(XX37); ALLX.Add(XX38); ALLX.Add(XX39); ALLX.Add(XX310);
            //     44            45             46              47                  48          49                  50          51                  52          53              54
            ALLX.Add(Y4X); ALLX.Add(XX41); ALLX.Add(XX42); ALLX.Add(XX43); ALLX.Add(XX44); ALLX.Add(XX45); ALLX.Add(XX46); ALLX.Add(XX47); ALLX.Add(XX48); ALLX.Add(XX49); ALLX.Add(XX410);
            //      55          56                  57          58              59              60              61              62              63              64              65
            ALLX.Add(Y5X); ALLX.Add(XX51); ALLX.Add(XX52); ALLX.Add(XX53); ALLX.Add(XX54); ALLX.Add(XX55); ALLX.Add(XX56); ALLX.Add(XX57); ALLX.Add(XX58); ALLX.Add(XX59); ALLX.Add(XX510);
            //     66           67              68              69          70                  71              72              73              74                  75          76          
            ALLX.Add(Y6X); ALLX.Add(XX61); ALLX.Add(XX62); ALLX.Add(XX63); ALLX.Add(XX64); ALLX.Add(XX65); ALLX.Add(XX66); ALLX.Add(XX67); ALLX.Add(XX68); ALLX.Add(XX69); ALLX.Add(XX610);
            //    77            78                  79          80              81              82              83                84            85              86              87              
            ALLX.Add(Y7X); ALLX.Add(XX71); ALLX.Add(XX72); ALLX.Add(XX73); ALLX.Add(XX74); ALLX.Add(XX75); ALLX.Add(XX76); ALLX.Add(XX77); ALLX.Add(XX78); ALLX.Add(XX79); ALLX.Add(XX710);
            //     88           89                  90              91              92          93                  94          95              96              97              98
            ALLX.Add(Y8X); ALLX.Add(XX81); ALLX.Add(XX82); ALLX.Add(XX83); ALLX.Add(XX84); ALLX.Add(XX85); ALLX.Add(XX86); ALLX.Add(XX87); ALLX.Add(XX88); ALLX.Add(XX89); ALLX.Add(XX810);
            //       99         100             101             102             103                 104         105             106             107                 108         109
            ALLX.Add(Y9X); ALLX.Add(XX91); ALLX.Add(XX92); ALLX.Add(XX93); ALLX.Add(XX94); ALLX.Add(XX95); ALLX.Add(XX96); ALLX.Add(XX97); ALLX.Add(XX98); ALLX.Add(XX99); ALLX.Add(XX910);
            //     110          111                 112             113             114             115                 116             117             118                 119             120
            ALLX.Add(Y10X); ALLX.Add(XX101); ALLX.Add(XX102); ALLX.Add(XX103); ALLX.Add(XX104); ALLX.Add(XX105); ALLX.Add(XX106); ALLX.Add(XX107); ALLX.Add(XX108); ALLX.Add(XX109); ALLX.Add(XX1010);
        }
        //ALLX[i * 11 - 1 + b].Visible = true;
        //HidBota(I, B, ALLX[(I - 1) * 11 - I + B], ALLX[(I - 1) * 11 + B], ALLX[(I - 1) * 11 + 1 + B], ALLX[I * 11 + B + 1], ALLX[I * 11 + B + 12], ALLX[I * 11 + B + 11], ALLX[I * 11 + B + 10], ALLX[I * 11 - 1 + B]);
        private void Bot_Ygli(int I, int B)
        {
            var rand = new Random();
            int Randomaiser = rand.Next(3);
            if (GameMassive[0, 0] == player&& I == 0&& B==0)
            {
                if (Randomaiser == 1)
                {
                    GameMassive[0, 1] = BOT;
                    ALLX[1].Visible = true;
                }
                else if (Randomaiser == 2)
                {
                    GameMassive[1, 1] = BOT;
                    ALLX[12].Visible = true;
                }
                else
                {
                    GameMassive[1, 0] = BOT;
                    ALLX[11].Visible = true;
                }
               
            }
            else if (GameMassive[0, 10] == player && I == 0 && B == 10)
            {
                if (Randomaiser == 1)
                {
                    GameMassive[0, 9] = BOT;
                    ALLX[9].Visible = true;
                }
                else if (Randomaiser == 2)
                {
                    GameMassive[1, 9] = BOT;
                    ALLX[20].Visible = true;
                }
                else
                {
                    GameMassive[1, 10] = BOT;
                    ALLX[21].Visible = true;
                }
                
            }
            else if (GameMassive[10, 0] == player && I == 10 && B == 0)
            {
                if (Randomaiser == 1)
                {
                    GameMassive[9, 0] = BOT;
                    ALLX[99].Visible = true;
                }
                else if (Randomaiser == 2)
                {
                    GameMassive[9, 1] = BOT;
                    ALLX[110].Visible = true;
                }
                else
                {
                    GameMassive[10, 1] = BOT;
                    ALLX[111].Visible = true;
                }
               
            }
            else if (GameMassive[10, 10] == player && I == 10 && B == 10)
            {
                if (Randomaiser == 1)
                {
                    GameMassive[10, 9] = BOT;
                    ALLX[119].Visible = true;
                }
                else if (Randomaiser == 2)
                {
                    GameMassive[9, 9] = BOT;
                    ALLX[108].Visible = true;
                }
                else
                {
                    GameMassive[9, 10] = BOT;
                    ALLX[109].Visible = true;
                }
                
            }
            
        } 
        private void LiniiBot(int I, int B)
        {     
            var rand = new Random();
            int r=7;
            while(r > 6)
            {
                r = rand.Next(5);
                if (GameMassive[I,B] == player&& GameMassive[I, B-1] != player&& GameMassive[I, B - 1] != BOT && r == 1)
                {
                    GameMassive[I, B - 1] = BOT;
                    ALLX[B-1].Visible = true; r = 7;
                }
                else if (GameMassive[I+1, B - 1] == player&& GameMassive[I+1, B - 1] != BOT && r ==2)
                {
                    GameMassive[I+1, B-1] = BOT;
                    ALLX[10+B].Visible= true; r = 7; 
                }
                else if (GameMassive[I+1, B] != player && GameMassive[I+1, B ] != BOT && r ==3)
                {
                    GameMassive[I+1, B] = BOT;
                    ALLX[11 + B].Visible = true; r = 7; 
                }
                else if (GameMassive[I + 1, B+1] != player && GameMassive[I+1, B + 1] != BOT && r==4)
                {
                    GameMassive[I + 1, B+1] = BOT;
                    ALLX[12 + B].Visible = true; r = 7; 
                }
                else if (GameMassive[I, B + 1] != player&& GameMassive[I, B + 1] != BOT && r ==5)
                {
                    GameMassive[I, B + 1] = BOT;
                    ALLX[B+1].Visible = true; r = 7;
                   
                    MessageBox.Show("2");
                }
                
            } 
        }
        private void leftLiniiys(int I, int B)
        {      
        
                if (GameMassive[I, B] == player && GameMassive[I-1, B] != player && GameMassive[I-1, B] != BOT)
                {
                    GameMassive[0, 0] = BOT;
                    ALLX[(I*11) -11].Visible = true;
                }
                else if (GameMassive[I, B] == player && GameMassive[I-1, B+1] != player && GameMassive[I-1, B+1] != BOT)
                {
                    GameMassive[I-1, B+1] = BOT;
                    int gg=0;
                    for(int b= 0; b < I; b++)
                    {
                        gg++;
                    }
                    ALLX[((I-1)*11)+gg].Visible = true;
                }
                else if (GameMassive[I, B] == player && GameMassive[I , B + 1] != player && GameMassive[I, B + 1] != BOT)
                {
                    GameMassive[I, B + 1] = BOT;

                    ALLX[(I * 11) +1].Visible = true;
                }
                else if (GameMassive[I, B] == player && GameMassive[I, B + 1] != player && GameMassive[I, B + 1] != BOT)
                {
                    GameMassive[I, B + 1] = BOT;
                    ALLX[((I+1) * 11) + 1].Visible = true;
                }
                else if (GameMassive[I, B] == player && GameMassive[I, B + 1] != player && GameMassive[I, B + 1] != BOT)
                {
                    GameMassive[I, B + 1] = BOT;
                    ALLX[((I + 1) * 11)].Visible = true;
                }
            
        }
        private void LiniiBotTop(int I, int B)
        {
            if (GameMassive[I,B] == player&& GameMassive[I,B-1] != player && GameMassive[I, B - 1] != BOT)
            {
                GameMassive[I,B-1] = BOT;
                ALLX[(11 * I)-1+B].Visible= true;
            }
            else if(GameMassive[I, B] == player && GameMassive[I-1, B - 1] != player && GameMassive[I-1, B - 1] != BOT)
            {
                GameMassive[I - 1, B - 1] = BOT;
                ALLX[(I*10) - 2+B].Visible= true;
            }
            else if (GameMassive[I, B] == player && GameMassive[I - 1, B] != player && GameMassive[I - 1, B] != BOT)
            {
                GameMassive[I - 1, B] = BOT;
                ALLX[(I * 10)+ (B-1)].Visible = true;
            }
            else if (GameMassive[I, B] == player && GameMassive[I - 1, B+1] != player && GameMassive[I - 1, B+1] != BOT)
            {
                GameMassive[I - 1, B+1] = BOT;
                ALLX[(I * 10) + B].Visible = true;
            }
            else if (GameMassive[I, B] == player && GameMassive[I, B + 1] != player && GameMassive[I, B + 1] != BOT)
            {
                GameMassive[I, B + 1] = BOT;
                ALLX[(I * 10) + (B+1)].Visible = true;
            }
        }
        private void rightlinia(int I, int B)
        {
             if (GameMassive[I - 1, B] != player && GameMassive[I - 1, B] != BOT)
            {
                GameMassive[I - 1, B] = BOT;
                ALLX[I * 10 - 1 + I].Visible = true;
            }
            else if (GameMassive[I - 1, B - 1] != player && GameMassive[I - 1, B - 1] != BOT)
            {
                GameMassive[I - 1, B - 1] = BOT;
                ALLX[I * 10 - 2 + I].Visible = true;
            }
            
            
            else if (GameMassive[I + 1, B - 1] != player && GameMassive[I + 1, B - 1] != BOT)
            {
                GameMassive[I + 1, B - 1] = BOT;
                ALLX[(I + 2) * 10 + I].Visible = true;
            }
            else if (GameMassive[I, B - 1] != player && GameMassive[I, B - 1] != BOT)
            {
                GameMassive[I, B - 1] = BOT;
                ALLX[(I +1)*10-1+I].Visible = true;
            }
            
            else
            {
                GameMassive[I + 1, B] = BOT;
                ALLX[(I + 2) * 10 +(I+1)].Visible = true;

            }
        }
       private void BotTryWin()
        {

            if (peremogaBota == 0)
            {
                for (int i = 0; i < 11; i++)
                {
                    for (int b = 0; b < 9; b++)
                    {
                        if (Defend != 1)
                        {
                            if (GameMassive[i, b] == BOT && GameMassive[i, b - 1] != BOT && GameMassive[i, b - 1] != player&& b!= 0)
                            {
                                GameMassive[i, b - 1] = BOT;
                                ALLX[i * 11 - 1 + b].Visible = true;
                                Defend = 1;
                                peremogaBota++; break;
                            }
                            else if (GameMassive[i, b] == BOT && GameMassive[i, b + 1] != player && GameMassive[i, b + 1] != BOT)
                            {
                                GameMassive[i, b + 1] = BOT;
                                ALLX[i * 11 + 1 + b].Visible = true;
                                Defend = 1;
                                peremogaBota++; break;
                            }
                        }

                    }
                    if(peremogaBota == 1) break;
                }
            }
            else if (peremogaBota == 1)
            {
                for (int i = 0; i < 11; i++)
                {
                    for (int b = 0; b < 8; b++)
                    {
                        if (Defend != 1)
                        {
                            if (GameMassive[i, b] == BOT && GameMassive[i, b + 1] == BOT && GameMassive[i, b + 2] != BOT && GameMassive[i, b + 2] != player)
                            {
                                GameMassive[i, b + 2] = BOT;
                                ALLX[i * 11 + (2 + b)].Visible = true;
                                Defend = 1;
                                peremogaBota++;
                                break;

                            }
                            else if (GameMassive[i, b] == BOT && GameMassive[i, b + 1] == BOT && GameMassive[i, b - 1] != BOT && GameMassive[i, b - 1] != player)
                            {
                                GameMassive[i, b - 1] = BOT;
                                ALLX[(i * 11 - 1 + b)].Visible = true;
                                Defend = 1;
                                peremogaBota++;
                                break;
                            }
                        }
                    }
                    if (peremogaBota == 2) break;
                }
            }
            else if (peremogaBota == 2)
            {
                for (int i = 0; i < 11; i++)
                {
                    for (int b = 0; b < 8; b++)
                    {
                        if (Defend != 1)
                        {
                            if (GameMassive[i, b] == BOT && GameMassive[i, b + 1] == BOT && GameMassive[i, b + 2] == BOT && GameMassive[i, b + 3] != player && GameMassive[i, b + 3] != BOT)
                            {
                                GameMassive[i, b + 3] = BOT;
                                ALLX[i * 11 + 3 + b].Visible = true;
                                Defend = 1;
                                peremogaBota++; break;
                            }
                            else if (GameMassive[i, b] == BOT && GameMassive[i, b + 1] == BOT && GameMassive[i, b + 2] == BOT && GameMassive[i, b - 1] != player && GameMassive[i, b - 1] != BOT)
                            {
                                GameMassive[i, b - 1] = BOT;
                                ALLX[i * 11 - 1 + b].Visible = true;
                                Defend = 1;
                                peremogaBota++; break;
                            }

                        }
                    }
                    if(peremogaBota == 3) break;
                }
            }
            else if (peremogaBota == 3)
            {
                for (int i = 0; i < 11; i++)
                {
                    for (int b = 0; b < 7; b++)
                    {
                        if (Defend != 1)
                        {
                            if (GameMassive[i, b] == BOT && GameMassive[i, b + 1] == BOT && GameMassive[i, b + 2] == BOT && GameMassive[i, b + 3] == BOT && GameMassive[i, b - 1] != player && GameMassive[i, b - 1] != BOT)
                            {
                                GameMassive[i, b - 1] = BOT;
                                ALLX[i * 11 - 1 + b].Visible = true;
                                Defend = 1;
                                peremogaBota++; break;
                            }
                            else if (GameMassive[i, b] == BOT && GameMassive[i, b + 1] == BOT && GameMassive[i, b + 2] == BOT && GameMassive[i, b + 3] == BOT && GameMassive[i, b + 4] != player && GameMassive[i, b + 4] != BOT)
                            {
                                GameMassive[i, b + 4] = BOT;
                                ALLX[i * 11 + 4 + b].Visible = true;
                                Defend = 1;
                                peremogaBota++; break;
                            }

                        }

                    }
                    if (peremogaBota == 4)  break; 
                }
            }
            if (peremogaBota >= 3) peremogaBota = 0;
       }
        private void BotTryWinWertekal()
        {

            for (int i = 10; i > 0; i--)
            {
                for (int v = 0; v < 11; v++)
                {
                    if (Defend != 1)
                    {
                        if (GameMassive[i, v] == BOT && GameMassive[i - 1, v] != BOT && GameMassive[i - 1, v] != player)
                        {
                            GameMassive[i - 1, v] = BOT;
                            ALLX[(i - 1) * 11 + v].Visible = true;
                            WerticalWin_BotMechanics = 1;
                            Defend = 1;
                            break;
                        }
                        else if (i < 7 && GameMassive[i, v] == BOT && GameMassive[i - 1, v] == player)
                        {
                            for (int g = 0; g < 5; g++)
                            {
                                if (GameMassive[i, v] == BOT && GameMassive[i + g, v] != BOT && GameMassive[i + g, v] != player)
                                {
                                    GameMassive[i + g, v] = BOT;
                                    ALLX[(i + g - 1) * 11 + v + 11].Visible = true;
                                    WerticalWin_BotMechanics = 1;
                                    Defend = 1;
                                    break;
                                }
                            }
                            if (WerticalWin_BotMechanics == 1) { WerticalWin_BotMechanics = 0; break; }
                        }
                    }

                }
                if (WerticalWin_BotMechanics == 1) { WerticalWin_BotMechanics = 0; break; }
            }      
        }
        private void BotTrywinDiagonale()
        {
            for(int i = 0; i < 7; i++)
            {
                for(int b= 0; b < 7; b++)
                {
                    if (Defend != 1)
                    {
                        if (GameMassive[i, b] == BOT && GameMassive[i + 1, b + 1] != BOT && GameMassive[i + 1, b + 1] != player)
                        {
                            GameMassive[i + 1, b + 1] = BOT;
                            ALLX[i * 11 + b + 12].Visible = true;
                            DiagoneWin_BotMechanics++;
                            Defend = 1;
                            break;
                        }
                        else if (GameMassive[i, b] == BOT && GameMassive[i + 1, b + 1] == BOT && GameMassive[i + 2, b + 2] != BOT && GameMassive[i + 2, b + 2] != player)
                        {
                            GameMassive[i + 2, b + 2] = BOT;
                            ALLX[(i + 1) * 11 + b + 13].Visible = true;
                            DiagoneWin_BotMechanics++;
                            Defend = 1;
                            break;
                        }
                        else if (GameMassive[i, b] == BOT && GameMassive[i + 1, b + 1] == BOT && GameMassive[i + 2, b + 2] == BOT && GameMassive[i + 3, b + 3] != BOT && GameMassive[i + 3, b + 3] != player)
                        {
                            GameMassive[i + 3, b + 3] = BOT;
                            ALLX[(i + 2) * 11 + b + 14].Visible = true;
                            DiagoneWin_BotMechanics++;
                            Defend = 1;
                            break;
                        }
                        else if (GameMassive[i, b] == BOT && GameMassive[i + 1, b + 1] == BOT && GameMassive[i + 2, b + 2] == BOT && GameMassive[i + 3, b + 3] == BOT && GameMassive[i + 4, b + 4] != BOT && GameMassive[i + 4, b + 4] != player)
                        {
                            GameMassive[i + 4, b + 4] = BOT;
                            ALLX[(i + 3) * 11 + b + 15].Visible = true;
                            DiagoneWin_BotMechanics++;
                            Defend = 1;
                            break;
                        }
                    }
                }  
                if(DiagoneWin_BotMechanics> 0) { DiagoneWin_BotMechanics = 0; break; }
            }
            
            
        }
        private void DeffBot()
        {
            
                for (int i = 0; i < 11; i++)
                {
                    for (int b = 0; b < 7; b++)
                    {
                    if (Defend != 1)
                    {
                        if (GameMassive[i, b] == BOT && GameMassive[i, b + 1] == BOT && GameMassive[i, b + 2] == BOT && GameMassive[i, b + 3] == BOT && GameMassive[i, b + 4] != player)
                        {
                            GameMassive[i, b + 4] = BOT;
                            ALLX[i * 11 + b + 4].Visible = true;
                            Defend = 1; break;
                        }
                        else if (i != 0)
                        {
                            if (GameMassive[i, b] == BOT && GameMassive[i, b + 1] == BOT && GameMassive[i, b + 2] == BOT && GameMassive[i, b + 3] == BOT && GameMassive[i, b - 1] != player)
                            {
                                GameMassive[i, b - 1] = BOT;
                                ALLX[i * 11 + b - 1].Visible = true;
                                Defend = 1; break;
                            }
                        }
                        else if (GameMassive[i, b] == player && GameMassive[i, b + 1] == player && GameMassive[i, b + 2] == player && GameMassive[i, b + 4] == player && GameMassive[i, b + 3] != BOT)
                        {
                            GameMassive[i, b + 3] = BOT;
                            ALLX[i * 11 + b + 3].Visible = true;
                            Defend = 1; break;
                        }
                        else if (GameMassive[i, b] == player && GameMassive[i, b + 2] == player && GameMassive[i, b + 3] == player && GameMassive[i, b + 4] == player && GameMassive[i, b + 1] != BOT && i != 0)
                        {
                            GameMassive[i, b + 1] = BOT;
                            ALLX[i * 11 + b + 1].Visible = true;
                            Defend = 1; break;
                        }
                    }
                    }
                    if (Defend == 1) break;
                }
            
            
                for (int i = 0; i < 7; i++)
                {
                    for (int b = 0; b < 11; b++)
                    {
                        if (Defend != 1)
                        {
                            if (GameMassive[i, b] == BOT && GameMassive[i + 1, b] == BOT && GameMassive[i + 2, b] == BOT && GameMassive[i + 3, b] == BOT && GameMassive[i + 4, b] != player)
                            {
                                GameMassive[i + 4, b] = BOT;
                                ALLX[(i + 3) * 11 + b + 11].Visible = true;
                                Defend = 1; break;
                            }
                            else if (i != 0)
                            {
                                if (GameMassive[i, b] == BOT && GameMassive[i + 1, b] == BOT && GameMassive[i + 2, b] == BOT && GameMassive[i + 3, b] == BOT && GameMassive[i - 1, b] != BOT && GameMassive[i - 1, b] != player)
                                {
                                    GameMassive[i - 1, b] = BOT;
                                    ALLX[(i - 1) * 11 + b].Visible = true;
                                    Defend = 1; break;
                                }
                            }
                        else if (GameMassive[i, b] == player && GameMassive[i + 1, b] == player && GameMassive[i + 2, b] == player && GameMassive[i + 4, b] == player && GameMassive[i + 3, b] != BOT)
                        {
                            GameMassive[i + 3, b] = BOT;
                            ALLX[(i + 2) * 11 + b + 11].Visible = true;
                            Defend = 1; break;
                        }
                        else if (GameMassive[i, b] == player && GameMassive[i + 2, b] == player && GameMassive[i + 3, b] == player && GameMassive[i + 4, b] == player && GameMassive[i + 1, b] != BOT && GameMassive[i + 1, b] != player)
                        {
                            GameMassive[i + 1, b] = BOT;
                            ALLX[i * 11 + b + 11].Visible = true;
                            Defend = 1; break;
                        }
                    }
                    }
                    if (Defend == 1) break;
                }
            
           
                for (int i = 0; i < 7; i++)
                {
                    for (int b = 0; b < 7; b++)
                    {
                        if (Defend != 1)
                        {
                            if (GameMassive[i, b] == BOT && GameMassive[i + 1, b + 1] == BOT && GameMassive[i + 2, b + 2] == BOT && GameMassive[i + 3, b + 3] == BOT && GameMassive[i + 4, b + 4] != BOT && GameMassive[i + 4, b + 4] != player)
                            {
                                GameMassive[i + 4, b + 4] = BOT;
                                ALLX[(i + 3) * 11 + b + 15].Visible = true;
                                Defend = 1; break;
                            }
                            else if (i != 0)
                            {
                                if (GameMassive[i, b] == BOT && GameMassive[i + 1, b + 1] == BOT && GameMassive[i + 2, b + 2] == BOT && GameMassive[i + 3, b + 3] == BOT && GameMassive[i - 1, b - 1] != BOT && GameMassive[i - 1, b - 1] != player && i != 0)
                                {
                                    GameMassive[i - 1, b - 1] = BOT;
                                    ALLX[(i - 1) * 11 - 1 + b].Visible = true;
                                    Defend = 1; break;
                                }
                            }
                        else if (GameMassive[i, b] == player && GameMassive[i + 2, b + 2] == player && GameMassive[i + 3, b + 3] == player && GameMassive[i + 4, b + 4] == player && GameMassive[i + 1, b + 1] != BOT && GameMassive[i + 1, b + 1] != player)
                        {
                            GameMassive[i + 1, b + 1] = BOT;
                            ALLX[i * 11 + b + 12].Visible = true;
                            Defend = 1; break;
                        }
                        else if (GameMassive[i, b] == player && GameMassive[i + 1, b + 1] == player && GameMassive[i + 2, b + 2] == player && GameMassive[i + 4, b + 4] == player && GameMassive[i + 3, b + 3] != BOT && GameMassive[i + 3, b + 3] != player && i != 0)
                        {
                            GameMassive[i + 3, b + 3] = BOT;
                            ALLX[(i + 3) * 11 - 1 + b + 3].Visible = true;
                            Defend = 1; break;
                        }
                    }
                    }
                    if (Defend == 1) break;
               }
            for (int i = 0; i < 7; i++)
            {
                for (int b = 4; b < 11; b++)
                {
                    if (Defend != 1)
                    {

                        if (GameMassive[i, b] == BOT && GameMassive[i + 1, b - 1] == BOT && GameMassive[i + 2, b - 2] == BOT && GameMassive[i + 3, b - 3] == BOT && GameMassive[i + 4, b - 4] != BOT && GameMassive[i + 4, b - 4] != player)
                        {
                            GameMassive[i + 4, b - 4] = BOT;
                            ALLX[(i + 3) * 11 + b + 8].Visible = true;
                            Defend = 1; break;
                        }
                        else if (GameMassive[i, b] == BOT && GameMassive[i + 1, b - 1] == BOT && GameMassive[i + 2, b - 2] == BOT && GameMassive[i + 3, b - 3] == BOT && GameMassive[i - 1, b + 1] != BOT && GameMassive[i - 1, b + 1] != player && i != 0)
                        {
                            GameMassive[i - 1, b + 1] = BOT;
                            ALLX[(i - 1) * 11 + 1 + b].Visible = true;
                            Defend = 1; break;
                        }
                        else if (GameMassive[i, b] == BOT && GameMassive[i + 2, b - 2] == BOT && GameMassive[i + 3, b - 3] == BOT && GameMassive[i + 4, b - 4] == BOT && GameMassive[i + 1, b - 1] != BOT && GameMassive[i + 1, b - 1] != player)
                        {
                            GameMassive[i + 1, b - 1] = BOT;
                            ALLX[i * 11 + b + 10].Visible = true;
                            Defend = 1; break;
                        }
                        else if (GameMassive[i, b] == BOT && GameMassive[i + 1, b - 1] == BOT && GameMassive[i + 2, b - 2] == BOT && GameMassive[i + 4, b - 4] == BOT && GameMassive[i + 3, b - 3] != BOT && GameMassive[i + 3, b - 3] != player)
                        {
                            GameMassive[i + 3, b - 3] = BOT;
                            ALLX[(i + 2) * 11 + b + 8].Visible = true;
                            Defend = 1; break;
                        }
                    }
                }
            }







                for (int i = 0; i < 11; i++)
                {
                    for (int b = 0; b < 7; b++)
                    {
                        if (Defend != 1)
                        {
                            if (GameMassive[i, b] == player && GameMassive[i, b + 1] == player && GameMassive[i, b + 2] == player && GameMassive[i, b + 3] == player && GameMassive[i, b + 4] != BOT)
                            {
                                GameMassive[i, b + 4] = BOT;
                                ALLX[i * 11 + b + 4].Visible = true;
                                Defend = 1; break;
                            }
                            else if (GameMassive[i, b] == player && GameMassive[i, b + 1] == player && GameMassive[i, b + 2] == player && GameMassive[i, b + 3] == player && GameMassive[i, b - 1] != BOT && i != 0)
                            {
                                GameMassive[i, b - 1] = BOT;
                                ALLX[i * 11 + b - 1].Visible = true;
                                Defend = 1; break;
                            }
                            else if (GameMassive[i, b] == player && GameMassive[i, b + 1] == player && GameMassive[i, b + 2] == player && GameMassive[i, b + 4] == player && GameMassive[i, b + 3] != BOT)
                            {
                                GameMassive[i, b + 3] = BOT;
                                ALLX[i * 11 + b + 3].Visible = true;
                                Defend = 1; break;
                            }
                            else if (GameMassive[i, b] == player && GameMassive[i, b + 2] == player && GameMassive[i, b + 3] == player && GameMassive[i, b + 4] == player && GameMassive[i, b + 1] != BOT && i != 0)
                            {
                                GameMassive[i, b +1] = BOT;
                                ALLX[i * 11 + b + 1].Visible = true;
                                Defend = 1; break;
                            }
                            else if (GameMassive[i, b] == player && GameMassive[i, b + 1] == player && GameMassive[i, b + 3] == player &&  GameMassive[i, b + 2] != BOT && GameMassive[i, b + 2] != player)
                            {
                                GameMassive[i, b + 2] = BOT;
                                ALLX[i * 11 + b + 2].Visible = true;
                                Defend = 1; break;
                            }
                            else if (GameMassive[i, b] == player && GameMassive[i, b + 2] == player && GameMassive[i, b + 3] == player  && GameMassive[i, b + 1] != BOT && GameMassive[i, b + 1] != player)
                            {
                                GameMassive[i, b + 1] = BOT;
                                ALLX[i * 11 + b + 1].Visible = true;
                                Defend = 1; break;
                            }
                            else if (GameMassive[i, b] == player && GameMassive[i, b + 1] == player && GameMassive[i, b + 2] == player && GameMassive[i, b + 3] != player && GameMassive[i, b + 3] != BOT)
                            {
                                GameMassive[i, b + 3] = BOT;
                                ALLX[i * 11 + b + 3].Visible = true;
                                Defend = 1; break;
                            }
                        }


                    }
                    if (Defend == 1) break;
                }
            
           
                for (int i = 0; i < 7; i++)
                {
                    for (int b = 0; b < 11; b++)
                    {
                        if (Defend != 1)
                        {
                            if (GameMassive[i, b] == player && GameMassive[i + 1, b] == player && GameMassive[i + 2, b] == player && GameMassive[i + 3, b] == player && GameMassive[i + 4, b] != BOT)
                            {
                                GameMassive[i + 4, b] = BOT;
                                ALLX[(i + 3) * 11 + b + 11].Visible = true;
                                Defend = 1; break;
                            }
                            else if (GameMassive[i, b] == player && GameMassive[i + 1, b] == player && GameMassive[i + 2, b] == player && GameMassive[i + 3, b] == player && GameMassive[i - 1, b] != BOT && GameMassive[i - 1, b] != player && i != 0)
                            {
                                GameMassive[i - 1, b] = BOT;
                                ALLX[(i - 1) * 11 + b].Visible = true;
                                Defend = 1; break;
                            }
                            else if (GameMassive[i, b] == player && GameMassive[i + 1, b] == player && GameMassive[i + 2, b] == player && GameMassive[i + 4, b] == player && GameMassive[i + 3, b] != BOT)
                            {
                                GameMassive[i + 3, b] = BOT;
                                ALLX[(i + 2) * 11 + b + 11].Visible = true;
                                Defend = 1; break;
                            }
                            else if (GameMassive[i, b] == player && GameMassive[i + 2, b] == player && GameMassive[i + 3, b] == player && GameMassive[i + 4, b] == player && GameMassive[i +1, b] != BOT && GameMassive[i + 1, b] != player )
                            {
                                GameMassive[i + 1, b] = BOT;
                                ALLX[i * 11 + b + 11].Visible = true;
                                Defend = 1; break;
                            }
                            else if (GameMassive[i, b] == player && GameMassive[i + 1, b] == player && GameMassive[i + 3, b] == player  && GameMassive[i +2, b] != BOT && GameMassive[i + 2, b] != player)
                            {
                                GameMassive[i + 2, b] = BOT;
                                ALLX[(i + 1) * 11 + b + 11].Visible = true;
                                Defend = 1; break;
                            }
                            else if (GameMassive[i, b] == player && GameMassive[i + 2, b] == player && GameMassive[i + 3, b] == player &&  GameMassive[i + 1, b] != BOT && GameMassive[i + 1, b] != player)
                            {
                                GameMassive[i + 1, b] = BOT;
                                ALLX[i * 11 + b + 11].Visible = true;
                                Defend = 1; break;
                            }
                            else if (GameMassive[i, b] == player && GameMassive[i + 1, b] == player && GameMassive[i + 2, b] == player && GameMassive[i + 3, b] != player && GameMassive[i + 3, b] != BOT)
                            {
                                GameMassive[i + 3, b] = BOT;
                                ALLX[(i + 2) * 11 + b + 11].Visible = true;
                                Defend = 1; break;
                            }
                        }


                    }
                    if (Defend == 1) break;
                }
            
            
                for (int i = 0; i < 7; i++)
                {
                    for (int b = 0; b < 7; b++)
                    {
                        if (Defend != 1)
                        {
                            if (GameMassive[i, b] == player && GameMassive[i + 1, b + 1] == player && GameMassive[i + 2, b + 2] == player && GameMassive[i + 3, b + 3] == player && GameMassive[i + 4, b + 4] != BOT && GameMassive[i + 4, b + 4] != player)
                            {
                                GameMassive[i + 4, b + 4] = BOT;
                                ALLX[(i + 3) * 11 + b + 15].Visible = true;
                                Defend = 1; break;
                            }
                            else if (GameMassive[i, b] == player && GameMassive[i + 1, b + 1] == player && GameMassive[i + 2, b + 2] == player && GameMassive[i + 3, b + 3] == player && GameMassive[i - 1, b - 1] != BOT && GameMassive[i - 1, b - 1] != player && i != 0)
                            {
                                GameMassive[i - 1, b - 1] = BOT;
                                ALLX[(i - 1) * 11 - 1 + b].Visible = true;
                                Defend = 1; break;
                            }
                            else if (GameMassive[i, b] == player && GameMassive[i + 2, b +2] == player && GameMassive[i + 3, b + 3] == player && GameMassive[i + 4, b + 4] == player && GameMassive[i + 1, b + 1] != BOT && GameMassive[i + 1, b + 1] != player)
                            {
                                GameMassive[i + 1, b + 1] = BOT;
                                ALLX[i * 11 + b + 12].Visible = true;
                                Defend = 1; break;
                            }
                            else if (GameMassive[i, b] == player && GameMassive[i + 1, b + 1] == player && GameMassive[i + 2, b + 2] == player && GameMassive[i + 4, b + 4] == player && GameMassive[i+3, b +3] != BOT && GameMassive[i + 3, b +3] != player && i != 0)
                            {
                                GameMassive[i +3, b +3] = BOT;
                                ALLX[(i + 3) * 11 - 1 + b+3].Visible = true;
                                Defend = 1; break;
                            }
                        else if (GameMassive[i, b] == player && GameMassive[i + 2, b + 2] == player && GameMassive[i + 3, b + 3] == player && GameMassive[i + 1, b + 1] != player && GameMassive[i + 1, b + 1] != BOT )
                        {
                            GameMassive[i + 1, b + 1] = BOT;
                            ALLX[i * 11 + b + 12].Visible = true;
                            Defend = 1; break;
                        }
                        else if (GameMassive[i, b] == player && GameMassive[i + 1, b + 1] == player && GameMassive[i + 3, b + 3] == player && GameMassive[i + 2, b + 2]!= player && GameMassive[i + 2, b + 2] != BOT )
                        {
                            GameMassive[i + 2, b + 2] = BOT;
                            ALLX[(i + 2) * 11 - 1 + b + 3].Visible = true;
                            Defend = 1; break;
                        }
                        else if (GameMassive[i, b] == player && GameMassive[i + 1, b + 1] == player && GameMassive[i + 2, b + 2] == player && GameMassive[i + 3, b + 3] != player && GameMassive[i + 3, b + 3] != BOT)
                            {
                                GameMassive[i + 3, b + 3] = BOT;
                                ALLX[(i + 2) * 11 + b + 14].Visible = true;
                                Defend = 1; break;
                            }
                        }


                    }
                    if (Defend == 1) break;
                }
            
            
                for (int i = 0; i < 7; i++)
                {
                    for (int b = 4; b < 11; b++)
                    {
                        if (Defend != 1)
                        {
                            
                            if (GameMassive[i, b] == player && GameMassive[i + 1, b - 1] == player && GameMassive[i + 2, b - 2] == player && GameMassive[i + 3, b - 3] == player && GameMassive[i + 4, b - 4] != BOT && GameMassive[i + 4, b - 4] != player)
                            {
                                GameMassive[i + 4, b - 4] = BOT;
                                ALLX[(i + 3) * 11 + b + 8].Visible = true;
                                Defend = 1; break;
                            }
                            else if (GameMassive[i, b] == player && GameMassive[i + 1, b - 1] == player && GameMassive[i + 2, b - 2] == player && GameMassive[i + 3, b - 3] == player && GameMassive[i - 1, b + 1] != BOT && GameMassive[i - 1, b + 1] != player && i != 0)
                            {
                                GameMassive[i - 1, b + 1] = BOT;
                                ALLX[(i - 1) * 11 + 1 + b].Visible = true;
                                Defend = 1; break;
                            }
                        else if (GameMassive[i, b] == player && GameMassive[i + 2, b - 2] == player && GameMassive[i + 3, b - 3] == player && GameMassive[i + 4, b - 4] == player && GameMassive[i + 1, b - 1] != BOT && GameMassive[i + 1, b - 1] != player)
                        {
                            GameMassive[i + 1, b - 1] = BOT;
                            ALLX[i * 11 + b + 10].Visible = true;
                            Defend = 1; break;
                        }
                        else if (GameMassive[i, b] == player && GameMassive[i + 1, b - 1] == player && GameMassive[i + 2, b - 2] == player && GameMassive[i + 4, b - 4] == player && GameMassive[i +3, b -3] != BOT && GameMassive[i + 3, b -3] != player )
                        {
                            GameMassive[i + 3, b - 3] = BOT;
                            ALLX[(i + 2) * 11 + b + 8].Visible = true;
                            Defend = 1; break;
                        }
                            // /////////////////////////////////////////////
                        else if (GameMassive[i, b] == player && GameMassive[i + 2, b - 2] == player && GameMassive[i + 3, b - 3] == player && GameMassive[i + 1, b - 1] != player && GameMassive[i + 1, b - 1] != BOT )
                        {
                            GameMassive[i + 1, b - 1] = BOT;
                            ALLX[i * 11 + b + 10].Visible = true;
                            Defend = 1; break;
                        }
                        else if (GameMassive[i, b] == player && GameMassive[i + 1, b - 1] == player && GameMassive[i + 3, b - 3] == player && GameMassive[i + 2, b - 2] != player && GameMassive[i + 2, b - 2] != BOT )
                        {
                            GameMassive[i + 2, b - 2] = BOT;
                            ALLX[(i + 1) * 11 + b + 9].Visible = true;
                            Defend = 1; break;
                        }
                        else if (GameMassive[i, b] == player && GameMassive[i + 1, b - 1] == player && GameMassive[i + 2, b - 2] == player && GameMassive[i + 3, b - 3] != player && GameMassive[i + 3, b - 3] != BOT)
                        {
                            GameMassive[i + 3, b - 3] = BOT;
                            ALLX[(i + 2) * 11 + b + 8].Visible = true;
                            Defend = 1; break;
                        }
                    }

                    }
                    if (Defend == 1) break;
                }
            
        }

        private void WIN_Mechanicks_AnD_Randrom()
        {
            
            DeffBot();
            if (Defend != 1)
            {
                if (NumBotHid < 5)
                    BotTryWin();
                else if (NumBotHid < 10 && NumBotHid > 5)
                {
                    BotTryWinWertekal();
                }
                else if (NumBotHid > 10 && NumBotHid < 15) BotTrywinDiagonale();

                NumBotHid++;
                if (NumBotHid == 15 || Win == 1) NumBotHid = 0;
            }
            
        }
 
        private void HidBota(int pos1, int pos2, PictureBox leftTop, PictureBox Top, PictureBox rightTop, PictureBox right, PictureBox rigtBot, PictureBox Bot,PictureBox leftBot, PictureBox left)
        {
            int[] PerevirkaMas = new int[8]; 
    

            
            var rand = new Random();
               int Бот = rand.Next(4);
               if (GameMassive[pos1, pos2] == player&& Бот == 1)
               {
                 if ( GameMassive[pos1 + 1, pos2 + 1] != player && GameMassive[pos1 + 1, pos2 + 1] != BOT) { GameMassive[pos1 + 1, pos2 + 1] = BOT; rigtBot.Visible = true; a++; }
                else if ( GameMassive[pos1 + 1, pos2] != player && GameMassive[pos1 + 1, pos2 ] != BOT) { GameMassive[pos1 + 1, pos2] = BOT; Bot.Visible = true; a++; }
                else if  (GameMassive[pos1 + 1, pos2 - 1] != player && GameMassive[pos1 + 1, pos2 - 1] != BOT) { GameMassive[pos1 - 1, pos2 + 1] = BOT; leftBot.Visible = true; a++; }
                else if ( GameMassive[pos1 - 1, pos2 - 1] != player && GameMassive[pos1 - 1, pos2 - 1] != BOT) { GameMassive[pos1 - 1, pos2 - 1] = BOT; leftTop.Visible = true; a++; }
                 else if (  GameMassive[pos1 - 1, pos2] != player && GameMassive[pos1 - 1, pos2] != BOT) { GameMassive[pos1 - 1, pos2] = BOT; Top.Visible = true; a++; }
                 else if (  GameMassive[pos1 - 1, pos2 + 1] != player && GameMassive[pos1 - 1, pos2 + 1] != BOT) { GameMassive[pos1 - 1, pos2 + 1] = BOT; rightTop.Visible = true; a++; }
                 else if ( GameMassive[pos1, pos2 + 1] != player && GameMassive[pos1, pos2 + 1] != BOT) { GameMassive[pos1, pos2 + 1] = BOT; right.Visible = true; a++; }
                
                 else if (   GameMassive[pos1, pos2 - 1] != player) { GameMassive[pos1, pos2 - 1] = BOT; left.Visible = true; a++; }

               }
            else if (GameMassive[pos1, pos2] == player && Бот == 2)
            {
                
                if ( GameMassive[pos1 - 1, pos2] != player && GameMassive[pos1 - 1, pos2] != BOT) { GameMassive[pos1 - 1, pos2] = BOT; Top.Visible = true; a++; }
                else if ( GameMassive[pos1 - 1, pos2 + 1] != player && GameMassive[pos1 - 1, pos2 + 1] != BOT) { GameMassive[pos1 - 1, pos2 + 1] = BOT; rightTop.Visible = true; a++; }
                else if (GameMassive[pos1 - 1, pos2 - 1] != player && GameMassive[pos1 - 1, pos2 - 1] != BOT) { GameMassive[pos1 - 1, pos2 - 1] = BOT; leftTop.Visible = true; a++; }
                else if (GameMassive[pos1 + 1, pos2] != player && GameMassive[pos1 + 1, pos2] != BOT) { GameMassive[pos1 + 1, pos2] = BOT; Bot.Visible = true; a++; }
                else if (GameMassive[pos1 + 1 , pos2 - 1] != player && GameMassive[pos1 - 1, pos2 + 1] != BOT) { GameMassive[pos1 - 1, pos2 + 1] = BOT; leftBot.Visible = true; a++; }
                else if (GameMassive[pos1, pos2 - 1] != player && GameMassive[pos1, pos2 - 1] != BOT) { GameMassive[pos1, pos2 - 1] = BOT; left.Visible = true; a++; }
                else if (GameMassive[pos1, pos2 + 1] != player && GameMassive[pos1, pos2 + 1] != BOT) { GameMassive[pos1, pos2 + 1] = BOT; right.Visible = true; a++; }
                else if (GameMassive[pos1 + 1, pos2 + 1] != player && GameMassive[pos1 + 1, pos2 + 1] != BOT) { GameMassive[pos1 + 1, pos2 + 1] = BOT; rigtBot.Visible = true; a++; }

            }
            else if (GameMassive[pos1, pos2] == player && Бот == 3)
            {
                
                if ( GameMassive[pos1 - 1, pos2 + 1] != player && GameMassive[pos1 - 1, pos2 + 1] != BOT) { GameMassive[pos1 - 1, pos2 + 1] = BOT; rightTop.Visible = true; a++; }
                else if (GameMassive[pos1 + 1, pos2] != player && GameMassive[pos1 + 1, pos2 ] != BOT) { GameMassive[pos1 + 1, pos2] = BOT; Bot.Visible = true; a++; }
                else if ( GameMassive[pos1, pos2 + 1] != player && GameMassive[pos1 , pos2 + 1] != BOT) { GameMassive[pos1, pos2 + 1] = BOT; right.Visible = true; a++; }
                else if ( GameMassive[pos1 + 1, pos2 + 1] != player && GameMassive[pos1 + 1, pos2 + 1] != BOT) { GameMassive[pos1 + 1, pos2 + 1] = BOT; rigtBot.Visible = true; a++; }               
                else if ( GameMassive[pos1 + 1, pos2 - 1] != player && GameMassive[pos1 + 1, pos2 - 1] != BOT) { GameMassive[pos1 - 1, pos2 + 1] = BOT; leftBot.Visible = true; a++; }
                else if ( GameMassive[pos1, pos2 - 1] != player && GameMassive[pos1, pos2 - 1] != BOT) { GameMassive[pos1, pos2 - 1] = BOT; left.Visible = true; a++; }
                else if (GameMassive[pos1 - 1, pos2 - 1] != player && GameMassive[pos1 - 1, pos2 - 1] != BOT) { GameMassive[pos1 - 1, pos2 - 1] = BOT; leftTop.Visible = true; a++; }
                else if (GameMassive[pos1 - 1, pos2] != player && GameMassive[pos1 - 1, pos2 ] != BOT) { GameMassive[pos1 - 1, pos2] = BOT; Top.Visible = true; a++; }

            }
            else 
            {
                if ( GameMassive[pos1 - 1, pos2 - 1] != player&& GameMassive[pos1 - 1, pos2 - 1] != BOT) { GameMassive[pos1 - 1, pos2 - 1] = BOT; leftTop.Visible = true; a++; }
                else if (GameMassive[pos1, pos2 - 1] != player && GameMassive[pos1 , pos2 - 1] != BOT) { GameMassive[pos1, pos2 - 1] = BOT; left.Visible = true; a++; }
                else if (GameMassive[pos1 + 1, pos2 + 1] != player && GameMassive[pos1 + 1, pos2 + 1] != BOT) { GameMassive[pos1 + 1, pos2 + 1] = BOT; rigtBot.Visible = true; a++; }
                else if ( GameMassive[pos1 - 1, pos2] != player && GameMassive[pos1 - 1, pos2 ] != BOT) { GameMassive[pos1 - 1, pos2] = BOT; Top.Visible = true; a++; }
                else if ( GameMassive[pos1 - 1, pos2 + 1] != player && GameMassive[pos1 - 1, pos2 + 1] != BOT) { GameMassive[pos1 - 1, pos2 + 1] = BOT; rightTop.Visible = true; a++; }
                else if ( GameMassive[pos1, pos2 + 1] != player && GameMassive[pos1 , pos2 + 1] != BOT) { GameMassive[pos1, pos2 + 1] = BOT; right.Visible = true; a++; }               
                else if ( GameMassive[pos1 + 1, pos2] != player && GameMassive[pos1 + 1, pos2 ] != BOT) { GameMassive[pos1 + 1, pos2] = BOT; Bot.Visible = true; a++; }
                else if (GameMassive[pos1 + 1, pos2 - 1] != player && GameMassive[pos1 + 1, pos2 - 1] != BOT) { GameMassive[pos1 - 1, pos2 + 1] = BOT; leftBot.Visible = true; a++; }
                

            }

        }
                            
             
          private void BOT_MECHANICS(int I, int B)
          {
            
            Defend = 0;
            

            WIN_Mechanicks_AnD_Randrom();
            if ((I == 0 && B == 0) || (I == 0 && B == 10) || (I == 10 && B == 0) || (I == 10 && B == 10) && Defend != 1)
                Bot_Ygli(I, B);
            else if (I == 0 && B <= 10 && Defend !=1)
                LiniiBot(I, B);
            else if (I <= 10 && B == 0 && Defend != 1)
                leftLiniiys(I, B);
            else if (I==10 && B<=10 && Defend != 1)
             LiniiBotTop(I, B);
            else if(I<=10 && B==10 && Defend != 1)
                rightlinia(I, B);
            else if(Defend != 1)
                HidBota(I, B, ALLX[(I - 1) * 11 - 1 + B], ALLX[(I - 1) * 11 + B], ALLX[(I - 1) * 11 + 1 + B], ALLX[I * 11 + B + 1], ALLX[I * 11 + B + 12], ALLX[I * 11 + B + 11], ALLX[I * 11 + B + 10], ALLX[I * 11 - 1 + B]);
                                 

                                
            
          }
                            private void ChekWin(string XorO)
                            {
                                for (int i = 0; i < 11; i++)
                                {
                                    for (int b = 0; b < 7; b++)
                                    {
                                        if (GameMassive[i, b] == XorO && GameMassive[i, b + 1] == XorO && GameMassive[i, b + 2] == XorO && GameMassive[i, b + 3] == XorO && GameMassive[i, b + 4] == XorO)
                                        {
                                            MessageBox.Show("Виграв " + XorO);
                                            Win = 1; peremogaBota = 0;
                    }
                                    }
                                }
                                for (int b = 0; b < 11; b++)
                                {
                                    for (int i = 0; i < 7; i++)
                                    {
                                        if (GameMassive[i, b] == XorO && GameMassive[i + 1, b] == XorO && GameMassive[i + 2, b] == XorO && GameMassive[i + 3, b] == XorO && GameMassive[i + 4, b] == XorO)
                                        {
                                            MessageBox.Show("Виграв " + XorO);
                                            Win = 1; peremogaBota = 0;
                    }
                                    }
                                }
                                for (int b = 0; b < 7; b++)
                                {
                                    for (int i = 0; i < 7; i++)
                                    {
                                        if (GameMassive[i, b] == XorO && GameMassive[i + 1, b + 1] == XorO && GameMassive[i + 2, b + 2] == XorO && GameMassive[i + 3, b + 3] == XorO && GameMassive[i + 4, b + 4] == XorO)
                                        {
                                            MessageBox.Show("Виграв " + XorO);
                                            Win = 1; peremogaBota = 0;
                    }
                                    }
                                }
                                for (int b = 0; b < 7; b++)
                                {
                                    for (int i = 0; i < 7; i++)
                                    {
                                        if (GameMassive[b + 4, i] == XorO && GameMassive[b + 3, i + 1] == XorO && GameMassive[b + 2, i + 2] == XorO && GameMassive[b + 1, i + 3] == XorO && GameMassive[b, i + 4] == XorO)
                                        {
                                            MessageBox.Show("Виграв " + XorO);
                                            Win = 1;
                        peremogaBota = 0;
                                        }
                                    }
                                }
            if (Win == 1)
            {
                for (int i = 0; i < 121; i++)
                {
                    ALLX[i].Visible = false;
                }
            }
            //if (player == "O") player = "X";
            //else if (player == "X") player = "O";
        }
                            private void EndGame(List<PictureBox> Del, List<PictureBox> Addd)
                            {

                                for (int i = 0; i < Del.Count; i++)
                                {
                                    Del[i].Visible = false;
                                }
                                for (int i = 0; i < Addd.Count; i++)
                                {
                                    Addd[i].Visible = true;
                                }
                                for (int i = 0; i < 11; i++)
                                {
                                    for (int b = 0; b < 11; b++)
                                    {
                                        GameMassive[i, b] = string.Empty;
                                    }
                                }

                            }


                            List<PictureBox> Ydal = new List<PictureBox>();
                            List<PictureBox> VisTrue = new List<PictureBox>();
                            public void PressAnyButtonPlayer(PictureBox хрестик, PictureBox noluk, PictureBox кнопка, int i1, int i2)
                            {
                                номерХоду++;
                                if (player == "O") { noluk.Visible = true; кнопка.Visible = false; }

                                //if (player == "X") { хрестик.Visible = true; кнопка.Visible = false; }
                                ChekWin(player);
                                BOT_MECHANICS(i1, i2);
                                ChekWin(BOT);

                                Ydal.Add(noluk);
                                Ydal.Add(хрестик);
                                VisTrue.Add(кнопка);
                                if (Win == 1)
                                {
                                    EndGame(Ydal, VisTrue);
                                    Win = 0;
                                }

                            }

                            public void generetion_map()
                            {
                                for (int i = 0; i <= _hight / SizeOfSide; i++)
                                {
                                    PictureBox picte = new PictureBox();
                                    picte.BackColor = Color.Black;
                                    picte.Location = new Point(0, SizeOfSide * i);
                                    picte.Size = new Size(_weight - 100, 1);
                                    this.Controls.Add(picte);

                                }
                                for (int i = 0; i <= _weight / SizeOfSide; i++)
                                {
                                    PictureBox picte = new PictureBox();
                                    picte.BackColor = Color.Black;
                                    picte.Location = new Point(SizeOfSide * i, 0);
                                    picte.Size = new Size(1, _weight - 100);
                                    this.Controls.Add(picte);
                                }
                            }


                            private void pictureBox1_Click(object sender, EventArgs e)
                            {

                            }

                            private void pictureBox1_Click_1(object sender, EventArgs e)
                            {
                                GameMassive[0, 0] = player;
                                PressAnyButtonPlayer(Xx00, Ox1, XY00, 0, 0);
                            }

                            private void XX2_Click(object sender, EventArgs e)
                            {

                            }

                            private void Form1_Load(object sender, EventArgs e)
                            {

                            }



                            //Перша лінія гри!!!!!!!!!!!!!!!!!!!!!1
                            private void X1_Click(object sender, EventArgs e)
                            {


                                GameMassive[0, 1] = player;
                                PressAnyButtonPlayer(XX1, OO1, X1, 0, 1);


                            }
                            private void X2_Click(object sender, EventArgs e)
                            {


                                GameMassive[0, 2] = player;
                                PressAnyButtonPlayer(XX2, OO2, X2, 0, 2);

                            }
                            private void X3_Click(object sender, EventArgs e)
                            {
                                GameMassive[0, 3] = player;
                                PressAnyButtonPlayer(XX3, OO3, X3, 0, 3);
                            }
                            private void X4_Click(object sender, EventArgs e)
                            {
                                GameMassive[0, 4] = player;
                                PressAnyButtonPlayer(XX4, OO4, X4, 0, 4);
                            }
                            private void X5_Click(object sender, EventArgs e)
                            {
                                GameMassive[0, 5] = player;
                                PressAnyButtonPlayer(XX5, OO5, X5, 0, 5);
                            }
                            private void X6_Click(object sender, EventArgs e)
                            {
                                GameMassive[0, 6] = player;
                                PressAnyButtonPlayer(XX6, OO6, X6, 0, 6);
                            }
                            private void X7_Click(object sender, EventArgs e)
                            {
                                GameMassive[0, 7] = player;
                                PressAnyButtonPlayer(XX7, OO7, X7, 0, 7);
                            }
                            private void X8_Click(object sender, EventArgs e)
                            {
                                GameMassive[0, 8] = player;
                                PressAnyButtonPlayer(XX8, OO8, X8, 0, 8);
                            }
                            private void X9_Click(object sender, EventArgs e)
                            {
                                GameMassive[0, 9] = player;
                                PressAnyButtonPlayer(XX9, OO9, X9, 0, 9);
                            }

                            private void X10_Click(object sender, EventArgs e)
                            {
                                GameMassive[0, 10] = player;
                                PressAnyButtonPlayer(XX10, OO10, X10, 0, 10);
                            }


                            // Друга лінія гри!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


                            private void Y1_Click(object sender, EventArgs e)
                            {
                                GameMassive[1, 0] = player;
                                PressAnyButtonPlayer(Xx01, Ox2, Y1, 1, 0);
                            }
                            private void XY11_Click(object sender, EventArgs e)
                            {
                                GameMassive[1, 1] = player;
                                PressAnyButtonPlayer(XX11, OO11, XY11, 1, 1);
                            }
                            private void XY12_Click(object sender, EventArgs e)
                            {
                                GameMassive[1, 2] = player;
                                PressAnyButtonPlayer(XX12, OO12, XY12, 1, 2);
                            }

                            private void XY13_Click(object sender, EventArgs e)
                            {
                                GameMassive[1, 3] = player;
                                PressAnyButtonPlayer(XX13, OO13, XY13, 1, 3);
                            }

                            private void XY14_Click(object sender, EventArgs e)
                            {
                                GameMassive[1, 4] = player;
                                PressAnyButtonPlayer(XX14, OO14, XY14, 1, 4);
                            }

                            private void XY15_Click(object sender, EventArgs e)
                            {
                                GameMassive[1, 5] = player;
                                PressAnyButtonPlayer(XX15, OO15, XY15, 1, 5);
                            }

                            private void XY16_Click(object sender, EventArgs e)
                            {
                                GameMassive[1, 6] = player;
                                PressAnyButtonPlayer(XX16, OO16, XY16, 1, 6);
                            }

                            private void XY17_Click(object sender, EventArgs e)
                            {
                                GameMassive[1, 7] = player;
                                PressAnyButtonPlayer(XX17, OO17, XY17, 1, 7);
                            }

                            private void XY18_Click(object sender, EventArgs e)
                            {
                                GameMassive[1, 8] = player;
                                PressAnyButtonPlayer(XX18, OO18, XY18, 1, 8);
                            }

                            private void XY19_Click(object sender, EventArgs e)
                            {
                                GameMassive[1, 9] = player;
                                PressAnyButtonPlayer(XX19, OO19, XY19, 1, 9);
                            }

                            private void XY110_Click(object sender, EventArgs e)
                            {
                                GameMassive[1, 10] = player;
                                PressAnyButtonPlayer(XX110, OO110, XY110, 1, 10);
                            }



                            // ТРЕТЯ ЛІНІЯ!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


                            private void Y2_Click(object sender, EventArgs e)
                            {
                                GameMassive[2, 0] = player;
                                PressAnyButtonPlayer(Xx02, Ox3, Y2, 2, 0);
                            }

                            private void XY21_Click(object sender, EventArgs e)
                            {
                                GameMassive[2, 1] = player;
                                PressAnyButtonPlayer(XX21, OO21, XY21, 2, 1);
                            }

                            private void XY22_Click(object sender, EventArgs e)
                            {
                                GameMassive[2, 2] = player;
                                PressAnyButtonPlayer(XX22, OO22, XY22, 2, 2);
                            }

                            private void XY23_Click(object sender, EventArgs e)
                            {
                                GameMassive[2, 3] = player;
                                PressAnyButtonPlayer(XX23, OO23, XY23, 2, 3);
                            }

                            private void XY24_Click(object sender, EventArgs e)
                            {
                                GameMassive[2, 4] = player;
                                PressAnyButtonPlayer(XX24, OO24, XY24, 2, 4);
                            }

                            private void XY25_Click(object sender, EventArgs e)
                            {
                                GameMassive[2, 5] = player;
                                PressAnyButtonPlayer(XX25, OO25, XY25, 2, 5);
                            }

                            private void XY26_Click(object sender, EventArgs e)
                            {
                                GameMassive[2, 6] = player;
                                PressAnyButtonPlayer(XX26, OO26, XY26, 2, 6);
                            }

                            private void XY27_Click(object sender, EventArgs e)
                            {
                                GameMassive[2, 7] = player;
                                PressAnyButtonPlayer(XX27, OO27, XY27, 2, 7);
                            }

                            private void XY28_Click(object sender, EventArgs e)
                            {
                                GameMassive[2, 8] = player;
                                PressAnyButtonPlayer(XX28, OO28, XY28, 2, 8);
                            }

                            private void XY29_Click(object sender, EventArgs e)
                            {
                                GameMassive[2, 9] = player;
                                PressAnyButtonPlayer(XX29, OO29, XY29, 2, 9);
                            }

                            private void XY210_Click(object sender, EventArgs e)
                            {
                                GameMassive[2, 10] = player;
                                PressAnyButtonPlayer(XX210, OO210, XY210, 2, 10);
                            }


                            // четвертий рядок!!!!!!!!!

                            private void Y3_Click(object sender, EventArgs e)
                            {
                                GameMassive[3, 0] = player;
                                PressAnyButtonPlayer(Y3X, Ox4, Y3, 3, 0);
                            }

                            private void XY31_Click(object sender, EventArgs e)
                            {
                                GameMassive[3, 1] = player;
                                PressAnyButtonPlayer(XX31, OO31, XY31, 3, 1);
                            }

                            private void XY32_Click(object sender, EventArgs e)
                            {
                                GameMassive[3, 2] = player;
                                PressAnyButtonPlayer(XX32, OO32, XY32, 3, 2);
                            }

                            private void XY33_Click(object sender, EventArgs e)
                            {
                                GameMassive[3, 3] = player;
                                PressAnyButtonPlayer(XX33, OO33, XY33, 3, 3);
                            }

                            private void XY34_Click(object sender, EventArgs e)
                            {
                                GameMassive[3, 4] = player;
                                PressAnyButtonPlayer(XX34, OO34, XY34, 3, 4);
                            }

                            private void XY35_Click(object sender, EventArgs e)
                            {
                                GameMassive[3, 5] = player;
                                PressAnyButtonPlayer(XX35, OO35, XY35, 3, 5);
                            }

                            private void XY36_Click(object sender, EventArgs e)
                            {
                                GameMassive[3, 6] = player;
                                PressAnyButtonPlayer(XX36, OO36, XY36, 3, 6);
                            }

                            private void XY37_Click(object sender, EventArgs e)
                            {
                                GameMassive[3, 7] = player;
                                PressAnyButtonPlayer(XX37, OO37, XY37, 3, 7);
                            }

                            private void XY38_Click(object sender, EventArgs e)
                            {
                                GameMassive[3, 8] = player;
                                PressAnyButtonPlayer(XX38, OO38, XY38, 3, 8);
                            }

                            private void XY39_Click(object sender, EventArgs e)
                            {
                                GameMassive[3, 9] = player;
                                PressAnyButtonPlayer(XX39, OO39, XY39, 3, 9);
                            }

                            private void XY310_Click(object sender, EventArgs e)
                            {
                                GameMassive[3, 10] = player;
                                PressAnyButtonPlayer(XX310, OO310, XY310, 3, 10);
                            }


                            //П'ятий рядок!!!!!!!!

                            private void Y4_Click(object sender, EventArgs e)
                            {

                                GameMassive[4, 0] = player;
                                PressAnyButtonPlayer(Y4X, Ox5, Y4, 4, 0);

                            }

                            private void XY41_Click(object sender, EventArgs e)
                            {
                                GameMassive[4, 1] = player;
                                PressAnyButtonPlayer(XX41, OO41, XY41, 4, 1);
                            }

                            private void XY42_Click(object sender, EventArgs e)
                            {
                                GameMassive[4, 2] = player;
                                PressAnyButtonPlayer(XX42, OO42, XY42, 4, 2);
                            }

                            private void XY43_Click(object sender, EventArgs e)
                            {
                                GameMassive[4, 3] = player;
                                PressAnyButtonPlayer(XX43, OO43, XY43, 4, 3);
                            }

                            private void XY44_Click(object sender, EventArgs e)
                            {
                                GameMassive[4, 4] = player;
                                PressAnyButtonPlayer(XX44, OO44, XY44, 4, 4);
                            }

                            private void XY45_Click(object sender, EventArgs e)
                            {
                                GameMassive[4, 5] = player;
                                PressAnyButtonPlayer(XX45, OO45, XY45, 4, 5);
                            }

                            private void XY46_Click(object sender, EventArgs e)
                            {
                                GameMassive[4, 6] = player;
                                PressAnyButtonPlayer(XX46, OO46, XY46, 4, 6);
                            }

                            private void XY47_Click(object sender, EventArgs e)
                            {
                                GameMassive[4, 7] = player;
                                PressAnyButtonPlayer(XX47, OO47, XY47, 4, 7);
                            }

                            private void XY48_Click(object sender, EventArgs e)
                            {
                                if (GameMassive[4, 8] != BOT)
                                {
                                    GameMassive[4, 8] = player;
                                    PressAnyButtonPlayer(XX48, OO48, XY48, 4, 8);
                                }
                            }

                            private void XY49_Click(object sender, EventArgs e)
                            {
                                GameMassive[4, 9] = player;
                                PressAnyButtonPlayer(XX49, OO49, XY49, 4, 9);
                            }

                            private void XY410_Click(object sender, EventArgs e)
                            {
                                GameMassive[4, 10] = player;
                                PressAnyButtonPlayer(XX410, OO410, XY410, 4, 10);
                            }


                            // Шостий рядок!!!!!!!!!!!!!!!!!!!!

                            private void Y5_Click(object sender, EventArgs e)
                            {
                                GameMassive[5, 0] = player;
                                PressAnyButtonPlayer(Y5X, Ox6, Y5, 5, 0);
                            }

                            private void XY51_Click(object sender, EventArgs e)
                            {
                                GameMassive[5, 1] = player;
                                PressAnyButtonPlayer(XX51, OO51, XY51, 5, 1);
                            }

                            private void XY52_Click(object sender, EventArgs e)
                            {
                                GameMassive[5, 2] = player;
                                PressAnyButtonPlayer(XX52, OO52, XY52, 5, 2);
                            }

                            private void XY53_Click(object sender, EventArgs e)
                            {
                                GameMassive[5, 3] = player;
                                PressAnyButtonPlayer(XX53, OO53, XY53, 5, 3);
                            }

                            private void XY54_Click(object sender, EventArgs e)
                            {
                                GameMassive[5, 4] = player;
                                PressAnyButtonPlayer(XX54, OO54, XY54, 5, 4);
                            }

                            private void XY55_Click(object sender, EventArgs e)
                            {
                                GameMassive[5, 5] = player;
                                PressAnyButtonPlayer(XX55, OO55, XY55, 5, 5);
                            }

                            private void XY56_Click(object sender, EventArgs e)
                            {
                                GameMassive[5, 6] = player;
                                PressAnyButtonPlayer(XX56, OO56, XY56, 5, 6);
                            }

                            private void XY57_Click(object sender, EventArgs e)
                            {
                                GameMassive[5, 7] = player;
                                PressAnyButtonPlayer(XX57, OO57, XY57, 5, 7);
                            }

                            private void XY58_Click(object sender, EventArgs e)
                            {
                                GameMassive[5, 8] = player;
                                PressAnyButtonPlayer(XX58, OO58, XY58, 5, 8);
                            }

                            private void XY59_Click(object sender, EventArgs e)
                            {
                                GameMassive[5, 9] = player;
                                PressAnyButtonPlayer(XX59, OO59, XY59, 5, 9);
                            }

                            private void XY510_Click(object sender, EventArgs e)
                            {
                                GameMassive[5, 10] = player;
                                PressAnyButtonPlayer(XX510, OO510, XY510, 5, 10);
                            }

                            //Сьома лінійка

                            private void Y6_Click(object sender, EventArgs e)
                            {
                                GameMassive[6, 0] = player;
                                PressAnyButtonPlayer(Y6X, Ox7, Y6, 6, 0);
                            }

                            private void XY61_Click(object sender, EventArgs e)
                            {
                                GameMassive[6, 1] = player;
                                PressAnyButtonPlayer(XX61, OO61, XY61, 6, 1);
                            }

                            private void XY62_Click(object sender, EventArgs e)
                            {
                                GameMassive[6, 2] = player;
                                PressAnyButtonPlayer(XX62, OO62, XY62, 6, 2);
                            }

                            private void XY63_Click(object sender, EventArgs e)
                            {
                                GameMassive[6, 3] = player;
                                PressAnyButtonPlayer(XX63, OO63, XY63, 6, 3);
                            }

                            private void XY64_Click(object sender, EventArgs e)
                            {
                                GameMassive[6, 4] = player;
                                PressAnyButtonPlayer(XX64, OO64, XY64, 6, 4);
                            }

                            private void XY65_Click(object sender, EventArgs e)
                            {
                                GameMassive[6, 5] = player;
                                PressAnyButtonPlayer(XX65, OO65, XY65, 6, 5);
                            }

                            private void XY66_Click(object sender, EventArgs e)
                            {
                                GameMassive[6, 6] = player;
                                PressAnyButtonPlayer(XX66, OO66, XY66, 6, 6);
                            }

                            private void XY67_Click(object sender, EventArgs e)
                            {
                                GameMassive[6, 7] = player;
                                PressAnyButtonPlayer(XX67, OO67, XY67, 6, 7);
                            }

                            private void XY68_Click(object sender, EventArgs e)
                            {
                                GameMassive[6, 8] = player;
                                PressAnyButtonPlayer(XX68, OO68, XY68, 6, 8);
                            }

                            private void XY69_Click(object sender, EventArgs e)
                            {
                                GameMassive[6, 9] = player;
                                PressAnyButtonPlayer(XX69, OO69, XY69, 6, 9);
                            }

                            private void XY610_Click(object sender, EventArgs e)
                            {
                                GameMassive[6, 10] = player;
                                PressAnyButtonPlayer(XX610, OO610, XY610, 6, 10);
                            }


                            // ВОСЬМИЙ РЯДОК

                            private void Y7_Click(object sender, EventArgs e)
                            {
                                GameMassive[7, 0] = player;
                                PressAnyButtonPlayer(Y7X, Ox8, Y7, 7, 0);
                            }

                            private void XY71_Click(object sender, EventArgs e)
                            {
                                GameMassive[7, 1] = player;
                                PressAnyButtonPlayer(XX71, OO71, XY71, 7, 1);
                            }

                            private void XY72_Click(object sender, EventArgs e)
                            {
                                GameMassive[7, 2] = player;
                                PressAnyButtonPlayer(XX72, OO72, XY72, 7, 2);
                            }

                            private void XY73_Click(object sender, EventArgs e)
                            {
                                GameMassive[7, 3] = player;
                                PressAnyButtonPlayer(XX73, OO73, XY73, 7, 3);
                            }

                            private void XY74_Click(object sender, EventArgs e)
                            {
                                GameMassive[7, 4] = player;
                                PressAnyButtonPlayer(XX74, OO74, XY74, 7, 4);
                            }

                            private void XY75_Click(object sender, EventArgs e)
                            {
                                GameMassive[7, 5] = player;
                                PressAnyButtonPlayer(XX75, OO75, XY75, 7, 5);
                            }

                            private void XY76_Click(object sender, EventArgs e)
                            {
                                GameMassive[7, 6] = player;
                                PressAnyButtonPlayer(XX76, OO76, XY76, 7, 6);
                            }

                            private void XY77_Click(object sender, EventArgs e)
                            {
                                GameMassive[7, 7] = player;
                                PressAnyButtonPlayer(XX77, OO77, XY77, 7, 7);
                            }

                            private void XY78_Click(object sender, EventArgs e)
                            {
                                GameMassive[7, 8] = player;
                                PressAnyButtonPlayer(XX78, OO78, XY78, 7, 8);
                            }

                            private void XY79_Click(object sender, EventArgs e)
                            {
                                GameMassive[7, 9] = player;
                                PressAnyButtonPlayer(XX79, OO79, XY79, 7, 9);
                            }

                            private void XY710_Click(object sender, EventArgs e)
                            {
                                GameMassive[7, 10] = player;
                                PressAnyButtonPlayer(XX710, OO710, XY710, 7, 10);
                            }


                            // ДЕВятий рядок

                            private void Y8_Click(object sender, EventArgs e)
                            {
                                GameMassive[8, 0] = player;
                                PressAnyButtonPlayer(Y8X, Ox9, Y8, 8, 0);
                            }

                            private void XY81_Click(object sender, EventArgs e)
                            {
                                GameMassive[8, 1] = player;
                                PressAnyButtonPlayer(XX81, OO81, XY81, 8, 1);
                            }

                            private void XY82_Click(object sender, EventArgs e)
                            {
                                GameMassive[8, 2] = player;
                                PressAnyButtonPlayer(XX82, OO82, XY82, 8, 2);
                            }

                            private void XY83_Click(object sender, EventArgs e)
                            {
                                GameMassive[8, 3] = player;
                                PressAnyButtonPlayer(XX83, OO83, XY83, 8, 3);
                            }

                            private void XY84_Click(object sender, EventArgs e)
                            {
                                GameMassive[8, 4] = player;
                                PressAnyButtonPlayer(XX84, OO84, XY84, 8, 4);
                            }

                            private void XY85_Click(object sender, EventArgs e)
                            {
                                GameMassive[8, 5] = player;
                                PressAnyButtonPlayer(XX85, OO85, XY85, 8, 5);
                            }

                            private void XY86_Click(object sender, EventArgs e)
                            {
                                GameMassive[8, 6] = player;
                                PressAnyButtonPlayer(XX86, OO86, XY86, 8, 6);
                            }

                            private void XY87_Click(object sender, EventArgs e)
                            {
                                GameMassive[8, 7] = player;
                                PressAnyButtonPlayer(XX87, OO87, XY87, 8, 7);
                            }

                            private void XY88_Click(object sender, EventArgs e)
                            {
                                GameMassive[8, 8] = player;
                                PressAnyButtonPlayer(XX88, OO88, XY88, 8, 8);
                            }

                            private void XY89_Click(object sender, EventArgs e)
                            {
                                GameMassive[8, 9] = player;
                                PressAnyButtonPlayer(XX89, OO89, XY89, 8, 9);
                            }

                            private void XY810_Click(object sender, EventArgs e)
                            {
                                GameMassive[8, 10] = player;
                                PressAnyButtonPlayer(XX810, OO810, XY810, 8, 10);
                            }


                            //ДЕСЯТИЙ РЯДОК

                            private void Y9_Click(object sender, EventArgs e)
                            {
                                GameMassive[9, 0] = player;
                                PressAnyButtonPlayer(Y9X, Ox10, Y9, 9, 0);
                            }

                            private void XY91_Click(object sender, EventArgs e)
                            {
                                GameMassive[9, 1] = player;
                                PressAnyButtonPlayer(XX91, OO91, XY91, 9, 1);
                            }

                            private void XY92_Click(object sender, EventArgs e)
                            {
                                GameMassive[9, 2] = player;
                                PressAnyButtonPlayer(XX92, OO92, XY92, 9, 2);
                            }

                            private void XY93_Click(object sender, EventArgs e)
                            {
                                GameMassive[9, 3] = player;
                                PressAnyButtonPlayer(XX93, OO93, XY93, 9, 3);
                            }

                            private void XY94_Click(object sender, EventArgs e)
                            {
                                GameMassive[9, 4] = player;
                                PressAnyButtonPlayer(XX94, OO94, XY94, 9, 4);
                            }

                            private void XY95_Click(object sender, EventArgs e)
                            {
                                GameMassive[9, 5] = player;
                                PressAnyButtonPlayer(XX95, OO95, XY95, 9, 5);
                            }

                            private void XY96_Click(object sender, EventArgs e)
                            {
                                GameMassive[9, 6] = player;
                                PressAnyButtonPlayer(XX96, OO96, XY96, 9, 6);
                            }

                            private void XY97_Click(object sender, EventArgs e)
                            {
                                GameMassive[9, 7] = player;
                                PressAnyButtonPlayer(XX97, OO97, XY97, 9, 7);
                            }

                            private void XY98_Click(object sender, EventArgs e)
                            {
                                GameMassive[9, 8] = player;
                                PressAnyButtonPlayer(XX98, OO98, XY98, 9, 8);
                            }

                            private void XY99_Click(object sender, EventArgs e)
                            {
                                GameMassive[9, 9] = player;
                                PressAnyButtonPlayer(XX99, OO99, XY99, 9, 9);
                            }

                            private void XY910_Click(object sender, EventArgs e)
                            {
                                GameMassive[9, 10] = player;
                                PressAnyButtonPlayer(XX910, OO910, XY910, 9, 10);
                            }


                            // Одинадцятий рядок

                            private void Y10_Click(object sender, EventArgs e)
                            {
                                GameMassive[10, 0] = player;
                                PressAnyButtonPlayer(Y10X, Ox11, Y10, 10, 0);
                            }

                            private void XY101_Click(object sender, EventArgs e)
                            {
                                GameMassive[10, 1] = player;
                                PressAnyButtonPlayer(XX101, OO101, XY101, 10, 1);
                            }

                            private void XY102_Click(object sender, EventArgs e)
                            {
                                GameMassive[10, 2] = player;
                                PressAnyButtonPlayer(XX102, OO102, XY102, 10, 2);
                            }

                            private void XY103_Click(object sender, EventArgs e)
                            {
                                GameMassive[10, 3] = player;
                                PressAnyButtonPlayer(XX103, OO103, XY103, 10, 3);
                            }

                            private void XY104_Click(object sender, EventArgs e)
                            {
                                GameMassive[10, 4] = player;
                                PressAnyButtonPlayer(XX104, OO104, XY104, 10, 4);
                            }

                            private void XY105_Click(object sender, EventArgs e)
                            {
                                GameMassive[10, 5] = player;
                                PressAnyButtonPlayer(XX105, OO105, XY105, 10, 5);
                            }

                            private void XY106_Click(object sender, EventArgs e)
                            {
                                GameMassive[10, 6] = player;
                                PressAnyButtonPlayer(XX106, OO106, XY106, 10, 6);
                            }

                            private void XY107_Click(object sender, EventArgs e)
                            {
                                GameMassive[10, 7] = player;
                                PressAnyButtonPlayer(XX107, OO107, XY107, 10, 7);
                            }

                            private void XY108_Click(object sender, EventArgs e)
                            {
                                GameMassive[10, 8] = player;
                                PressAnyButtonPlayer(XX108, OO108, XY108, 10, 8);
                            }

                            private void XY109_Click(object sender, EventArgs e)
                            {
                                GameMassive[10, 9] = player;
                                PressAnyButtonPlayer(XX109, OO109, XY109, 10, 9);
                            }

                            private void XY1010_Click(object sender, EventArgs e)
                            {
                                GameMassive[10, 10] = player;
                                PressAnyButtonPlayer(XX1010, OO1010, XY1010, 10, 10);
                            }

                            private void pictureBox3_Click(object sender, EventArgs e)
                            {

                            }
    }
}
