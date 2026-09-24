using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3
{
    class Program
    {
        public static int GT(int n)
        {
            if (n<0)
            {
                Console.WriteLine($"Khong ton tai {n}!");
                return -1;
            }
            if (n==1 ||n==0)
            {
                return 1;
            }
            else
            {
                return n * GT(n - 1);
            }
        }
        public static bool isPrime(int n)
        {
            if (n<2)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n%i==0)
                {
                    return false;
                }
                
            }return true;
        }
        public static void Main(string[] args)
        {
            Console.Write("Nhap so nguyen n: ");
            int n = int.Parse(Console.ReadLine());
            if (n>=0)
            {
                Console.WriteLine($"{n}! = {GT(n)}");
                Console.Write($"Cac so nguyen to tren doan tu [2,{n}]: ");
                for (int i = 2; i <= n; i++)
                {
                    if (isPrime(i))
                    {
                        Console.Write($"{i} ");
                    }
                }
            }
            else
            {
                Console.WriteLine("Khong the thuc hien bai toan");
            } 
        }
    }
}
