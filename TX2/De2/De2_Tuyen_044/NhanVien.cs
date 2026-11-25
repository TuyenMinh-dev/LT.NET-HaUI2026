using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De2_Tuyen_044
{
    public class NhanVien
    {
        public string MaNV { get; set; } = "";
        public string HoTen { get; set; } = "";
        public DateTime NgayTuyen { get; set; }
        public string GioiTinh { get; set; } = "";
        public string PhongBan { get; set; } = "";
        public int SoNgayLam { get; set; }

        public double TienLuong
        {
            get
            {
                if (SoNgayLam <= 10)
                {
                    return SoNgayLam * 200_000;
                }else
                {
                    return SoNgayLam * 300_000;
                }
            }
        }
    }
}
