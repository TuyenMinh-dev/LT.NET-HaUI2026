using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3
{
    class Program
    {
        static int NhapSoNguyen()
        {
            int kq;
            while (!int.TryParse(Console.ReadLine(), out kq) || kq < 0)
            {
                Console.Write("Vui long nhap mot so nguyen khong am, nhap lai: ");
            }
            return kq;
        }

        static double NhapSoThuc()
        {
            double kq;
            while (!double.TryParse(Console.ReadLine(), out kq))
            {
                Console.Write("Vui long nhap mot con so hop le, nhap lai: ");
            }
            return kq;
        }
        static void Main(string[] args)
        {
            List<PhongBan> dsPhongBan = new List<PhongBan>();

            string tiepTuc;
            do
            {
                Console.Write("\nNhap ten phong ban: ");
                string tenPhong = Console.ReadLine();

                PhongBan pb = new PhongBan(tenPhong);

                Console.Write("Nhap so luong nhan vien cua phong: ");
                int soNV = NhapSoNguyen();

                for (int i = 0; i < soNV; i++)
                {
                    Console.WriteLine(new string('-', 20));
                    Console.WriteLine($"Nhap thong tin nhan vien thu {i + 1}:");

                    Console.Write("Ho ten: ");
                    string hoTen = Console.ReadLine();

                    Console.Write("Luong: ");
                    double luong = NhapSoThuc();

                    try
                    {
                        NhanVien nv = new NhanVien(hoTen, luong);
                        pb.ThemNV(nv);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine("Khong them duoc nhan vien: " + ex.Message);
                        i--; // lam lai dung nhan vien nay, khong tinh vao so luong da nhap
                    }
                }

                dsPhongBan.Add(pb);

                Console.Write("\nBan co muon nhap them phong ban nua khong? (Yes/No): ");
                tiepTuc = Console.ReadLine();

            } while (tiepTuc.ToLower() == "yes" || tiepTuc.ToLower() == "y");

            Console.WriteLine("\n===== BAO CAO TOAN BO PHONG BAN =====");
            foreach (PhongBan pb in dsPhongBan)
            {
                pb.InDanhSach();
                Console.WriteLine(new string('*', 40));
            }
        }
    }
}
