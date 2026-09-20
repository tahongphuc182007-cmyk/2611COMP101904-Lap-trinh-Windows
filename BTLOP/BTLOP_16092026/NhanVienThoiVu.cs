using System;

namespace QuanLyNhanVien
{
    public class NhanVienThoiVu : NhanVien
    {
        private double soGioLam;
        private double luongTheoGio;

        public double SoGioLam
        {
            get { return soGioLam; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Số giờ làm không được âm.");
                soGioLam = value;
            }
        }

        public double LuongTheoGio
        {
            get { return luongTheoGio; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Lương theo giờ phải lớn hơn 0.");
                luongTheoGio = value;
            }
        }

        public NhanVienThoiVu(string maNV, string hoTen, double luongCoBan, double soGioLam, double luongTheoGio)
            : base(maNV, hoTen, luongCoBan)
        {
            SoGioLam = soGioLam;
            LuongTheoGio = luongTheoGio;
        }

        public override double TinhLuong()
        {
            return SoGioLam * LuongTheoGio;
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine(MoTaChung("Thời vụ")
                + string.Format(" | Giờ làm: {0,5} x {1}", SoGioLam, TienTe.DinhDang(LuongTheoGio))
                + " | Thực lãnh: " + TienTe.DinhDang(TinhLuong()).PadLeft(13));
        }
    }
}
