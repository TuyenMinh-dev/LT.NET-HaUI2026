using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Bai2_CRUD_SinhVien
{
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<SinhVien> _list = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        { 
            _list.Add(new SinhVien { MSSV = "2024609044", HoTen = "Lê Minh Tuyên", GPA = 9.2 });
            _list.Add(new SinhVien { MSSV = "2021002", HoTen = "Trần Thị Bình", GPA = 8.1 });
            _list.Add(new SinhVien { MSSV = "2021003", HoTen = "Lê Minh Cường", GPA = 6.8 });
            _list.Add(new SinhVien { MSSV = "2021004", HoTen = "Phạm Thu Dung", GPA = 5.5 });
            _list.Add(new SinhVien { MSSV = "2021005", HoTen = "Hoàng Văn Em", GPA = 4.2 });

            HienThiDanhSach();
        }

       
        private void HienThiDanhSach()
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            if (tuKhoa == "")
            {
                dgSinhVien.ItemsSource = _list; 
            }
            else
            {
               
                dgSinhVien.ItemsSource = _list
                    .Where(sv => sv.HoTen.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase)
                              || sv.MSSV.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            dgSinhVien.Items.Refresh(); 
            lblTongSo.Text = $"Hiển thị {dgSinhVien.Items.Count} / {_list.Count} sinh viên";
        }

      
        private static bool TryDocDiem(string chuoi, out double diem)
        {
            return double.TryParse(chuoi.Trim().Replace(',', '.'),
                NumberStyles.Float, CultureInfo.InvariantCulture,
                out diem);
        }

        private SinhVien? DocDuLieuForm()
        {
            string mssv = txtMSSV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();

            if (string.IsNullOrWhiteSpace(mssv) || string.IsNullOrWhiteSpace(hoTen))
            {
                BaoLoi("MSSV và Họ tên không được để trống!");
                (mssv == "" ? txtMSSV : txtHoTen).Focus();
                return null;
            }

            if (!TryDocDiem(txtGPA.Text, out double gpa) || gpa < 0 || gpa > 10)
            {
                BaoLoi("Điểm trung bình phải là số trong khoảng 0 - 10!");
                txtGPA.Focus();
                return null;
            }

            return new SinhVien { MSSV = mssv, HoTen = hoTen, GPA = gpa };
        }

       
        private bool TrungMSSV(string mssv, SinhVien? boQua = null)
        {
            return _list.Any(sv => sv != boQua
                && sv.MSSV.Equals(mssv, StringComparison.OrdinalIgnoreCase));
        }

        private static void BaoLoi(string thongBao) =>
            MessageBox.Show(thongBao, "Lỗi nhập liệu",
                MessageBoxButton.OK, MessageBoxImage.Warning);

        private void XoaTrangForm()
        {
            txtMSSV.Clear();
            txtHoTen.Clear();
            txtGPA.Clear();
            txtMSSV.Focus();
        }

        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SinhVien? sv = DocDuLieuForm();
                if (sv == null) return;

                if (TrungMSSV(sv.MSSV))
                {
                    BaoLoi($"MSSV {sv.MSSV} đã tồn tại!");
                    txtMSSV.Focus();
                    return;
                }

                _list.Add(sv);
                txtTimKiem.Clear();
                HienThiDanhSach();
                dgSinhVien.SelectedItem = sv;
                dgSinhVien.ScrollIntoView(sv);

                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgSinhVien.SelectedItem is not SinhVien chon)
                {
                    BaoLoi("Hãy chọn một sinh viên trên danh sách để sửa!");
                    return;
                }

                SinhVien? moi = DocDuLieuForm();
                if (moi == null) return;

                if (TrungMSSV(moi.MSSV, chon))
                {
                    BaoLoi($"MSSV {moi.MSSV} đã thuộc về sinh viên khác!");
                    return;
                }

               
                chon.MSSV = moi.MSSV;
                chon.HoTen = moi.HoTen;
                chon.GPA = moi.GPA;

              
                HienThiDanhSach();
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (dgSinhVien.SelectedItem is not SinhVien chon)
            {
                BaoLoi("Hãy chọn một sinh viên trên danh sách để xóa!");
                return;
            }

            var traLoi = MessageBox.Show(
                $"Bạn có chắc muốn xóa sinh viên {chon.HoTen} ({chon.MSSV})?",
                "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (traLoi == MessageBoxResult.Yes)
            {
                _list.Remove(chon);
                HienThiDanhSach(); 
                XoaTrangForm();
            }
        }

        private void BtnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            HienThiDanhSach();
            if (dgSinhVien.Items.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sinh viên phù hợp.", "Tìm kiếm");
            }
        }

        private void BtnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            txtTimKiem.Clear();
            dgSinhVien.SelectedItem = null;
            HienThiDanhSach();
            XoaTrangForm();
        }

      
        private void DgSinhVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgSinhVien.SelectedItem is SinhVien sv)
            {
                txtMSSV.Text = sv.MSSV;
                txtHoTen.Text = sv.HoTen;
                txtGPA.Text = sv.GPA.ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}