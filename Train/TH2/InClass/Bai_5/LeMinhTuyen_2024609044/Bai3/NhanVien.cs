using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3
{
    class NhanVien
    {
        public string HoTen { get; set; }
        public double Luong { get; set; }

        public NhanVien(string hoTen, double luong)
        {
            if (string.IsNullOrEmpty(hoTen))
            {
                throw new ArgumentException("Ho ten khong duoc de trong!");
            }
            if(luong <= 0)
            {
                throw new ArgumentException("Luong phai lon hon 0");
            }
            HoTen = hoTen;
            Luong = luong;
        }
        public void InThongTin()
        {
            Console.WriteLine("| {0,-20} | {1,-15} |", HoTen, Luong);
        }
    }
}
