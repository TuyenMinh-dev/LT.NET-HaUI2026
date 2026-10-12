using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    class HinhChuNhat
    {
        public double ChieuDai { get; set; }
        public double ChieuRong { get; set; }

        public HinhChuNhat(double ChieuDai, double ChieuRong)
        {
            if (ChieuDai <= 0)
            {
                throw new ArgumentException("Chieu dai phai > 0");
            }
            if (ChieuRong <= 0)
            {
                throw new ArgumentException("Chieu rong phai >0");
            }
            this.ChieuDai = ChieuDai;
            this.ChieuRong = ChieuRong;
        }
        public double TinhChuVi()
        {
            return 2 * (ChieuDai + ChieuRong);
        }
        public double TinhDienTich()
        {
            return ChieuDai * ChieuRong;
        }
    }
}
