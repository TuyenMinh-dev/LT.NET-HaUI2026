using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrcEcample
{
    class DienThoai
    {
        private string maDT;
        private string tenDT;
        private double giaBan;
        private string hangSX;

        public DienThoai()
        {
        }

        public DienThoai(string maDT, string tenDT, double giaBan, string hangSX)
        {
            this.MaDT = maDT;
            this.TenDT = tenDT;
            this.GiaBan = giaBan;
            this.HangSX = hangSX;
        }

        public string MaDT { get => maDT; set => maDT = value; }
        public string TenDT { get => tenDT; set => tenDT = value; }
        public double GiaBan { get => giaBan; set => giaBan = value; }
        public string HangSX { get => hangSX; set => hangSX = value; }

        public virtual double TinhGia()
        {
            return giaBan;
        }
    }
}
