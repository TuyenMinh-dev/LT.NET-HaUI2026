using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srcDe1
{
    class SanPham
    {
        public string maSP { set; get; }
        public string tenSP { set; get; }
        public double gia { set; get; }
        public int soLuong { set; get; }
        public SanPham()
        {
        }

        public SanPham(string maSP, string tenSP, double gia, int soLuong)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.gia = gia;
            this.soLuong = soLuong;
        }
        public virtual double TinhThanhTien()
        {
            return gia * soLuong;
        }
    }
}
