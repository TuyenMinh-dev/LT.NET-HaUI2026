namespace Bai2_CRUD_SinhVien
{
    public class SinhVien
    {
        public string MSSV { get; set; } = "";
        public string HoTen { get; set; } = "";
        public double GPA { get; set; } 
        public string XepLoai =>
            GPA >= 9.0 ? "Xuất sắc" :
            GPA >= 8.0 ? "Giỏi" :
            GPA >= 6.5 ? "Khá" :
            GPA >= 5.0 ? "Trung bình" : "Yếu";
    }
}