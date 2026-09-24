using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai4
{
    class Program
    {
        public static void Main(string[] args)
        {
        var ds = new List<string>();
         int i = 0;
        while (true)
        {
            Console.Write($"Ho ten SV thu {i+1}: ");
            var ten = Console.ReadLine();
                if (string.IsNullOrEmpty(ten))
                {
                    break;
                }
                ds.Add(ten);
                i++;
        }
            if (ds.Count ==0)
            {
                Console.WriteLine("Danh sach rong");
                return;
            }
            Console.WriteLine("Danh sach sinh vien ban dau : ");
            /*foreach (string sv in ds)
            {
                Console.WriteLine($"{sv}");
            }*/
            ds.ForEach(sv => Console.WriteLine(sv));// dung lambda
            
            ds.Sort();// sap xep theo A-Z
            Console.WriteLine("Danh sach sinh vien sau khi sap xep : ");
            ds.ForEach(sv => Console.WriteLine(sv));// dung lambda

            Console.Write("Nhap tu khoa ten SV can tim: ");
            string key = Console.ReadLine();
            var kq = ds.FindAll(sv => sv.ToLower().Contains(key.ToLower()));

            if (kq.Count > 0)
            {
                Console.WriteLine($"Tim thay {kq.Count} sinh vien phu hop:");
                kq.ForEach(sv => Console.WriteLine($" -> {sv}"));
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien nao phu hop!");
            }
        }
    }
}
