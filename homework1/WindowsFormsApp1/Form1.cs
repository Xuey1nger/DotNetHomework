using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "";
            int n = 0;
            int m = 0;
            char ch = 'a';
            s = textBox1.Text;
            m = Int32.Parse(s);
            s = textBox2.Text;
            n = Int32.Parse(s);
            s = (string)comboBox1.SelectedItem;
            ch = Char.Parse(s);
            switch (ch)
            {
                case '+':
                    button1.Text = ($"{m + n}");
                    break;
                case '-':
                    button1.Text = ($"{m - n}");
                    break;
                case '*':
                    button1.Text = ($"{m * n}");
                    break;
                case '/':
                    button1.Text = ($"{m / n}");
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
