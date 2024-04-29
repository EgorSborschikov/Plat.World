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
    public partial class Form6 : Form
    {
        private int rI, rJ;
        private PictureBox fruit;
        private PictureBox[] snake = new PictureBox[400];
        private Label labelScore;
        private int dirX, dirY;
        private int _width = 1100;
        private int _height = 1000;
        private int _sizeOfSides = 50;
        private int score = 0;

        public Form6()
        {
            InitializeComponent();
            this.Text = "Snake";
            this.Width = _width;
            this.Height = _height;
            dirX = 1;
            dirY = 0;
            labelScore = new Label();
            labelScore.Text = "score 0";
            labelScore.Location = new Point(810, 10);
            this.Controls.Add(labelScore);
            snake[0] = new PictureBox();
            snake[0].Location = new Point(200,200);
            snake[0].Size = new Size(_sizeOfSides-1, _sizeOfSides-1);
            snake[0].BackColor = Color.Red;
            this.Controls.Add(snake[0]);
            fruit = new PictureBox();
            fruit.BackColor = Color.Yellow;
            fruit.Size = new Size(_sizeOfSides,_sizeOfSides);
            _generateMap();
            _generateFruit();
            timer1.Tick += new EventHandler(_update);
            timer1.Interval = 500;
            timer1.Start();
            this.KeyDown += new KeyEventHandler(OKP);
            this.KeyPreview = true;
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void _generateFruit()
        {
            Random r = new Random();
            int attempts = 0;
            do
            {
                rI = r.Next(0, _width - _sizeOfSides);
                rJ = r.Next(0, _height - _sizeOfSides);
                attempts++;
            } while (snake.Any(s => s != null && s.Location.X == rI && s.Location.Y == rJ) && attempts < 100);

            if (attempts < 100)
            {
                fruit.Location = new Point(rI, rJ);
                this.Controls.Add(fruit);
            }
            else
            {
                // Обработка ситуации, когда змея заполнила все поле
                MessageBox.Show("Игра окончена. Змея заполнила все поле.");
                timer1.Stop();
            }
        }

        private void _checkBorders()
        {
            if (snake[0].Location.X < 0)
            {
                for (int _i = 1; _i <= score; _i++)
                {
                    this.Controls.Remove(snake[_i]);
                }
                score = 0;
                labelScore.Text = "Score: " + score;
                dirX = 1;
            }
            if (snake[0].Location.X >= _width - _sizeOfSides)
            {
                for (int _i = 1; _i <= score; _i++)
                {
                    this.Controls.Remove(snake[_i]);
                }
                score = 0;
                labelScore.Text = "Score: " + score;
                dirX = -1;
            }
            if (snake[0].Location.Y < 0)
            {
                for (int _i = 1; _i <= score; _i++)
                {
                    this.Controls.Remove(snake[_i]);
                }
                score = 0;
                labelScore.Text = "Score: " + score;
                dirY = 1;
            }
            if (snake[0].Location.Y >= _height - _sizeOfSides)
            {
                for (int _i = 1; _i <= score; _i++)
                {
                    this.Controls.Remove(snake[_i]);
                }
                score = 0;
                labelScore.Text = "Score: " + score;
                dirY = -1;
            }
        }

        private void _eatItself()
        {
            for (int i = 1; i < score; i++)
            {
                if (snake[0].Location == snake[i].Location)
                {
                    for (int j = i; j < score; j++)
                    {
                        this.Controls.Remove(snake[j]);
                    }
                    score = i;
                    labelScore.Text = "Score: " + score;
                    break;
                }
            }
        }

        private void _eatFruit()
        {
            if (snake[0].Location.X == rI && snake[0].Location.Y == rJ)
            {
                labelScore.Text = "Score: " + ++score;
                snake[score] = new PictureBox();
                snake[score].Location = new Point(snake[score - 1].Location.X + dirX * _sizeOfSides, snake[score - 1].Location.Y + dirY * _sizeOfSides);
                snake[score].Size = new Size(_sizeOfSides - 1, _sizeOfSides - 1);
                snake[score].BackColor = Color.Red;
                this.Controls.Add(snake[score]);
                _generateFruit();
            }
        }

        private void _generateMap()
        {
            for (int i = 0; i < _width/_sizeOfSides; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(0,_sizeOfSides * i);
                pic.Size = new Size(_width - 100,1);
                this.Controls.Add(pic);
            }
            for (int i = 0; i <= _height / _sizeOfSides; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(_sizeOfSides * i, 0);
                pic.Size = new Size(1, _width - 100);
                this.Controls.Add(pic);
            }
        }

        private void _moveSnake()
        {
            for (int i = score; i >= 1; i--)
            {
                snake[i].Location = snake[i - 1].Location;
            }

            int newX = (snake[0].Location.X + dirX * _sizeOfSides) % _width;
            int newY = (snake[0].Location.Y + dirY * _sizeOfSides) % _height;

            if (newX < 0)
            {
                newX += _width;
            }

            if (newY < 0)
            {
                newY += _height;
            }

            snake[0].Location = new Point(newX, newY);
            _eatItself();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Close();
        }

        private void _update(Object myObject, EventArgs eventArgs)
        {
            _checkBorders();
            _eatItself();
            _eatFruit();
            _moveSnake();
            //cube.Location = new Point(cube.Location.X + dirX * _sizeOfSides, cube.Location.Y + dirY * _sizeOfSides);
        }

        private void OKP(object sender,KeyEventArgs e)
        {
               switch (e.KeyCode.ToString())
            {
                case "D":
                    if (dirX != -1)
                    {
                        dirX = 1;
                        dirY = 0;
                    }
                    break;
                case "A":
                    if (dirX != 1)
                    {
                        dirX = -1;
                        dirY = 0;
                    }
                    break;
                case "W":
                    if (dirY != 1)
                    {
                        dirY = -1;
                        dirX = 0;
                    }
                    break;
                case "S":
                    if (dirY != -1)
                    {
                        dirY = 1;
                        dirX = 0;
                    }
                    break;
            }
        }
    }
}
