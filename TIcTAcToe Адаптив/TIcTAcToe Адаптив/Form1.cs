using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//asdfasdfsdfsfdas

namespace TIcTAcToe_Адаптив
{
	public partial class Form1 : Form
	{
		static int N = 1;
		// це поле яке показує скільки обьєктів має бути в ряд щоб виграти
		static int WinIN = 3;
		// Масив карти
		char[,] dataMAP = new char[N, N];
		List<PictureBox> pictureBoxes = new List<PictureBox>();

		char Player = 'X', BOT = 'O';
		static int STARTposX = 10, STARTposY = 10;
		static sbyte SIZE = 100;

		Random rand = new Random();

		// Масив в якому галочки ставлятся якщо для прикладу є 3 в ряд а WinIN = 3
		byte[] ChekingForWin = new byte[WinIN];

		byte x = 0, y = 0;

		string HID = "Player";

		public Form1()
		{
			InitializeComponent();
			CreateMAP();


			TIMER.Interval += 900;
			TIMER.Tick += new EventHandler(TIMER_Tick);
		}

		public void CreateMAP()
		{
			for(int i = 0; i < N; i++)
			{
				for(int b= 0; b < N; b++)
				{
					PictureBox pic = new PictureBox();

					pic.Name = i.ToString()+ "_" + b.ToString(); 
					pic.Size = new Size(SIZE, SIZE);
					pic.Location = new Point(STARTposX, STARTposY);
					pic.BackColor = Color.LightGray;
					pic.Click += new EventHandler(OnClick);

					pictureBoxes.Add(pic);
					// Завдяки Controls додаєтся на екран цей PicBox
					this.Controls.Add(pic);
					// зразу змінюємо наступні дані для локації наступного picbox
					STARTposX += SIZE + 5;
				}
				STARTposX = 10;
				STARTposY += SIZE + 5; 
			}

		}

		private void OnClick(object sender, EventArgs e)
		{
			PictureBox pic = sender as PictureBox;

			if (HID != "BOT" && pic.BackColor != Color.Green && pic.BackColor != Color.Red)
			{
				TakeLocation(pic, ref x, ref y);

				Image imageToe = Image.FromFile(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "toe.png"));

                dataMAP[x, y] = Player;
				pictureBoxes[(x - 1) * N + y + N].BackColor = Color.Green;
				
				pictureBoxes[(x - 1) * N + y + N].SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxes[(x - 1) * N + y + N].Image = imageToe;
                //pictureBoxes[(x - 1) * N + y + N].AutoSize = true;
                //pictureBoxes[(x - 1) * N + y + N].Size = pictureBoxes[(x - 1) * N + y + N].Image.Size;
                HID = "BOT";
				TIMER.Start();
			}
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
				if(HelpBool)
                    _ = helpChar != '_' ? result2 += helpChar.ToString() : helpChar.ToString();
				else
                    result1 += helpChar.ToString();
            }

				x = Byte.Parse(result1);
				y = Byte.Parse(result2);
		}

		private void ChechWho_WinGame(int CountCubeForWin, char PlayerOrBot)
		{
			for(int i = 0; i < N; i++)
			{
				for(int j=0; j < N; j++)
				{
					//if (pictureBoxes[i].BackColor == )

				}
			}
		}



		//		___     __   _______           
		//		-  -  -    -    |
		//		---   -    -    |
		//		-  -  -    -    |
		//		---     --	    |



		private void Level1_RANDOM()
		{
			if (HID != "Player")
			{

				int random = rand.Next(N * N);

				if (pictureBoxes[random].BackColor == Color.LightGray)
				{
					TakeLocation(pictureBoxes[random], ref x, ref y);
					pictureBoxes[random].BackColor = Color.Red;
					dataMAP[x, y] = BOT;
					HID = "Player";
					return;
				}
				else
					//HID = "Player";
				Level1_RANDOM();

			}
			//GC.Collect();
		}
	}
}
