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
    public partial class Form1 : Form
    {
        public static OrderService odserve = new OrderService();
        public Form1()
        {
            InitializeComponent();
            Order order1 = new Order(114514, "水果", 4, 50);
            Order order2 = new Order(114515, "家具", 5, 1000);
            Order order3 = new Order(114516, "零食", 8, 100);
            Order order4 = new Order(114517, "蔬菜", 8, 40);
            Order order5 = new Order(114515, "家具", 8, 500);
            odserve.AddOrder(order1);
            odserve.AddOrder(order2);
            odserve.AddOrder(order3);
            odserve.AddOrder(order4);
            odserve.AddOrder(order5);
            bindingSource1.DataSource = odserve.orderlist;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = comboBox1.Text;
            if (s == "订单号")
            {
                int num = Int32.Parse(textBox1.Text);
                var order = from w in odserve.orderlist where w.ordernum == num select w;
                bindingSource1.DataSource = order;
            }
            else if (s == "全部订单")
            {
                var order = from w in odserve.orderlist select w;
                bindingSource1.DataSource = order;

            }
            else
            {
                int num = Int32.Parse(textBox1.Text);
                var order = from w in odserve.orderlist where w.count == num select w;
                bindingSource1.DataSource = order;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
