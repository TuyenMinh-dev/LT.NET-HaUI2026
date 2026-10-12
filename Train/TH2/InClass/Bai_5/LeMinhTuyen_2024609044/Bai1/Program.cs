using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1{
    class Program
    {
        static double NhapSoThuc()
        {
            double ketQua;
            while (!double.TryParse(Console.ReadLine(), out ketQua))
            {
                Console.WriteLine("Du lieu khong hop le! Vui long nhap lai");
            }
            return ketQua;
        }
        static void Main(string[] args)
        {
            Console.Write("Nhap chieu dai: ");
            double dai = NhapSoThuc();

            Console.Write("Nhap chieu rong: ");
            double rong = NhapSoThuc();

            HinhChuNhat HCN = new HinhChuNhat(dai, rong);

            Console.WriteLine($"Chu vi HCN: " + HCN.TinhChuVi());
            Console.WriteLine($"Dien tich HCN: "+ HCN.TinhDienTich());
        }
    }
}
