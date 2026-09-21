using System;

namespace Lab03_QuanLySinhVienOOP
{
    public class SinhVien : Nguoi
    {
        public string MaSinhVien { get; }
        public string MaLop { get; set; }

        private double _diem;
        public double DiemTrungBinh
        {
            get => _diem;
            set => _diem = value is >= 0 and <= 10
                ? value
                : throw new ArgumentException("Điểm trung bình chỉ nhận giá trị từ 0 đến 10.");
        }

        public SinhVien(string maSinhVien, string hoTen, DateTime ngaySinh, string maLop, double diem)
            : base(hoTen, ngaySinh)
        {
            MaSinhVien = maSinhVien;
            MaLop = maLop;
            DiemTrungBinh = diem;
        }

        public string XepLoai() => DiemTrungBinh switch
        {
            >= 8.0 => "Giỏi",
            >= 6.5 => "Khá",
            >= 5.0 => "Trung bình",
            _ => "Yếu"
        };

        public override string LayThongTin() =>
            string.Format("{0,-8}{1,-25}{2,-10}{3,-8:0.0}{4,-10}", MaSinhVien, HoTen, MaLop, DiemTrungBinh, XepLoai());
    }
}
