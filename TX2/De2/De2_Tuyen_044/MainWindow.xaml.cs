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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace De2_Tuyen_044
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<NhanVien> danhSach = new List<NhanVien>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            string hoTen = txtName.Text.Trim();
            // 1. Kiểm tra nhập/chọn đầy đủ tất cả các trường
            if (string.IsNullOrWhiteSpace(maNV) ||
                string.IsNullOrWhiteSpace(hoTen) ||
                dpNgayTuyen.SelectedDate == null ||
                cbPhongBan.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtSoNgayLam.Text)
                )
            {
                MessageBox.Show("Vui long nhap day du cac thong tin", "Canh bao", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // 2. Kiem tra trung Ma NV
            if (danhSach.Any(x => x.MaNV == maNV))
            {
                MessageBox.Show("Ma nhan vien da ton tai!","Canh bao", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtMaNV.Focus();
                return;
            }
            // 3. Kiểm tra Ngày tuyển phải <= ngày hiện tại
            if(dpNgayTuyen.SelectedDate.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Ngay tuyen phai truoc hoac bang bang hom nay!", "Canh bao", MessageBoxButton.OK, MessageBoxImage.Warning);
                dpNgayTuyen.Focus();
                return;
            }
            // 4. Kiểm tra Số ngày làm là số nguyên từ 1 đến 31
            if(!int.TryParse(txtSoNgayLam.Text, out int soNgay) || soNgay<1 || soNgay > 31)
            {
                MessageBox.Show("So ngay lam phai la so nguyen tu 1 den 31", "Canh bao", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtSoNgayLam.Focus();
                return;
            }
            // 5. Đọc dữ liệu từ DatePicker, RadioButton, ComboBox
            DateTime ngayTuyen = dpNgayTuyen.SelectedDate.Value;
            string gioiTinh = (radNam.IsChecked == true) ? "Nam" : "Nu";
            string phongBan = (cbPhongBan.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "";

            NhanVien nv = new NhanVien
            {
                MaNV = maNV,
                HoTen = hoTen,
                NgayTuyen = ngayTuyen,
                GioiTinh = gioiTinh,
                PhongBan = phongBan,
                SoNgayLam = soNgay
            };
            danhSach.Add(nv);

            // 7. Làm mới DataGrid
            dgDanhSach.ItemsSource = null;
            dgDanhSach.ItemsSource = danhSach;

            // 8. Xóa trắng form để nhập tiếp
            txtMaNV.Clear();
            txtName.Clear();
            dpNgayTuyen.SelectedDate = null;
            radNam.IsChecked = true;
            txtSoNgayLam.Clear();
            cbPhongBan.SelectedItem = null;
            txtMaNV.Focus();
        }

        private void btnWindow2_Click(object sender, RoutedEventArgs e)
        {
            NhanVien chon = dgDanhSach.SelectedItem as NhanVien;
            if(chon==null)
            {
                MessageBox.Show("Vui long chon mot nhan vien", "Thong bao", MessageBoxButton.OK, MessageBoxImage.Information);
                return;

            }
            Window2 w2 = new Window2(chon);
            w2.ShowDialog();
        }
    }
}
