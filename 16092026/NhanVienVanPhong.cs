using System;

namespace QuanLyNhanVien
{
    public class NhanVienVanPhong : NhanVien
    {
        public const double PHU_CAP_NGAY = 200000;

        private int soNgayLamViec;

        public int SoNgayLamViec
        {
            get { return soNgayLamViec; }
            set
            {
                if (value < 0 || value > 31)
                    throw new ArgumentException("Số ngày làm việc phải nằm trong khoảng 0 - 31.");
                soNgayLamViec = value;
            }
        }

        public NhanVienVanPhong(string maNV, string hoTen, double luongCoBan, int soNgayLamViec)
            : base(maNV, hoTen, luongCoBan)
        {
            SoNgayLamViec = soNgayLamViec;
        }

        public override double TinhLuong()
        {
            return LuongCoBan + SoNgayLamViec * PHU_CAP_NGAY;
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine(MoTaChung("Văn phòng")
                + string.Format(" | Ngày công: {0,2}", SoNgayLamViec)
                + " | Thực lãnh: " + TienTe.DinhDang(TinhLuong()).PadLeft(13));
        }
    }
}
