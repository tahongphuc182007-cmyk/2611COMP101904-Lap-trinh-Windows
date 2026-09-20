using System;

namespace QuanLyNhanVien
{
    public class NhanVien
    {
        private string maNV;
        private string hoTen;
        private double luongCoBan;

        public string MaNV
        {
            get { return maNV; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Mã nhân viên không được để trống.");
                maNV = value.Trim();
            }
        }

        public string HoTen
        {
            get { return hoTen; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Họ tên không được để trống.");
                hoTen = value.Trim();
            }
        }

        public double LuongCoBan
        {
            get { return luongCoBan; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Lương cơ bản phải lớn hơn 0.");
                luongCoBan = value;
            }
        }

        public NhanVien(string maNV, string hoTen, double luongCoBan)
        {
            MaNV = maNV;
            HoTen = hoTen;
            LuongCoBan = luongCoBan;
        }

        public virtual double TinhLuong()
        {
            return LuongCoBan;
        }

        protected string MoTaChung(string loai)
        {
            return string.Format("Mã: {0,-6} | Họ tên: {1,-20} | Loại: {2,-14} | Lương CB: {3,13}",
                                 MaNV, HoTen, loai, TienTe.DinhDang(LuongCoBan));
        }

        public virtual void HienThiThongTin()
        {
            Console.WriteLine(MoTaChung("Nhân viên") + " | Thực lãnh: " + TienTe.DinhDang(TinhLuong()).PadLeft(13));
        }
    }
}
