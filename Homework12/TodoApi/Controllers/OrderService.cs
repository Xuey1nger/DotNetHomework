using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderManagerWeb
{
    public class OrderService : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        private List<Order> OrderList;
        //private Dictionary<string, string> CustomerDict;
        private int OrderNum;
        public int OrderCount { get => OrderList.Count(); }
        public OrderService()
        {
            OrderNum = 0;
            OrderList = new List<Order>();
        }
        public bool AddOrder(Customer customer)
        {
            try
            {
                OrderNum += 1;
                OrderList.Add(new Order(OrderNum.ToString().PadLeft(8, '0'), customer));
            }
            catch { return false; }
            return true;
        }
        [HttpDelete]
        public bool DeleteOrder(string OrderNo)
        {
            int index = OrderList.FindIndex(o => o.OrderNo == OrderNo);
            if (index == -1)
            {
                return false;
            }
            OrderList.RemoveAt(index);
            return true;
        }
        [HttpGet]
        public IEnumerable<Order> QueryOrder(string query = "", string _type = "")
        {
            IEnumerable<Order> result = OrderList;
            result = OrderList.Where(o => o.OrderNo == query);
            return result.OrderByDescending(r => r.OrderNo);
        }
        public List<Order> SortOrder(string by = "ascending")
        {
            if (by == "ascending")
            {
                return SortOrder((o1, o2) =>
                {
                    if (int.Parse(o1.OrderNo) < int.Parse(o2.OrderNo)) return 1;
                    else if (int.Parse(o1.OrderNo) == int.Parse(o2.OrderNo)) return 0;
                    else return -1;
                });
            }
            else
            {
                return SortOrder((o1, o2) =>
                {
                    if (int.Parse(o1.OrderNo) > int.Parse(o2.OrderNo)) return 1;
                    else if (int.Parse(o1.OrderNo) == int.Parse(o2.OrderNo)) return 0;
                    else return -1;
                });
            }
        }
        public List<Order> SortOrder(Comparison<Order> comparison)
        {
            OrderList.Sort(comparison);
            return OrderList;
        }
        public void Export(string filename = "export.xml")
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                try
                {
                    System.Xml.Serialization.XmlSerializer xmlSerializer = string.IsNullOrWhiteSpace(filename) ?
                    new System.Xml.Serialization.XmlSerializer(OrderList.GetType()) :
                    new System.Xml.Serialization.XmlSerializer(OrderList.GetType(), new XmlRootAttribute("Order"));
                    xmlSerializer.Serialize(writer, OrderList);
                }
                finally
                {
                    writer.Close();
                }
            }
        }
        public void Import(string filename = "export.xml")
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                try
                {
                    System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(OrderList.GetType(), new XmlRootAttribute("Order"));
                    OrderList = (List<Order>)xmlSerializer.Deserialize(reader);
                }
                finally
                {
                    reader.Close();
                }
            }

        }
    }

    [XmlRootAttribute("Order")]
    public class Order
    {
        public string OrderNo;//订单号
        public enum State { Unfinished, Finished }
        public State OrderState;//订单状态
        private DateTime _dt;
        public DateTime OrderTime
        {
            get => _dt;
            set => _dt = value;
        }
        public Order() { }
        public Order(string No)
        {
            OrderNo = No;
            OrderTime = DateTime.Now;
            OrderState = State.Unfinished;
        }
        public override string ToString()
        {
            string table = "下单时间：" + OrderTime + "订单编号:" + OrderNo + "\n";
            return table;
        }
        public bool Equals(Order other)
        {
            if (ReferenceEquals(null, other)) return false;

            if (ReferenceEquals(this, other)) return true;

            if (!string.Equals(this.ToString(), other.ToString(), StringComparison.InvariantCulture))
                return false;
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;

            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != this.GetType()) return false;

            return Equals((Order)obj);
        }
        public override int GetHashCode()
        {
            return (this.ToString() != null ? StringComparer.InvariantCulture.GetHashCode(this.ToString()) : 0);
        }

        public static bool operator ==(Order left, Order right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Order left, Order right)
        {
            return !Equals(left, right);
        }
    }
}
