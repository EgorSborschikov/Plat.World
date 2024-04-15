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
    public partial class Form5 : Form
    {
        private int x = 12, y = 12;
        private Button[,] buttons = new Button[3,3];
        private int player;

        public Form5()
        {
            InitializeComponent();

            this.Height = 700;
            this.Width = 900;

            player = 1;
            label1.Text = "Текущий ход: Игрок 1";

            for (int i = 0; i < buttons.Length / 3; i++)
            {
                for (int j = 0; j < buttons.Length / 3; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(200, 200);
                    buttons[i, j].Location = new Point(12 + 201 * j, 12 + 201 * i);
                    buttons[i, j].Click += button1_Click;
                    buttons[i, j].Font = new Font(new FontFamily("Microsoft Sans Serif"), 138);
                    this.Controls.Add(buttons[i, j]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            if (player == 1)
            {
                clickedButton.Text = "x";
                player = 0;
                label1.Text = "Текущий ход: Игрок 2";
            }
            else if (player == 0)
            {
                clickedButton.Text = "0";
                player = 1;
                label1.Text = "Текущий ход: Игрок 1";
            }

            clickedButton.Enabled = false;
            checkWin();
        }

        private void checkWin()
        {
            if(buttons[0,0].Text == buttons[0,1].Text && buttons[0,1].Text == buttons[0,2].Text)
            {
                if (buttons[0, 0].Text != "")
                {
                    MessageBox.Show("Congratulations, you've won!");
                }
            }
            if (buttons[1, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[1, 2].Text)
            {
                if (buttons[1, 0].Text != "")
                {
                    MessageBox.Show("Congratulations, you've won!");
                }
            }
            if (buttons[2, 0].Text == buttons[2, 1].Text && buttons[2, 1].Text == buttons[2, 2].Text)
            {
                if (buttons[2, 0].Text != "")
                {
                    MessageBox.Show("Congratulations, you've won!");
                }
            }
            if (buttons[0, 0].Text == buttons[1, 0].Text && buttons[1, 0].Text == buttons[2, 0].Text)
            {
                if (buttons[0, 0].Text != "")
                {
                    MessageBox.Show("Congratulations, you've won!");
                }
            }
            if (buttons[0, 1].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 1].Text)
            {
                if (buttons[0, 1].Text != "")
                {
                    MessageBox.Show("Congratulations, you've won!");
                }
            }
            if (buttons[0, 2].Text == buttons[1, 2].Text && buttons[1, 2].Text == buttons[2, 2].Text)
            {
                if (buttons[0, 2].Text != "")
                {
                    MessageBox.Show("Congratulations, you've won!");
                }
            }
            if (buttons[0, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 2].Text)
            {
                if (buttons[0, 0].Text != "")
                {
                    MessageBox.Show("Congratulations, you've won!");
                }
            }
            if (buttons[2, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[0, 2].Text)
            {
                if (buttons[2, 0].Text != "")
                {
                    MessageBox.Show("Congratulations, you've won!");
                }
            }
            if (buttons[0, 0].Text == buttons[0, 1].Text && buttons[0, 1].Text == buttons[0, 2].Text)
            {
                if (buttons[0, 0].Text != "")
                {
                    MessageBox.Show("Congratulations, you've won!");
                }
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j<3; j++)
                {
                    buttons[i, j].Text = "";
                    buttons[i, j].Enabled = true;
                }
            }
        }
    }
}
