using System;
using System.Collections.Generic;
using System.Linq;

namespace LeMinhTuyen_2024609044
{
    class Program
    {
        static List<ThiSinhA> danhSach = new List<ThiSinhA>();

        // Hàm hỗ trợ nhập số thực an toàn, tránh crash chương trình
        static double NhapDiem(string prompt)
        {
            double val;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out val) && val >= 0 && val <= 10)
                    return val;
                Console.WriteLine("Diem khong hop le (phai la so tu 0 den 10). Vui long nhập lai!");
            }
        }

        static void Nhap()
        {
            Console.Write("Nhap SBD: ");
            string sbd = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(sbd))
            {
                Console.WriteLine("SBD khong duoc de rong!");
                return;
            }

            if (danhSach.Exists(x => x.soBaoDanh.Equals(sbd, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("So bao danh nay da ton tai, khong the them!");
                return;
            }

            Console.Write("Nhap ho ten: ");
            string ten = Console.ReadLine();
            Console.Write("Dia chi: ");
            string address = Console.ReadLine();

            double toan = NhapDiem("Diem toan: ");
            double ly = NhapDiem("Diem ly: ");
            double hoa = NhapDiem("Diem hoa: ");

            Console.Write("Diem uu tien: ");
            double uuTien;
            while (!double.TryParse(Console.ReadLine(), out uuTien) || uuTien < 0)
            {
                Console.Write("Diem uu tien khong hop le, nhap lai: ");
            }

            ThiSinhA ts = new ThiSinhA(sbd, ten, address, toan, ly, hoa, uuTien);
            danhSach.Add(ts);
            Console.WriteLine($"Them thanh cong thi sinh co SBD: {sbd}");
        }

        static void HienThiTheoTongDiem(List<ThiSinhA> ds)
        {
            if (ds.Count == 0)
            {
                Console.WriteLine("Danh sach rong!");
                return;
            }
            Console.Write("Nhap vao nguong diem x can loc (>= x): ");
            double nguong = double.Parse(Console.ReadLine());
            List<ThiSinhA> ketQua = ds.FindAll(x => x.tongDiem >= nguong);

            if (ketQua.Count == 0)
            {
                Console.WriteLine("Khong co thi sinh nao dat tong diem >= " + nguong);
                return;
            }

            Console.WriteLine("\n--- DANH SACH THI SINH DAT NGUONG DIEM ---");
            HienThiDanhSach(ketQua);
        }

        static void HienThiTheoDiaChi(List<ThiSinhA> ds)
        {
            if (ds.Count == 0)
            {
                Console.WriteLine("Danh sach rong!");
                return;
            }

            Console.Write("Nhap dia chi can tim: ");
            string diaChi = Console.ReadLine()?.Trim();

            // Sửa lỗi: Dùng tham số ds thay vì biến toàn cục danhSach
            List<ThiSinhA> ketQua = ds.FindAll(
                x => x.diaChi.Trim().Equals(diaChi, StringComparison.OrdinalIgnoreCase));

            if (ketQua.Count == 0)
            {
                Console.WriteLine("Khong co thi sinh nao co dia chi: " + diaChi);
                return;
            }

            Console.WriteLine("\n--- DANH SACH THI SINH THEO DIA CHI ---");
            HienThiDanhSach(ketQua);
        }

        static void HienThiDanhSach(List<ThiSinhA> ds)
        {
            if (ds.Count == 0)
            {
                Console.WriteLine("=> Danh sach rong!");
                return;
            }

            // In tiêu đề bảng (Header)
            string headerLine = new string('-', 92);
            Console.WriteLine(headerLine);
            Console.WriteLine(string.Format("| {0,-8} | {1,-20} | {2,-15} | {3,-6} | {4,-6} | {5,-6} | {6,-6} | {7,-8} |",
                "SBD", "Ho va Ten", "Dia Chi", "Toan", "Ly", "Hoa", "Uu Tien", "Tong Diem"));
            Console.WriteLine(headerLine);

            // In từng dòng dữ liệu thí sinh
            foreach (ThiSinhA ts in ds)
            {
                Console.WriteLine(ts);
            }
            Console.WriteLine(headerLine);
        }

        // Sửa lỗi hiển thị lặp thông báo không tìm thấy & sửa tên phương thức chuẩn PascalCase
        static void FindById(List<ThiSinhA> ds)
        {
            if (ds.Count == 0)
            {
                Console.WriteLine("Danh sach rong!");
                return;
            }

            Console.Write("Nhap so bao danh cua thi sinh muon tim: ");
            string sbd = Console.ReadLine()?.Trim();

            ThiSinhA ts = ds.FirstOrDefault(x => x.soBaoDanh.Equals(sbd, StringComparison.OrdinalIgnoreCase));

            if (ts != null)
            {
                Console.WriteLine($"\nDa tim thay sinh vien co so bao danh {sbd}:");
                Console.WriteLine(ts);
            }
            else
            {
                Console.WriteLine($"Khong tim thay thi sinh co so bao danh {sbd}");
            }
        }

        static void Main(string[] args)
        {
            int choice = 0;
            do
            {
                Console.WriteLine("\n================ MENU ================");
                Console.WriteLine("1. Nhap thong tin 1 thi sinh");
                Console.WriteLine("2. Hien thi danh sach cac thi sinh");
                Console.WriteLine("3. Hien thi cac sinh vien theo tong diem");
                Console.WriteLine("4. Hien thi cac sinh vien theo dia chi");
                Console.WriteLine("5. Tim kiem theo so bao danh");
                Console.WriteLine("6. Ket thuc chuong trinh");
                Console.WriteLine("======================================");

                Console.Write("Nhap lua chon cua ban: ");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Write("Vui long nhap vao mot so nguyen hop le: ");
                }

                Console.WriteLine(); // Tạo khoảng trống giữa menu và kết quả
                switch (choice)
                {
                    case 1:
                        Nhap();
                        break;
                    case 2:
                        HienThiDanhSach(danhSach);
                        break;
                    case 3:
                        HienThiTheoTongDiem(danhSach);
                        break;
                    case 4:
                        HienThiTheoDiaChi(danhSach);
                        break;
                    case 5:
                        FindById(danhSach);
                        break;
                    case 6:
                        Console.WriteLine("Thoat chuong trinh!");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn từ 1 đến 6!");
                        break;
                }

            } while (choice != 6);
        }
    }
}