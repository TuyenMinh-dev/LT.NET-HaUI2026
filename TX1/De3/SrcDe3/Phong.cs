using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrcDe3
{
    abstract class Phong
    {
        private string maPhong;
        private string tenPhong;
        private double giaCoBan;
        private int soNgayThue;

        public string MaPhong { get => maPhong; set => maPhong = value; }
        public string TenPhong { get => tenPhong; set => tenPhong = value; }
        public double GiaCoBan { get => giaCoBan; set => giaCoBan = value; }
        public int SoNgayThue { get => soNgayThue; set => soNgayThue = value; }

        protected Phong()
        {
        }

        protected Phong(string maPhong, string tenPhong, double giaCoBan, int soNgayThue)
        {
            this.MaPhong = maPhong;
            this.TenPhong = tenPhong;
            this.GiaCoBan = giaCoBan;
            this.SoNgayThue = soNgayThue;
        }
        public abstract double TinhTienThue();
        public virtual void HienThi()
        {
            Console.Write("| {0,-10} | {1,-15} | {2,-15} | {3,-10} |",MaPhong,TenPhong,GiaCoBan,SoNgayThue);
        }
        
    }
}
