using System;

namespace QuanLyNhanVien
{
    public class NhanVienKinhDoanh : NhanVien
    {
        public const double TI_LE_HOA_HONG = 0.05;

        private double doanhSo;

        public double DoanhSo
        {
            get { return doanhSo; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Doanh số không được âm.");
                doanhSo = value;
            }
        }

        public NhanVienKinhDoanh(string maNV, string hoTen, double luongCoBan, double doanhSo)
            : base(maNV, hoTen, luongCoBan)
        {
            DoanhSo = doanhSo;
        }

        public override double TinhLuong()
        {
            return LuongCoBan + TI_LE_HOA_HONG * DoanhSo;
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine(MoTaChung("Kinh doanh")
                + " | Doanh số: " + TienTe.DinhDang(DoanhSo).PadLeft(13)
                + " | Thực lãnh: " + TienTe.DinhDang(TinhLuong()).PadLeft(13));
        }
    }
}
