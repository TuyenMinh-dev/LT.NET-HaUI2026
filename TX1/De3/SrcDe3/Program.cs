using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrcDe3
{
    class Program
    {
        static List<PhongVIP> DSPhong = new List<PhongVIP>();
        static void Main(string[] args)
        {
            DSPhong.Add(new PhongVIP("01", "A", 500_000, 2, 50_000));
            DSPhong.Add(new PhongVIP("02", "B", 3_000_000, 5, 80_000));
            DSPhong.Add(new PhongVIP("03", "C", 4_000_000, 10, 90_000));
            DSPhong.Add(new PhongVIP("04", "D", 450_000, 6, 100_000));
            DSPhong.Add(new PhongVIP("05", "E", 600_000, 5, 50_000));
            int choice;
            do
            {
                menu();
                Console.Write("Nhap lua chon cua ban: ");
                choice = PhongVIP.NhapSoNguyen();
                switch (choice)
                {
                    case 1:
                        Them();
                        break;
                    case 2:
                        HienThiAll();
                        break;
                    case 3:
                        Filter();
                        break;
                    case 4:
                        FindByID();
                        break;
                    case 5:
                        Console.WriteLine("Thoat chuong trinh!");
                        break;
                    default:
                        Console.WriteLine("Vui long nhpa lai lua chon cua ban");
                        break;
                }
            } while (choice != 5);

            }
        static void menu()
        {
            Console.WriteLine("---MENU---");
            Console.WriteLine("1. Them phong");
            Console.WriteLine("2. Hien thi");
            Console.WriteLine("3. Loc theo nguong hoac theo xep hang");
            Console.WriteLine("4. Tim va cap nhap so ngay thue moi");
            Console.WriteLine("5. Thoat chuong trinh");
        }
        static void Them()
        {
            PhongVIP p = new PhongVIP();
            p.NhapThongTin();
            if(DSPhong.Any(ph=>ph.MaPhong == p.MaPhong))
            {
                Console.WriteLine("Ma ID nay da ton tai!");
                Console.WriteLine("Khong them thanh cong!");
                return;
            }
            DSPhong.Add(p);
            Console.WriteLine("Da them thanh cong!");
        }
        static void HienThiAll()
        {
            if(DSPhong.Count == 0)
            {
                Console.WriteLine("Danh sach rong!");
                return;
            }
            PhongVIP.Title();
            DSPhong.Sort();
            foreach(PhongVIP p in DSPhong)
            {
                p.HienThi();
            }
            
        }
        static void FindByID()
        {
            Console.Write("Nhap ma phong muon tim: ");
            string ma = Console.ReadLine();
            var kq = DSPhong.FirstOrDefault(p => p.MaPhong == ma);
            if (kq == null)
            {
                Console.WriteLine("Khong tim thay phong co ma "+ ma);
            }
            else
            {
                Console.WriteLine("Da tim thay!");
                Console.WriteLine("Nhap so ngay thue moi: ");
                kq.SoNgayThue = PhongVIP.NhapSoNguyen();
                Console.WriteLine("Thong tin cua phong sau khi cap nhat:");
                PhongVIP.Title();
                kq.HienThi();
            }
            
        }
        static void Filter()
        {
            Console.WriteLine("Nhap nguong can xet: ");
            double nguong = PhongVIP.NhapSoNguyen();
            var kq = DSPhong.Where(p => p.TinhTienThue() <= nguong).ToList();
            kq.Sort();
            if (kq.Count == 0)
            {
                Console.WriteLine("DS rong!");
            }
            else
            {
                Console.WriteLine("DS sau khi loc la: ");
                PhongVIP.Title();
                foreach(PhongVIP p in kq)
                {
                    p.HienThi();
                }

            }
        }
    }
}
