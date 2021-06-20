using System;

namespace homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            int m = 0;
            int[] array = new int[]{ 0, 1, 4, 6, 8, 8, 5, 8 };
            int[,] array1= new int[,]{ { 0, 1, 1, 1 },{ 1, 0, 1, 1 },{ 1, 1, 0, 1 },{ 1, 1, 1, 0 } };
            Program pro = new Program();
            Console.Write("请输入数据:");
            s = Console.ReadLine();
            m = Int32.Parse(s);
            pro.PriFactor(m,out string str);
            Console.WriteLine($"{str}");
            pro.CountArray(array, out int max, out int min, out double aver, out int sum);
            Console.WriteLine($"最大值为:{max},最小值为:{min},平均数为:{aver},和为:{sum}");
            pro.GetPrime(out int[] a);
            Console.Write("0到100的素数为:");
            for (int i=0;i<99;i++)
            {
                if(a[i]==0)
                {
                    Console.Write($"{i + 2} ");
                }
            }
            Console.WriteLine(" ");
            pro.Tplis(array1, 4, 4, out bool isTplis);
            Console.WriteLine($"{isTplis}");
        }

        void PriFactor(int x,out string str)
        {
            str = "";
            for(int j = 2;j*j<=x;j++)
            {
                while(x%j==0)
                {
                    x = x / j;
                }
                str = str + j+",";
            }
            if (x != 1)
                str = str + x;
        }

        void CountArray(int[] arr,out int max,out int min,out double aver,out int sum)
        {
            max = 0;
            min = arr[0];
            sum = arr[0];
            int i = 0;
            foreach(int a in arr)
            {
                if(a>max)
                {
                    max = a;
                }
                else if(a<min)
                {
                    min = a;
                }
                i++;
                sum += a;
            }
            aver = sum / i;
        }

        void GetPrime(out int[] array)
        {
            array = new int[99];
            for(int i=2;i<100;i++)
            {
                for(int j = i+1;j<=100;j++)
                {
                    if(j%i==0)
                    {
                        array[j - 2] = 1;
                    }
                }
            }
        }

        void Tplis(int[,] mat,int m,int n,out bool isTplis)
        {
            isTplis = true;
            for(int i=0;i<n;i++)
            {
                int j = 0;
                while(i<n-1&&j<m-1)
                {
                    if(mat[j,i]!=mat[j+1,i+1])
                    {
                        isTplis = false;
                        return;
                    }
                    i++;
                    j++;
                }
            }
        }
    }
}
