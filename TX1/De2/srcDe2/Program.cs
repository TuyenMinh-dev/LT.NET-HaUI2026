using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srcDe2
{
    class Program
    {
        static List<NhanVienKinhDoanh> DSNV = new List<NhanVienKinhDoanh>();
        static void menu()
        {
            Console.WriteLine("---MENU---");
            Console.WriteLine("1. Them NV");
            Console.WriteLine("2. Hien thi");
            Console.WriteLine("3.Loc theo xep loai");
            Console.WriteLine("4. Tim kiem va chinh sua");
            Console.WriteLine("5. Thoat");
        }
        static void hienthi()
        {
            NhanVienKinhDoanh.Title();
            foreach(NhanVienKinhDoanh nv in DSNV)
            {
                nv.HienThi();
            }
        }
        static void Them()
        {
            Console.Write("Nhap ma: ");
            string ma = Console.ReadLine();
            if(DSNV.Any(nv => nv.maNV == ma))
            {
                Console.WriteLine("Ma NV nay da ton tai");
                return;
            }
            NhanVienKinhDoanh a = new NhanVienKinhDoanh();
            a.maNV = ma;
            Console.Write("Nhap ho ten: ");
            a.hoTen = Console.ReadLine();
            Console.Write("Nhap luong co ban: ");
            a.luongCoBan = NhapSoThuc();
            Console.Write("Nhap so ngay cong: ");
            a.soNgayCong = NhapSoNguyen();
            Console.Write("Doanh so: ");
            a.doanhSo = NhapSoThuc();

            DSNV.Add(a);
            Console.WriteLine("Them thanh cong nhan vien co ma "+ a.maNV);
        }
        static void filter()
        {
            Console.WriteLine("Ban muon loc ds theo xep loai nao: ");
            string xl = Console.ReadLine();
            var kq = DSNV.Where(nv => nv.XepLoai().ToLower() == xl.ToLower()).ToList();
            if (kq.Count == 0)
            {
                Console.WriteLine("Khong co kieu xep loai nay!");
            }
            else
            {
                Console.WriteLine("DS sau khi loc: ");
                NhanVienKinhDoanh.Title();
                foreach(NhanVienKinhDoanh nv in kq)
                {
                    nv.HienThi();
                }
            }
        }
        static void FindAndUpdate()
        {
            Console.Write("Nhap ma muon tim: ");
            string ma = Console.ReadLine();
            NhanVienKinhDoanh nv = DSNV.FirstOrDefault(a => a.maNV == ma);
            if (nv == null)
            {
                Console.WriteLine("Khong tim thay nhan vien co ma "+ ma);
            }
            else
            {
                Console.WriteLine("Da tim thay!");
                string sua;
                Console.Write("Ban co muon sua lai thong tin cho nhan vien nay khong! (yes/no):");
                sua = Console.ReadLine();
                if(sua.ToLower() == "yes")
                {
                    Console.Write("Nhap luong co ban: ");
                    nv.luongCoBan = NhapSoThuc();
                    Console.Write("Nhap so ngay cong: ");
                    nv.soNgayCong = NhapSoNguyen();
                    Console.Write("Doanh so: ");
                    nv.doanhSo = NhapSoThuc();

                    Console.WriteLine("Da cap nhat thong tin cho nhan vien tren!");

                }
                
            }
        }
        static int NhapSoNguyen()
        {
            int kq;
            while(!int.TryParse(Console.ReadLine(),out kq) || kq<0)
            {
                Console.WriteLine("Vui long nhap vao mot so nguyen khong am!");
                
            }return kq;
        }
        static double NhapSoThuc()
        {
            double kq;
            while (!double.TryParse(Console.ReadLine(), out kq)|| kq<0)
            {
                Console.WriteLine("Vui long nhap vao mot so thuc khong am!");

            }
            return kq;
        }
        static void Main(string[] args)
        {
            DSNV.Add(new NhanVienKinhDoanh("1", "a", 3500000, 22, 150000000));
            DSNV.Add(new NhanVienKinhDoanh("2", "b", 3000000, 15, 50000000));
            DSNV.Add(new NhanVienKinhDoanh("3", "c", 500000, 35, 2000000));
            int choice;
            do
            {
                menu();
                Console.Write("Nhap lua chon cua ban: ");
                choice = NhapSoNguyen();

                switch (choice)
                {
                    case 1:
                        Console.WriteLine(new string('*', 50));
                        Them();
                       
                        break;
                    case 2:
                        Console.WriteLine(new string('*', 50)); 
                        hienthi();
                      
                        break;
                    case 3:
                        Console.WriteLine(new string('*', 50));
                        filter();
                        break;
                    case 4:
                        Console.WriteLine(new string('*', 50));
                        FindAndUpdate();
                  
                        break;
                    case 5:
                        Console.WriteLine(new string('*', 50));
                        Console.WriteLine("Thoat chuong trinh!");
                     
                        break;
                    default:
                        Console.WriteLine("Vui long nhap lai lua chon cua ban!");
                        break;
                }
            } while (choice != 5);
        }
    }
}
