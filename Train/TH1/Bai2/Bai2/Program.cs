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
            Console.Write("Nhap so luong phan tu cho mang: n= ");
            int n = int.Parse(Console.ReadLine());
            int []a = new int [n];
            for (int i = 0; i < n ; i++)
            {
                Console.Write($"Nhap gia tri cho phan tu thu {i+1}: ");
                a[i] = int.Parse(Console.ReadLine());
            }
            int tong = 0, min = a[0], max = a[0];
            foreach (int x in a)
            {
                if (x<min)
                {
                    min = x;
                }
                if (x>max)
                {
                    max = x;
                }
                tong += x;
            }
            Console.WriteLine($"Max: {max}");
            Console.WriteLine($"Min: {min}");
            Console.WriteLine($"Tong: {tong}");
            Console.WriteLine($"Trung binh: { (double)tong / n:F2}");
                                            
        }
    }
}
