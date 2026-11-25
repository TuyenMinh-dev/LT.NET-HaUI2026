using System;
using System.Windows;
using System.Windows.Threading;

namespace Bai1_DangNhap
{
    public partial class MainWindow : Window
    {
       
        private static string tenDaGhiNho = "";

        private const int SO_LAN_SAI_TOI_DA = 3;
        private const int THOI_GIAN_KHOA = 30; // giây
        private int soLanSai = 0;
        private int giayConLai = 0;
        private readonly DispatcherTimer timerKhoa =
            new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };

        public MainWindow()
        {
            InitializeComponent();
            timerKhoa.Tick += TimerKhoa_Tick;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (tenDaGhiNho != "")
            {
                txtUser.Text = tenDaGhiNho;
                chkGhiNho.IsChecked = true;
                txtPass.Focus();
            }
            else
            {
                txtUser.Focus();
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string user = txtUser.Text.Trim();
           
            string pass = txtPass.Password;

          
            if (string.IsNullOrWhiteSpace(user))
            {
                HienLoi("Vui lòng nhập tên đăng nhập!");
                txtUser.Focus();
                return;
            }
            if (pass == "")
            {
                HienLoi("Vui lòng nhập mật khẩu!");
                txtPass.Focus();
                return;
            }
            if (pass.Length < 6)
            {
                HienLoi("Mật khẩu phải có ít nhất 6 ký tự!");
                txtPass.Focus();
                return;
            }
            if (KiemTraTaiKhoan(user, pass))
            {
                tenDaGhiNho = chkGhiNho.IsChecked == true ? user : "";
                MessageBox.Show("Đăng nhập thành công!", "Thông báo",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                new TrangChuWindow(user).Show(); 
                Close();                        
            }
            else
            {
                soLanSai++;
                txtPass.Clear();
                txtPass.Focus();

                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Đăng nhập thất bại",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                if (soLanSai >= SO_LAN_SAI_TOI_DA)
                {
                    KhoaDangNhap();
                }
                else
                {
                    HienLoi($"Sai thông tin đăng nhập ({soLanSai}/{SO_LAN_SAI_TOI_DA} lần).");
                }
            }
        }

      
        private static bool KiemTraTaiKhoan(string user, string pass)
        {
            return (user == "admin" && pass == "123456")
                || (user == "giaovien" && pass == "haui2024");
        }

      
        private void KhoaDangNhap()
        {
            btnLogin.IsEnabled = false;
            giayConLai = THOI_GIAN_KHOA;
            HienLoi($"Sai {SO_LAN_SAI_TOI_DA} lần. Vui lòng thử lại sau {giayConLai} giây.");
            timerKhoa.Start();
        }

        private void TimerKhoa_Tick(object? sender, EventArgs e)
        {
            giayConLai--;
            if (giayConLai > 0)
            {
                HienLoi($"Sai {SO_LAN_SAI_TOI_DA} lần. Vui lòng thử lại sau {giayConLai} giây.");
                return;
            }

           
            timerKhoa.Stop();
            soLanSai = 0;
            btnLogin.IsEnabled = true;
            lblThongBao.Text = "";
        }

        private void HienLoi(string thongBao) => lblThongBao.Text = thongBao;

        private void BtnThoat_Click(object sender, RoutedEventArgs e) => Close();
    }
}