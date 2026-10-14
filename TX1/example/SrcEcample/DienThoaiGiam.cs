using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrcEcample
{
    class DienThoaiGiam : DienThoai
    {
        private float phanTramGiam;

        public DienThoaiGiam():base()
        {
        }

        public DienThoaiGiam(string maDT, string tenDT, double giaBan, string hangSX, float phanTramGiam) : base(maDT, tenDT, giaBan, hangSX)
        {
            this.phanTramGiam = phanTramGiam;
        }

        public float PhanTramGiam { get => phanTramGiam; set => phanTramGiam = value; }


        public void NhapThongTin()
        {
            Console.Write("Nhap MaDT: ");
            MaDT = Console.ReadLine();
            Console.Write("Nhap TenDT: ");
            TenDT = Console.ReadLine();
            Console.Write("Nhap gia: ");
            GiaBan = NhapSoThuc();
            Console.Write("Nhap hang: ");
            HangSX = Console.ReadLine();
            Console.WriteLine("Phan tram giam: ");
            phanTramGiam = (float)NhapSoThuc();

        }
        
        public void HienThi()
        {
            Console.WriteLine("| {0,-10} | {1,-15} | {2,-10} | {3,-15} | {4,-10} | {5,-20} | {6,-15} |", MaDT, TenDT, GiaBan, HangSX, phanTramGiam, LoaiGiam(), TinhGia());
        }
        public static void Title()
        {
            Console.WriteLine("| {0,-10} | {1,-15} | {2,-10} | {3,-15} | {4,-10} | {5,-20} | {6,-15} |","MaDT","Ten","Gia","Hang","% Giam","Loai giam","ThanhTien");
            Console.WriteLine(new string('-',117));
        }
        override
            public  double TinhGia()
        {
            return GiaBan * (1 - phanTramGiam / 100);
        }

        public string LoaiGiam()
        {
            if(phanTramGiam > 30)
            {
                return "Sieu sale";
            }else if(phanTramGiam>=10 && phanTramGiam <= 30)
            {
                return "Khuyen mai";
            }
            else
            {
                return "Binh thuong";
            }
        }

        public static int NhapSoNguyen()
        {
            int kq;
            while(!int.TryParse(Console.ReadLine(),out kq) || kq < 0)
            {
                Console.WriteLine("Vui long nhap vao mot so nguyen khong am!");
            }
            return kq;
        }
        public static double NhapSoThuc()
        {
            double kq;
            while (!double.TryParse(Console.ReadLine(), out kq) || kq < 0)
            {
                Console.WriteLine("Vui long nhap vao mot so thuc khong am!");
            }
            return kq;
        }
    }
}
