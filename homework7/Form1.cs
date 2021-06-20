using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework7
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        double th1 = 0;
        double th2 = 0;
        double per1 = 0;
        double per2 = 0;
        int n = 0;
        double leng = 0;
        int r = 0;
        int g = 0;
        int b = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            graphics.Clear(Color.White);
            drawCayleyTree(n,400,397,leng,-Math.PI/2);
        }

        void drawCayleyTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }

        void drawLine(double x0,double y0,double x1,double y1)
        {
            Pen pen = new Pen(Color.FromArgb(r, g, b));
            graphics.DrawLine(pen,(int)x0,(int)y0,(int)x1,(int)y1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            n = Int32.Parse(textBox1.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            leng = Double.Parse(textBox4.Text);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            per1 = Double.Parse(textBox6.Text);
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            per2 = Double.Parse(textBox8.Text);
        }


        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            th1 = Double.Parse(textBox10.Text);
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            th2 = Double.Parse(textBox12.Text);
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            r = Int32.Parse(textBox14.Text);
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            g = Int32.Parse(textBox16.Text);
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            b = Int32.Parse(textBox18.Text);
        }

    }
}
