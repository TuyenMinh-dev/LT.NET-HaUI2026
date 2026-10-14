using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srcDe2
{
    class NhanVienKinhDoanh : NhanVien
    {
        public double doanhSo;

        public NhanVienKinhDoanh():base()
        {
        }
        public NhanVienKinhDoanh(string maNV, string hoTen, double luongCoBan, int soNgayCong, double doanhSo) : base(maNV, hoTen, luongCoBan, soNgayCong)
        {
            this.doanhSo = doanhSo;
        }
        
        
        
        public double HoaHong()
        {
            if (doanhSo > 100000000)
            {
                return 0.1 * doanhSo;
            }
            else if (doanhSo >= 50000000 && doanhSo <= 100000000)
            {
                return 0.05 * doanhSo;
            }
            else
            {
                return 0.02 * doanhSo;
            }
        }
        override
        public double TinhThucLinh()
        {
            return base.TinhThucLinh() + HoaHong();
        }
        public string XepLoai()
        {
            if (HoaHong() > 10000000)
            {
                return "Xuat sac";
            }
            else if(HoaHong()>=2500000 && HoaHong() <= 10000000){
                return "Dat";
            }
            else
            {
                return "Can co gang";
            }
        }
        public static void Title()
        {
            Console.WriteLine("| {0,-10} | {1,-15} | {2,-15} | {3,-10} | {4,-15} | {5,-15} | {6,-15} | {7,-15} |","MaNV","Ten","LuongCB","Cong","DoanhSo","HoaHong","XepLoai","ThanhTien");
            Console.WriteLine(new string ('-',150));
        }
        public void HienThi()
        {
            Console.WriteLine("| {0,-10} | {1,-15} | {2,-15} | {3,-10} | {4,-15} | {5,-15} | {6,-15} | {7,-15} |",maNV,hoTen,luongCoBan,soNgayCong,doanhSo,HoaHong(),XepLoai(),TinhThucLinh());
        }
    }
}
