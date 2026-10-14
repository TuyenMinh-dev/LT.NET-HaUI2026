using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srcDe2
{
    class NhanVien
    {
        

        public string maNV { get; set; }
        public string hoTen { get; set; }
        public double luongCoBan { get; set; }
        public int soNgayCong { get; set; }

        public NhanVien()
        {

        }

        public NhanVien(string maNV, string hoTen, double luongCoBan, int soNgayCong)
        {
            this.maNV = maNV;
            this.hoTen = hoTen;
            this.luongCoBan = luongCoBan;
            this.soNgayCong = soNgayCong;
        }
        public virtual double TinhThucLinh()
        {
            return (luongCoBan / 22) * soNgayCong;
        }
    }
}
