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
            List<SinhVien> danhSach = new List<SinhVien>();
            danhSach.Add(new SinhVien("Le Van A", "2024100", 9));
            danhSach.Add(new SinhVien("Le Van B", "2024101", 8.5));
            danhSach.Add(new SinhVien("Le Van B", "2024102", 7));

            Console.WriteLine("Danh sach sinh vien ban dau: ");
            SinhVien.InTieuDe();
            foreach (SinhVien sv in danhSach)
            {
                sv.InTT();
            }
            string choice;
            do {
                Console.Write("Ban co muon nhap them sinh vien nua khong? (Yes/No ): ");
                choice = Console.ReadLine();
                if (choice.ToLower() == "yes" || choice.ToLower() == "y")
                {
                    Console.Write("Ban muon nhap them bao nhieu sinh vien: ");
                    int n = NhapSoNguyen();
                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine(new string('-',20));
                        Console.WriteLine("Nhap tt cho sinh vien: ");
                        Console.Write("MSSV: ");
                        string id = Console.ReadLine();
                        Console.Write("Ho ten: ");
                        string name = Console.ReadLine();
                        Console.Write("Diem TB: ");
                        double point = NhapSoThuc();

                        SinhVien sv = new SinhVien(name, id, point);
                        danhSach.Add(sv);
                        Console.WriteLine("Da them thanh cong sinh vien co mssv la " + id);

                    }
                   
                }
            } while (choice.ToLower()=="yes" || choice.ToLower() == "y");
            Console.WriteLine(new string('-', 20));
            Console.WriteLine("Danh sach sinh vien hien tai la: ");
            SinhVien.InTieuDe();
            foreach(SinhVien sv in danhSach)
            {
                sv.InTT();
            }

            }
        static int NhapSoNguyen()
        {
            int kq;
            while(!int.TryParse(Console.ReadLine(),out kq))
            {
                Console.WriteLine("Vui long nhap vao mot so nguyen!Thu lai");
            }
            return kq;
        }
        static double NhapSoThuc()
        {
            double kq;
            while (!double.TryParse(Console.ReadLine(), out kq))
            {
                Console.WriteLine("Vui long nhap vao mot so nguyen!Thu lai");
            }
            return kq;
        }
    }
}
