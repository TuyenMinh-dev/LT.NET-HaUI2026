using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srcDe1
{
    class SanPhamKhuyenMai : SanPham
    {
       

        public float phanTramGiam { get; set; }

        public SanPhamKhuyenMai() :base()
        {
        }

        public SanPhamKhuyenMai(string maSP, string tenSP, double gia, int soLuong,float phanTramGiam) : base(maSP, tenSP, gia, soLuong)
        {   
            this.phanTramGiam = phanTramGiam;
        }

        override
            public double TinhThanhTien()
        {
            return gia * soLuong * (1 - phanTramGiam / 100);
        }
        public string XepHang()
        {
            if (phanTramGiam > 30)
            {
                return "VIP";
            }
            else if(phanTramGiam>=10 && phanTramGiam <= 30)
            {
                return "Thuong";
            }
            else
            {
                return "Thuong thiet";
            }
        }
        public void NhapThongTin()
        {
            Console.Write("Nhap MaSP: ");
            maSP = Console.ReadLine();
            Console.Write("Nhap ten: ");
            tenSP = Console.ReadLine();
            Console.Write("Nhap gia: ");
            gia = NhapSoThuc();
            Console.WriteLine("Nhap so luong: ");
            soLuong = NhapSoNguyen();
        }
        public void HienThi()
        {
            Console.WriteLine("| {0,-10} | {1,-15} | {2,-10} | {3,-10} | {4,-10} | {5,-15} | {6,-10} |",maSP,tenSP,gia,soLuong,phanTramGiam,XepHang(),TinhThanhTien());
        }
        public static void title()
        {
            Console.WriteLine("| {0,-10} | {1,-15} | {2,-10} | {3,-10} | {4,-10} | {5,-15} | {6,-10} |", "MaSP", "Ten", "Gia","SLG" ,"% giam gia", "XepHang", "ThanhTien");
            Console.WriteLine(new string('-',100));
        }
        public double NhapSoThuc()
        {
            double kq;
            while(!double.TryParse(Console.ReadLine(),out kq)||kq<0)
            {
                Console.WriteLine("Vui long nhap vao mot so thuc!");
            }
            return kq;
        }
        public int NhapSoNguyen()
        {
            int kq;
            while (!int.TryParse(Console.ReadLine(), out kq) || kq<0)
            {
                Console.WriteLine("Vui long nhap vao mot so nguyen!");
            }
            return kq;
        }
    }
}
