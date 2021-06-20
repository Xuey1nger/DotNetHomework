using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

namespace homework5
{
    public class OrderService
    {
        public List<Order> orderlist = new List<Order>();

        public void AddOrder(Order order)
        {
            bool canAdd = true;
            foreach (Order element in orderlist)
            {
                if (order.Equals(element))
                {
                    canAdd = false;
                }
            }
            if (canAdd == true)
            {
                orderlist.Add(order);
            }
        }

        public void DeleteOrder(int number)
        {
            var order = from w in orderlist where w.ordernum == number select w;
            for (int i = 0; i < order.Count(); i++)
            {
                orderlist.Remove(order.ElementAt(i));
            }
        }

        public void Modify(int num, Order order)
        {
            DeleteOrder(num);
            AddOrder(order);
        }

        public void OrderSort()
        {
            var odlist = from w in orderlist orderby w.ordernum select w;
            Console.WriteLine("所有的订单按编号排序为:");
            foreach (Order od in odlist)
            {
                string s = od.ToString();
                Console.WriteLine(s);
            }
        }

        public void search(int num)
        {
            Console.Write($"查到到编号为:{num}的订单为");
            var order = from w in orderlist where w.ordernum == num select w;
            foreach (Order od in order)
            {
                string s = od.ToString();
                Console.WriteLine(s);
            }
        }

        public void searchcount(int count)
        {
            Console.WriteLine($"账户{count}的所有订单按价格排序为:");
            var order = from w in orderlist where w.count == count orderby w.price select w;
            foreach (Order od in order)
            {
                string s = od.ToString();
                Console.WriteLine(s);
            }
        }

        public void Export()
        {
            XmlSerializer xmlserializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("Order.xml", FileMode.Create))
            {
                xmlserializer.Serialize(fs, orderlist);
            }
            Console.WriteLine(File.ReadAllText("Order.xml"));
        }

        public void Import()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("Order.xml", FileMode.Open)) 
            {
                orderlist = (List<Order>)xmlSerializer.Deserialize(fs);
            }
            foreach (Order element in orderlist)
            {
                string s = element.ToString();
                Console.WriteLine(s);
            }
        }
    }
}
