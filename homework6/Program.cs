using System;

namespace homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order1 = new Order(114514, "水果", 4, 50);
            Order order2 = new Order(114515, "家具", 5, 1000);
            Order order3 = new Order(114516, "零食", 8, 100);
            Order order4 = new Order(114517, "蔬菜", 8, 40);
            Order order5 = new Order(114515, "家具", 8, 500);
            OrderService odserve = new OrderService();
            odserve.AddOrder(order1);
            odserve.AddOrder(order2);
            odserve.AddOrder(order3);
            odserve.AddOrder(order4);
            odserve.AddOrder(order5);
            odserve.DeleteOrder(114514);
            odserve.OrderSort();
            odserve.search(114516);
            odserve.searchcount(8);
            odserve.Export();
            odserve.Import();
        }
    }
}
