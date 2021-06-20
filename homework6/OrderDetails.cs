using System;
using System.Collections.Generic;
using System.Text;

namespace homework5
{
    public class OrderDetails
    {
        public int ordernum;
        public string name;
        public int count;
        public int price;

        public OrderDetails(int ordernum, string name, int count, int price)
        {
            this.count = count;
            this.name = name;
            this.ordernum = ordernum;
            this.price = price;
        }

        public OrderDetails()
        {

        }

        public override bool Equals(object obj)
        {
            OrderDetails ord = obj as OrderDetails;
            return ordernum == ord.ordernum;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "订单编号为:" + ordernum + "  商品名称为:" + name + "  客户为:" + count + "  订单金额为:" + price;
        }
    }
}
