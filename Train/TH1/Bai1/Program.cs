using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap so phan tu cho mang: n= ");
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap gia tri cho phan tu thu {i+1}");
                a[i] = int.Parse(Console.ReadLine());
            }
            
        }
    }
}
