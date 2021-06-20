using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using homework5;

namespace homework8
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
            bindingSource1.DataSource = Form1.odserve.orderlist;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int ordernum = Int32.Parse(textBox1.Text);
            string name = textBox2.Text;
            int count = Int32.Parse(textBox3.Text);
            int price = Int32.Parse(textBox4.Text);
            Order order = new Order(ordernum, name, count, price);
            Form1.odserve.AddOrder(order);
            var order1 = from w in Form1.odserve.orderlist select w;
            bindingSource1.DataSource = order1;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int ordernum = Int32.Parse(textBox1.Text);
            Form1.odserve.DeleteOrder(ordernum);
            var order = from w in Form1.odserve.orderlist select w;
            bindingSource1.DataSource = order;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            int ordernum = Int32.Parse(textBox1.Text);
            string name = textBox2.Text;
            int count = Int32.Parse(textBox3.Text);
            int price = Int32.Parse(textBox4.Text);
            Order order = new Order(ordernum, name, count, price);
            Form1.odserve.Modify(ordernum, order);
            var order1 = from w in Form1.odserve.orderlist select w;
            bindingSource1.DataSource = order1;
        }

    }
}
