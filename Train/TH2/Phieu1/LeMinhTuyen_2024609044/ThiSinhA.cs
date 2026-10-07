using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeMinhTuyen_2024609044
{
    class ThiSinhA
    {
        public string soBaoDanh { get; set; }
        public string hoten { get; set; }
        public string diaChi { get; set; }
        public double diemToan { get; set; }
        public double diemLy { get; set; }
        public double diemHoa { get; set; }
        public double diemUuTien { get; set; }

        public ThiSinhA()
        {
        }
        public ThiSinhA(string soBaoDanh, string hoten, string diaChi, double diemToan, double diemLy, double diemHoa, double diemUuTien)
        {
            this.soBaoDanh = soBaoDanh;
            this.hoten = hoten;
            this.diaChi = diaChi;
            this.diemToan = diemToan;
            this.diemLy = diemLy;
            this.diemHoa = diemHoa;
            this.diemUuTien = diemUuTien;
        }

        public double tongDiem
        {
            get { return diemToan + diemLy + diemHoa + diemUuTien; }
        }

        public override string ToString()
        {
            return string.Format("| {0,-8} | {1,-20} | {2,-15} | {3,-6:F1} | {4,-6:F1} | {5,-6:F1} | {6,-6:F1} | {7,-8:F1} |",
                soBaoDanh, hoten, diaChi, diemToan, 
                diemLy, diemHoa, diemUuTien, tongDiem);
            } 
    }
}
