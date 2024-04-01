using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plat.World
{
    public partial class Form3 : Form
    {
        const int n = 3;
        const int sizeButton = 50;

        public int[,] map = new int[n * n, n * n];

        public Button[,] buttons = new Button[n * n, n * n];

        public Form3()
        {
            InitializeComponent();
            GenerateMap();
        }

        public void GenerateMap()
        {
            for (int i = 0; i < n * n; i++)
            {
                for (int j = 0; j < n * n; j++)
                {
                    map[i, j] = (i * n + i / n + j) % (n * n) + 1;
                    buttons[i, j] = new Button();
                }
            }
            /*MatrixTransosition();
            SwapRowsInBlock();
            SwapColumnsInBlock();
            SwapBlocksInRows();
            SwapBlocksInColumns();*/ // было вызвано для проверки работоспособности
            Random r = new Random();
            for (int i =0;i<10;i++)
            {
                ShuffleMap(r.Next(0, 5));
            }
            CreateMap();
            HideCells();
        }

        public void HideCells() // метод сокрытия клеток
        {
            int N = 40;
            Random r = new Random();

            while(N>0)
            {
                for (int i = 0; i < n * n; i++)
                {
                    for (int j = 0; j < n * n; j++)
                    {
                        if (!string.IsNullOrEmpty(buttons[i, j].Text))
                        {
                            int a = r.Next(0, 3);
                            buttons[i, j].Text = a == 0 ? "" : buttons[i, j].Text;
                            buttons[i, j].Enabled = a == 0 ? true : false;
                            if (a == 0)
                            {
                                N--;
                            }
                            if (N <= 0)
                            {
                                break;
                            }
                        }
                    }
                    if (N <= 0)
                    {
                        break;
                    }
                }
            }
        }

        public void ShuffleMap(int i) // метод для перемешивания начального состояния карты с помощью ранее описанных методов
        {
            switch(i)
            {
                case 0:
                    MatrixTransosition();
                    break;
                case 1:
                    SwapRowsInBlock();
                    break;
                case 2:
                    SwapColumnsInBlock();
                    break;
                case 3:
                    SwapBlocksInRows();
                    break;
                case 4:
                    SwapBlocksInColumns();
                    break;
                default:
                    MatrixTransosition();
                    break;
            }
        }

        public void SwapRowsInBlock() //метод смены строк в пределах одного блока
        {
            Random r = new Random();
            var block = r.Next(0, n);
            var row1 = r.Next(0, n);
            var line1 = block * n + row1;
            var row2 = r.Next(0, n);
            while(row1 == row2) // для избежания повторения строк
            {
                row2 = r.Next(0, n);
            }
            var line2 = block * n + row2;
            for(int i=0;i<n*n;i++)
            {
                var temp = map[line1, i];
                map[line1, i] = map[line2, i];
                map[line2, i] = temp;
            }
        }

        public void SwapBlocksInColumns() // метод замены блоков среди столбцов
        {
            Random r = new Random();
            var block1 = r.Next(0, n);
            var block2 = r.Next(0, n);
            while (block1 == block2)
            {
                block2 = r.Next(0, n);
            }
            block1 *= n;
            block2 *= n;
            for (int i = 0; i < n * n; i++)
            {
                var k = block2;
                for (int j = block1; j < block1 + n; j++)
                {
                    var temp = map[i, j];
                    map[i, j] = map[i, k];
                    map[i, k] = temp;
                    k++;
                }
            }
        }

        public void SwapBlocksInRows() // метод замены блоков среди строк
        {
            Random r = new Random();
            var block1 = r.Next(0, n);
            var block2 = r.Next(0, n);
            while(block1 == block2)
            {
                block2 = r.Next(0, n);
            }
            block1 *= n;
            block2 *= n;
            for(int i =0; i<n*n;i++)
            {
                var k = block2;
                for(int j = block1; j<block1+n;j++)
                {
                    var temp = map[j, i];
                    map[j, i] = map[k, i];
                    map[k, i] = temp;
                    k++;
                }
            }
        }

        public void SwapColumnsInBlock() //метод смены столбцов в пределах одного блока
        {
            Random r = new Random();
            var block = r.Next(0, n);
            var row1 = r.Next(0, n);
            var line1 = block * n + row1;
            var row2 = r.Next(0, n);
            while (row1 == row2) // для избежания повторения строк
            {
                row2 = r.Next(0, n);
            }
            var line2 = block * n + row2;
            for (int i = 0; i < n * n; i++)
            {
                var temp = map[i,line1];
                map[i, line1] = map[i,line2];
                map[i,line2] = temp;
            }
        }

        public void MatrixTransosition()
        {
            int[,] tMap = new int[n * n, n * n]; // временный массив

            for(int i = 0;i<n*n;i++)
            {
                for(int j = 0; j<n*n;j++)
                {
                    tMap[i, j] = map[j, i];
                }
            }
            map = tMap;
        }

        public void CreateMap()
        {
            for (int i = 0; i < n * n; i++)
            {
                for (int j = 0; j < n * n; j++)
                {
                    Button button = new Button();
                    buttons[i, j] = new Button();
                    buttons[i, j] = button;
                    button.Size = new Size(sizeButton, sizeButton);
                    button.Text = map[i, j].ToString();
                    button.Click += OnCellPressed;
                    button.Location = new Point(j*sizeButton,i*sizeButton);
                    this.Controls.Add(button);
                }
            }
        }

        public void OnCellPressed(object sender,EventArgs e) // обработчик нажатия клавиш
        {
            Button pressedButton = sender as Button;
            string buttonText = pressedButton.Text;
            if(string.IsNullOrEmpty(buttonText))
            {
                pressedButton.Text = "1";
            }
            else
            {
                int num = int.Parse(buttonText);
                num++;
                if(num == 10)
                {
                    num = 1;
                }
                pressedButton.Text = num.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 0;i<n*n;i++)
            {
                for(int j = 0; j<n*n; j++)
                {
                    var btnText = buttons[i, j].Text;
                    if(btnText != map[i,j].ToString())
                    {
                        MessageBox.Show("That's not right! ");
                        return;
                    }
                }
            }
            MessageBox.Show("That's right! ");
            for (int i = 0; i < n * n; i++)
            {
                for (int j = 0; j < n * n; j++)
                {
                    this.Controls.Remove(buttons[i, j]);
                }
            }
            GenerateMap();
        }
    }
}
