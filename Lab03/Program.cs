using System;
using System.Collections.Generic;
using System.Globalization;

namespace Lab03_QuanLySinhVienOOP
{
    public class Program
    {
        private static readonly QuanLySinhVien QuanLy = new();

        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var chucNang = new Dictionary<string, Action>
            {
                ["1"] = ThemSinhVien,
                ["2"] = () => InDanhSach(QuanLy.LayDanhSach()),
                ["3"] = TimTheoMa,
                ["4"] = TimTheoTen,
                ["5"] = SuaDiem,
                ["6"] = XoaSinhVien,
                ["7"] = () => InDanhSach(QuanLy.SapXepTheoDiem()),
                ["8"] = () => InDanhSach(QuanLy.LocSinhVienDat()),
            };

            while (true)
            {
                InMenu();
                string chon = Console.ReadLine();

                if (chon == "0")
                {
                    Console.WriteLine("Tạm biệt!");
                    break;
                }

                if (chucNang.TryGetValue(chon ?? "", out Action hanhDong))
                    hanhDong.Invoke();
                else
                    Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại.");

                Console.WriteLine("\nNhấn Enter để tiếp tục...");
                Console.ReadLine();
            }
        }

        private static void InMenu()
        {
            Console.Clear();
            string[] dong =
            {
                "===== QUAN LY SINH VIEN =====",
                "1. Them sinh vien",
                "2. Xuat danh sach",
                "3. Tim sinh vien theo ma",
                "4. Tim sinh vien theo ten",
                "5. Sua diem trung binh",
                "6. Xoa sinh vien",
                "7. Sap xep theo diem giam dan",
                "8. Loc sinh vien dat",
                "0. Thoat",
            };
            foreach (string d in dong) Console.WriteLine(d);
            Console.Write("Chon chuc nang: ");
        }

        private static void ThemSinhVien()
        {
            string ma = DocChuoi("Nhập mã sinh viên: ");

            if (QuanLy.TimTheoMa(ma) != null)
            {
                Console.WriteLine("Mã sinh viên đã tồn tại!");
                return;
            }

            string hoTen = DocChuoi("Nhập họ tên: ");
            DateTime ngaySinh = DocNgay("Nhập ngày sinh (dd/MM/yyyy): ");
            string maLop = DocChuoi("Nhập mã lớp: ");
            double diem = DocDiem("Nhập điểm trung bình (0-10): ");

            try
            {
                bool thanhCong = QuanLy.Them(new SinhVien(ma, hoTen, ngaySinh, maLop, diem));
                Console.WriteLine(thanhCong ? "Thêm sinh viên thành công!" : "Mã sinh viên đã tồn tại!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
        }

        private static void InDanhSach(List<SinhVien> ds)
        {
            if (ds.Count == 0)
            {
                Console.WriteLine("Danh sách trống.");
                return;
            }

            Console.WriteLine(string.Format("{0,-8}{1,-25}{2,-10}{3,-8}{4,-10}", "Mã SV", "Họ tên", "Lớp", "Điểm", "Xếp loại"));
            Console.WriteLine(new string('-', 61));
            ds.ForEach(sv => Console.WriteLine(sv.LayThongTin()));
        }

        private static void TimTheoMa()
        {
            string ma = DocChuoi("Nhập mã sinh viên cần tìm: ");
            SinhVien sv = QuanLy.TimTheoMa(ma);

            if (sv == null)
                Console.WriteLine("Không tìm thấy sinh viên.");
            else
                InDanhSach(new List<SinhVien> { sv });
        }

        private static void TimTheoTen()
        {
            string tuKhoa = DocChuoi("Nhập từ khóa họ tên: ");
            InDanhSach(QuanLy.TimTheoTen(tuKhoa));
        }

        private static void SuaDiem()
        {
            string ma = DocChuoi("Nhập mã sinh viên cần sửa điểm: ");

            if (QuanLy.TimTheoMa(ma) == null)
            {
                Console.WriteLine("Không tìm thấy sinh viên.");
                return;
            }

            double diemMoi = DocDiem("Nhập điểm trung bình mới (0-10): ");

            try
            {
                QuanLy.Sua(ma, diemMoi);
                Console.WriteLine("Cập nhật điểm thành công!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
        }

        private static void XoaSinhVien()
        {
            string ma = DocChuoi("Nhập mã sinh viên cần xóa: ");
            Console.WriteLine(QuanLy.Xoa(ma) ? "Xóa thành công!" : "Không tìm thấy sinh viên.");
        }

        private static string DocChuoi(string thongBao)
        {
            Console.Write(thongBao);
            return Console.ReadLine() ?? "";
        }

        private static double DocDiem(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();

                if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double diem) && diem is >= 0 and <= 10)
                    return diem;

                Console.WriteLine("Điểm không hợp lệ, vui lòng nhập lại (0-10).");
            }
        }

        private static DateTime DocNgay(string thongBao)
        {
            string[] dinhDang = { "dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy", "d-M-yyyy" };

            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine()?.Trim();

                if (DateTime.TryParseExact(input, dinhDang, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngay))
                    return ngay;

                Console.WriteLine("Ngày sinh không hợp lệ, vui lòng nhập lại (dd/MM/yyyy).");
            }
        }
    }
}
