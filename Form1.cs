using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Plat.World
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var exit_result = System.Windows.MessageBox.Show("Are you sure you want to go out? ", "", (MessageBoxButton)MessageBoxButtons.YesNoCancel);
            if (exit_result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
