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

namespace Homework11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ctx = new OrderContext())
            {
                string s = comboBox1.Text;
                if (s == "订单号")
                {
                    int num = Int32.Parse(textBox1.Text);
                    var order = from w in ctx.OrderDetails where w.ordernum == num select w;
                    bindingSource1.DataSource = order;
                }
                else if (s == "全部订单")
                {
                    bindingSource1.DataSource = ctx.OrderDetails;

                }
                else
                {
                    int num = Int32.Parse(textBox1.Text);
                    var order = from w in ctx.OrderDetails where w.count == num select w;
                    bindingSource1.DataSource = order;
                }
            }
        }
    }
}
