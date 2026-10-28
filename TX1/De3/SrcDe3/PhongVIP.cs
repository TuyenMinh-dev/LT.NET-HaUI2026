using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrcDe3
{
    class PhongVIP : Phong, IComparable<PhongVIP>
    {
        private double phiDichVu;

        public PhongVIP():base()
        {
        }

        public PhongVIP(string maPhong, string tenPhong, double giaCoBan, int soNgayThue, double phiDichVu) : base(maPhong, tenPhong, giaCoBan, soNgayThue)
        {
            this.PhiDichVu = phiDichVu;
        }

        public double PhiDichVu { get => phiDichVu; set => phiDichVu = value; }
        public double TyLeGiam()
        {
            if(SoNgayThue >= 10)
            {
                return 0.15;
            }else if(SoNgayThue>=5 && SoNgayThue < 10)
            {
                return 0.05;
            }else  
            {
                return 0;
            }
        }
            public override double TinhTienThue()
        {
            return GiaCoBan * SoNgayThue * (1 - TyLeGiam()) + phiDichVu;
        }
        public string XepHang()
        {
            double tongTien = TinhTienThue();
            if (tongTien > 20_000_000)
            {
                return "Hang Kim Cuong";
            }else if(tongTien>=10_000_000 && tongTien <= 20_000_000)
            {
                return "Hang Vang";
            }
            else
            {
                return "Hang Bac";
            }
        }
        public int CompareTo(PhongVIP other)
        {
            if (other == null)
            {
                return 1;
            }return other.TinhTienThue().CompareTo(this.TinhTienThue());
        }
        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine(" {0,-10} | {1,-15} | {2,-20} | {3,-20} |",phiDichVu,TyLeGiam(),TinhTienThue(),XepHang());
        }
        public static void Title()
        {
            Console.WriteLine("| {0,-10} | {1,-15} | {2,-15} | {3,-10} | {4,-10} | {5,-15} | {6,-20} | {7,-20} | ","MaPhong", "TenPhong", "GiaCoBan", "SoNgayThue","PhiDichVu","TyLeGiam","ThanhTien","XepHang");
            Console.WriteLine(new string('-',120));
        } 
        public void NhapThongTin()
        {
            Console.Write("Nhap ma phong: ");
            MaPhong = Console.ReadLine();
            Console.Write("Nhap ten phong: ");
            TenPhong = Console.ReadLine();
            Console.Write("Nhap gia co ban: ");
            GiaCoBan = NhapSoThuc();
            Console.Write("Nhap so ngay thue: ");
            SoNgayThue = NhapSoNguyen();
            Console.Write("Nhap phi dich vu: ");
            phiDichVu = NhapSoThuc();

        }
        public static double NhapSoThuc()
        {
            double kq;
            while(!double.TryParse(Console.ReadLine(),out kq) || kq<0)
            {
                Console.WriteLine("Vui long nhap vao mot so thuc khong am!");
            }return kq;
        }
        public static int NhapSoNguyen()
        {
            int kq;
            while (!int.TryParse(Console.ReadLine(), out kq) || kq < 0)
            {
                Console.WriteLine("Vui long nhap vao mot so nguyen khong am!");
            }
            return kq;
        }

    }
}
