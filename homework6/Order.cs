using System;
using System.Collections.Generic;
using System.Text;

namespace homework5
{
    public class Order : OrderDetails
    {
        public Order(int ordernum, string name, int count, int price) : base(ordernum, name, count, price)
        {

        }
        public Order()
        {

        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
