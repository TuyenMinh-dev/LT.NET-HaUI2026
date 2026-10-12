using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    class SinhVien
    {
        public string HoTen { get; set; }
        public string MSSV { get; set; }
        public double DiemTB { get; set; }

        public SinhVien(string hoTen, string mSSV, double diemTB)
        {
            HoTen = hoTen;
            MSSV = mSSV;
            DiemTB = diemTB;
        }

        public string XepLoai()
        {
            if (DiemTB >= 9)
            {
                return "Xuat sac";
            }else if(DiemTB >= 8)
            {
                return "Gioi";
            }else if(DiemTB >=7)
            {
                return "Kha";
            }
            else if(DiemTB >= 5)
            {
                return "Trung binh";
            }
            else
            {
                return "Yeu";
            }
        }
        public static void InTieuDe()
        {
            Console.WriteLine("| {0,-10} | {1,-20} | {2,-10} | {3,-15} |","MSSV","Ho va ten","Diem TB","Xep loai");
            Console.WriteLine(new string('-',68));
            
        }
        public void InTT()
        {
            Console.WriteLine("| {0,-10} | {1,-20} | {2,-10} | {3,-15} |", MSSV, HoTen, DiemTB, XepLoai());
        }
    }
}
