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

namespace OnTap
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

        private void btnNhap_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtHoTen.Text) ||
               string.IsNullOrWhiteSpace(txtTuoi.Text) ||
               string.IsNullOrWhiteSpace(txtHeSoLuong.Text) ||
               cbPhongBan.SelectedItem == null)
            {
                MessageBox.Show("Vui long nhap day du thong tin!","Canh bao", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if(!int.TryParse(txtTuoi.Text, out int tuoi) || tuoi < 18)
            {
                MessageBox.Show("Tuoi phai la so nguyen va >=18!", "Canh bao", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtTuoi.Focus();
                return;
            }
            if(!double.TryParse(txtHeSoLuong.Text, out double heSoLuong) || heSoLuong <= 0)
            {
                MessageBox.Show("He so luong phai la so thuc duong","Canh bao", MessageBoxButton.OK,MessageBoxImage.Warning);
            }
            // 4. Đọc Phòng Ban từ ComboBox
            string phongBan = (cbPhongBan.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "";
            // 5. Tạo đối tượng NhanVien và thêm vào danh sách
            NhanVien nv = new NhanVien
            {
                HoTen = txtHoTen.Text.Trim(),
                Tuoi = tuoi,
                HeSoLuong = heSoLuong,
                PhongBan = phongBan
            };
            danhSach.Add(nv);
            // 6. Làm mới DataGrid (Bắt buộc gán null trước khi gán lại)
            dgDanhSach.ItemsSource = null;
            dgDanhSach.ItemsSource = danhSach;
            // 7. Xóa trắng form để nhập người tiếp theo
            txtHoTen.Clear();
            txtTuoi.Clear();
            txtHeSoLuong.Clear();
            cbPhongBan.SelectedItem = null;
            txtHoTen.Focus();


        }

        private void btnWindow2_Click(object sender, RoutedEventArgs e)
        {
            if(danhSach.Count == 0)
            {
                MessageBox.Show("Danh sach rong, chua co nhan vien nao!", "Thong bao", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            int maxTuoi = danhSach.Max(nv => nv.Tuoi);
            List<NhanVien> dsMax = danhSach.Where(nv => nv.Tuoi == maxTuoi).ToList();

            Window2 w2 = new Window2(dsMax);
            w2.ShowDialog();
         }
    }
}
