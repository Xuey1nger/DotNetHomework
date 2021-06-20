using System;

namespace homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            int n = 0;
            int m = 0;
            char ch = 'a';
            Console.Write("请输入第一个数字:");
            s = Console.ReadLine();
            m = Int32.Parse(s);
            Console.Write("请输入第二个数字:");
            s = Console.ReadLine();
            n = Int32.Parse(s);
            Console.Write("请输入运算符:");
            s = Console.ReadLine();
            ch = Char.Parse(s);
            switch(ch)
            {
                case '+':
                    Console.WriteLine($"{m + n}");
                    break;
                case '-':
                    Console.WriteLine($"{m - n}");
                    break;
                case '*':
                    Console.WriteLine($"{m * n}");
                    break;
                case '/':
                    Console.WriteLine($"{m / n}");
                    break;
            }
        }
    }
}
