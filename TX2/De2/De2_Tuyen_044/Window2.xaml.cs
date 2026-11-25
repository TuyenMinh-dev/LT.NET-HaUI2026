using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace De2_Tuyen_044
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2(NhanVien nv)
        {
            InitializeComponent();
            txtMaNV.Text = nv.MaNV;
            txtHoTen.Text = nv.HoTen;
            txtNgayTuyen.Text = nv.NgayTuyen.ToString("dd-MM-yyyy");
            txtGioiTinh.Text = nv.GioiTinh;
            txtPhongBan.Text = nv.PhongBan;
            txtSoNgayLam.Text = nv.SoNgayLam.ToString();
            txtTienLuong.Text = nv.TienLuong.ToString("N0");

        }
    }
}
