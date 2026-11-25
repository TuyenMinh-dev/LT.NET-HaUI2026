using System.Windows;

namespace Bai1_DangNhap
{
    public partial class TrangChuWindow : Window
    {
        public TrangChuWindow(string tenDangNhap)
        {
            InitializeComponent();
            lblChao.Text = $"Xin chào, {tenDangNhap}!";
        }

        private void BtnDangXuat_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show(); 
            Close();
        }
    }
}