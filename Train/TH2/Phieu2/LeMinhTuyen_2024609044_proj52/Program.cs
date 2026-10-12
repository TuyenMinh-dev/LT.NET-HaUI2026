using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeMinhTuyen_2024609044_proj52
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee e = new Employee();
            string tiepTuc;
            do
            {
                
                Console.WriteLine("Ban muon nhap vao bao nhieu nhan vien: ");
                int n = e.EnterAnInteger();
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"Nhap thong tin cho sinh vien thu {i + 1}: ");
                    e.Input();
                }
                Console.Write("Ban co muon nhap them nua khong?(yes/no): ");
                tiepTuc = Console.ReadLine();
            } while (tiepTuc.ToLower() == "yes");
            e.Ouput();
            }


    }
}
