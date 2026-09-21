using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab03_QuanLySinhVienOOP
{
    public class QuanLySinhVien
    {
        private readonly List<SinhVien> _ds = new();

        public bool Them(SinhVien sv)
        {
            bool daTonTai = _ds.Any(x => x.MaSinhVien == sv.MaSinhVien);
            if (daTonTai) return false;

            _ds.Add(sv);
            return true;
        }

        public bool Sua(string ma, double diemMoi)
        {
            SinhVien sv = TimTheoMa(ma);
            if (sv is null) return false;

            sv.DiemTrungBinh = diemMoi;
            return true;
        }

        public bool Xoa(string ma)
        {
            int soLuongXoa = _ds.RemoveAll(x => x.MaSinhVien == ma);
            return soLuongXoa > 0;
        }

        public SinhVien TimTheoMa(string ma) =>
            _ds.SingleOrDefault(x => string.Equals(x.MaSinhVien, ma, StringComparison.OrdinalIgnoreCase));

        public List<SinhVien> TimTheoTen(string tuKhoa)
        {
            var ketQua = from sv in _ds
                         where sv.HoTen.ToLower().Contains(tuKhoa.ToLower())
                         select sv;
            return ketQua.ToList();
        }

        public List<SinhVien> SapXepTheoDiem() =>
            _ds.OrderByDescending(x => x.DiemTrungBinh).ThenBy(x => x.HoTen).ToList();

        public List<SinhVien> LocSinhVienDat() =>
            _ds.Where(x => x.DiemTrungBinh >= 5.0).ToList();

        public List<SinhVien> LayDanhSach() => _ds;
    }
}
