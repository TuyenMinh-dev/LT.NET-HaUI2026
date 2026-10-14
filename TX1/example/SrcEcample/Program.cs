using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrcEcample
{
    class Program
    {
        static List<DienThoaiGiam> ListDT = new List<DienThoaiGiam>();
        static void menu()
        {
            Console.WriteLine("---MENU---");
            Console.WriteLine("1. Them dien thoai");
            Console.WriteLine("2. Hien thi toan bo, sap xep theo TinhGia() tang dan");
            Console.WriteLine("3. Liet ke cac DT co gia <= x");
            Console.WriteLine("4. Tim kiem va hien thi theo maDT");
            Console.WriteLine("0. Thoat chuong trinh");
        }
        static void Them()
        {
            DienThoaiGiam dt = new DienThoaiGiam();
            dt.NhapThongTin();
            if(ListDT.Any(d =>d.MaDT == dt.MaDT))
            {
                Console.WriteLine("Ma ID nay da ton tai!");
                Console.WriteLine("Khong them dien thoai thanh cong!");
                return;
            }
            ListDT.Add(dt);
            Console.WriteLine("Da them dien thoai moi thanh cong!");
        }
        static void HienThiAll()
        {   if(ListDT.Count == 0)
            {
                Console.WriteLine("Danh sach rong!");
                return;
            }
            DienThoaiGiam.Title();
            var kq = ListDT.OrderBy(dt => dt.TinhGia()).ToList();
            foreach(DienThoaiGiam dt in kq)
            {
                dt.HienThi();
            }
        }
        public static void FindById()
        {
            Console.WriteLine("Nhap ma muon tim: ");
            string ma = Console.ReadLine();
            var kq = ListDT.FirstOrDefault(dt => dt.MaDT == ma);
            if (kq == null)
            {
                Console.WriteLine("Khong tim thay dien thoai co ma "+ ma);
            }
            else
            {
                Console.WriteLine("Da tim thay!");
                DienThoaiGiam.Title();
                kq.HienThi();
            }
        }
        public static void Filter()
        {
            Console.Write("Nhap nguong can xet: ");
            double nguong = DienThoaiGiam.NhapSoThuc();
            var kq = ListDT.Where(dt => dt.TinhGia() <= nguong).ToList();
            var ds = kq.OrderBy(dt => dt.TinhGia()).ToList();
            if (ds.Count==0)
            {
                Console.WriteLine("Hien khong co dien thoai nao <= "+  nguong);
            }
            else
            {
                DienThoaiGiam.Title();
                foreach(DienThoaiGiam dt in ds)
                {
                    dt.HienThi();
                }
            }
        }
        
        static void Main(string[] args)
        {
            ListDT.Add(new DienThoaiGiam("01", "iphone15", 18_000_000, "Apple", 15));
            ListDT.Add(new DienThoaiGiam("02", "iphone16", 20_000_000, "Apple", 10));
            ListDT.Add(new DienThoaiGiam("03", "iphone17", 40_000_000, "Apple", 2));
            int choice;
            do
            {
                menu();
                Console.Write("Vui long nhap lua chon cua ban:");
                choice = DienThoaiGiam.NhapSoNguyen();
                switch (choice)
                {
                    case 1:
                        Them();
                        Console.WriteLine(new string('*', 50));
                        break;
                    case 2:
                        HienThiAll();
                        Console.WriteLine(new string('*', 50));
                        break;
                    case 3:
                        Filter();
                        Console.WriteLine(new string('*', 50));
                        break;
                    case 4:
                        FindById();
                        Console.WriteLine(new string('*', 50));
                        break;
                    case 0:
                        Console.WriteLine("Thoat chuong trinh!");
                        Console.WriteLine(new string('*', 50));
                        break;
                    default:
                        Console.WriteLine("Vui long nhap vao mot so tu 0 den 4!");
                        break;
                }

            } while (choice != 0);
        }
    }
}
