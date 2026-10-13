using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srcDe1
{
    class Program
    {   static List<SanPhamKhuyenMai> DSSP = new List<SanPhamKhuyenMai>();
        static void ThemSP()
        {
            Console.Write("Nhap MaSP: ");
            string ma = Console.ReadLine();
            if(DSSP.Any(a => a.maSP == ma))
            {
                Console.WriteLine("Ma SP nay da ton tai!");
                return;
            }
            SanPhamKhuyenMai sp = new SanPhamKhuyenMai();
            sp.maSP = ma;
            Console.Write("Nhap ten SP: ");
            sp.tenSP = Console.ReadLine();
            Console.Write("Nhap gia: ");
            sp.gia = sp.NhapSoThuc();
            Console.Write("Nhap so luong: ");
            sp.soLuong = sp.NhapSoNguyen();
            Console.Write("Nhap phan tram giam: ");
            sp.phanTramGiam = (float)sp.NhapSoThuc();

            DSSP.Add(sp);
            Console.WriteLine("Da them san pham co ma "+ sp.maSP );

        }
        static void menu()
        {
            Console.WriteLine("---MENU---");
            Console.WriteLine("1.Them san pham moi");
            Console.WriteLine("2.Hien thi toan bo");
            Console.WriteLine("3.Sap xep giam dan theo ThanhTien");
            Console.WriteLine("4.Loc cac san pham co gia <= nguong ");
            Console.WriteLine("5.Tim kiem va in thong tin");
            Console.WriteLine("6.Thoat chuong trinh");

        }
        static void findById()
        {
            Console.Write("Nhap ma can tim: ");
            string ma = Console.ReadLine();
            SanPhamKhuyenMai sp = DSSP.FirstOrDefault(x => x.maSP == ma);

            if (sp == null)
            {
                Console.WriteLine("Khong tim thay san pham co ma: " + ma);
                return;
            }
            SanPhamKhuyenMai.title();
            sp.HienThi();
        }
        static void Filter()
        {
            Console.Write("Nhap nguong cho thanh tien: ");
            double nguong = NhapSoThuc();
            var ketQua = DSSP.Where(sp => sp.TinhThanhTien() <= nguong).ToList();

            if (ketQua.Count == 0)
            {
                Console.WriteLine("Khong co san pham nao thoa dieu kien!");
                return;
            }
            Console.WriteLine("Ds sau khi loc: ");
            SanPhamKhuyenMai.title();
            foreach (SanPhamKhuyenMai a in ketQua)
            {
                a.HienThi();
            }
        }
        static void HienThiTatCa()
        {
            SanPhamKhuyenMai.title();
            foreach(SanPhamKhuyenMai sp in DSSP)
            {
                sp.HienThi();
            }
        }
        static void SXGiamDan()
        {
            var ketQua = DSSP.OrderByDescending(sp => sp.TinhThanhTien()).ToList();
            Console.WriteLine("Danh sach sau khi sap xep: ");
            SanPhamKhuyenMai.title();
            foreach (SanPhamKhuyenMai a in ketQua)
            {
                a.HienThi();
            }
        }
        
        static public int NhapSoNguyen()
        {
            int kq;
            while (!int.TryParse(Console.ReadLine(), out kq) || kq < 0)
            {
                Console.WriteLine("Vui long nhap vao mot so nguyen!");
            }
            return kq;
        }
        static public double NhapSoThuc()
        {
            double kq;
            while (!double.TryParse(Console.ReadLine(), out kq) || kq < 0)
            {
                Console.WriteLine("Vui long nhap vao mot so thuc!");
            }
            return kq;
        }
        static void Main(string[] args)
        {
            DSSP.Add(new SanPhamKhuyenMai("1", "a", 50000, 10,35));
            DSSP.Add(new SanPhamKhuyenMai("2", "b", 60000, 5, 30));
            DSSP.Add(new SanPhamKhuyenMai("3", "c", 70000, 15, 20));
            int choice;
            do
            {
                menu();
                Console.Write("Nhap lua chon cua ban: ");
                choice = NhapSoNguyen();
                switch (choice)
                {
                    case 1:
                        ThemSP();
                        break;
                    case 2:
                        HienThiTatCa();
                        break;
                    case 3:
                        SXGiamDan();
                        break;
                    case 4:
                        Filter();
                        break;
                    case 5:
                        findById();
                        break;
                    case 6:
                        Console.WriteLine("Thoat chuong trinh!");
                        break;
                    default:
                        Console.WriteLine("Vui long nhap nhap lai lua chon cua ban!");
                        break;

                }
            } while (choice != 6);
        }
    }
}
