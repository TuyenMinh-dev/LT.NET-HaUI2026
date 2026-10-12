using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3
{
    class PhongBan
    {
        public string TenPhong { get; set; }
        public List<NhanVien> DanhSach = new List<NhanVien>();

        public PhongBan(string tenPhong)
        {
            if (string.IsNullOrEmpty(tenPhong))
            {
                throw new ArgumentException("Ten phong khong duoc trong");
            }
            TenPhong = tenPhong;
            
        }

        public void ThemNV(NhanVien nv)
        {
            if (nv == null)
            {
                throw new ArgumentException("Nhan vien khong hop le!");
            }
            DanhSach.Add(nv);
        }
        public double TinhTongLuong()
        {
            return DanhSach.Sum(nv => nv.Luong);
        }
        public void Title()
        {
            Console.WriteLine("| {0,-20} | {1,-15} |","Ho ten","Luong");
            Console.WriteLine(new string('-',40));
        }
        public void InDanhSach()
        {
            Console.WriteLine($"DSNV Phong" + TenPhong);
            if (DanhSach.Count == 0)
            {
                Console.WriteLine("Chua co nhan vien nao!");
                return;
            }
            Title();
            foreach(NhanVien nv in DanhSach)
            {
                nv.InThongTin();
            }

        }
        public NhanVien TimLuongMax()
        {
            if (DanhSach.Count == 0) return null;
            return DanhSach.OrderByDescending(nv => nv.Luong).First();
        }
        public double TinhLuongTB()
        {
            if (DanhSach.Count == 0) return 0;
            return DanhSach.Average(nv => nv.Luong);
        }
    }
}
