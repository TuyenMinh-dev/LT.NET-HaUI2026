using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap so a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Nhap so b: ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine($"Tong: {a+b}");
            Console.WriteLine($"Hieu: {a-b}");
            Console.WriteLine($"Tich: {a*b}");
            if (b!=0)
            {
                Console.WriteLine($"Thuong: {(double)a / b:F2}");
            }
            else
            {
                Console.WriteLine("Khong the tim thuong cua a chia b");
            }
        }
    }
}
