using System.Globalization;

namespace QuanLyNhanVien
{
    public static class TienTe
    {
        public static string DinhDang(double tien)
        {
            return tien.ToString("#,##0", CultureInfo.InvariantCulture).Replace(',', '.') + " đ";
        }
    }
}
