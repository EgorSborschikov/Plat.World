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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            button2.Click += button2_Click;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming Soon :( ");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 frm6 = new Form6();
            frm6.Show();
            this.Close();
        }
    }
}
