using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyNhanVien
{
    class Program
    {
        const int SO_NV_TOI_THIEU = 5;

        static List<NhanVien> danhSach = new List<NhanVien>();

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            NhapDanhSach();

            int chon;
            do
            {
                HienThiMenu();
                chon = DocInt("Chọn chức năng: ", 0, 4);

                switch (chon)
                {
                    case 1: XuatDanhSach(); break;
                    case 2: TimTheoMa(); break;
                    case 3: TimLuongCaoNhat(); break;
                    case 4: TinhTongLuong(); break;
                    case 0: Console.WriteLine("\nKết thúc chương trình."); break;
                }
            } while (chon != 0);
        }

        static void HienThiMenu()
        {
            Console.WriteLine("\n========== MENU ==========");
            Console.WriteLine("1. Xuất danh sách nhân viên");
            Console.WriteLine("2. Tìm nhân viên theo mã");
            Console.WriteLine("3. Tìm nhân viên có lương cao nhất");
            Console.WriteLine("4. Tính tổng lương công ty phải trả");
            Console.WriteLine("0. Thoát");
            Console.WriteLine("==========================");
        }

        // ================= CÁC CHỨC NĂNG (dùng đa hình, không kiểm tra kiểu) =================

        static void XuatDanhSach()
        {
            Console.WriteLine("\n----- DANH SÁCH NHÂN VIÊN -----");
            foreach (NhanVien nv in danhSach)
            {
                nv.HienThiThongTin();
            }
        }

        static void TimTheoMa()
        {
            Console.Write("\nNhập mã cần tìm: ");
            string ma = (Console.ReadLine() ?? "").Trim();

            NhanVien ketQua = null;
            foreach (NhanVien nv in danhSach)
            {
                if (string.Equals(nv.MaNV, ma, StringComparison.OrdinalIgnoreCase))
                {
                    ketQua = nv;
                    break;
                }
            }

            if (ketQua == null)
                Console.WriteLine("Không tìm thấy nhân viên có mã " + ma + ".");
            else
                ketQua.HienThiThongTin();
        }

        static void TimLuongCaoNhat()
        {
            NhanVien cao = danhSach[0];
            foreach (NhanVien nv in danhSach)
            {
                if (nv.TinhLuong() > cao.TinhLuong())
                    cao = nv;
            }

            Console.WriteLine("\n----- NHÂN VIÊN CÓ LƯƠNG CAO NHẤT -----");
            cao.HienThiThongTin();
        }

        static void TinhTongLuong()
        {
            double tong = 0;
            foreach (NhanVien nv in danhSach)
            {
                tong += nv.TinhLuong();
            }

            Console.WriteLine("\nTổng lương công ty phải trả: " + TienTe.DinhDang(tong));
        }

        // ================= NHẬP LIỆU =================

        static void NhapDanhSach()
        {
            Console.WriteLine("===== NHẬP DANH SÁCH NHÂN VIÊN =====");
            int n = DocInt("Số nhân viên cần nhập (>= " + SO_NV_TOI_THIEU + "): ", SO_NV_TOI_THIEU, 100);

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("\n--- Nhân viên thứ " + i + " ---");
                Console.WriteLine("1. Văn phòng   2. Kinh doanh   3. Thời vụ");
                int loai = DocInt("Chọn loại: ", 1, 3);

                string ma = DocChuoi("Mã nhân viên: ");
                string ten = DocChuoi("Họ tên: ");
                double luongCB = DocDouble("Lương cơ bản: ", 0.01, double.MaxValue);

                if (loai == 1)
                {
                    int ngay = DocInt("Số ngày làm việc (0-31): ", 0, 31);
                    danhSach.Add(new NhanVienVanPhong(ma, ten, luongCB, ngay));
                }
                else if (loai == 2)
                {
                    double ds = DocDouble("Doanh số: ", 0, double.MaxValue);
                    danhSach.Add(new NhanVienKinhDoanh(ma, ten, luongCB, ds));
                }
                else
                {
                    double gio = DocDouble("Số giờ làm: ", 0, double.MaxValue);
                    double luongGio = DocDouble("Lương theo giờ: ", 0.01, double.MaxValue);
                    danhSach.Add(new NhanVienThoiVu(ma, ten, luongCB, gio, luongGio));
                }
            }
        }

        static string DocChuoi(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string s = (Console.ReadLine() ?? "").Trim();
                if (s.Length > 0) return s;
                Console.WriteLine("Giá trị không được để trống, nhập lại.");
            }
        }

        static int DocInt(string thongBao, int min, int max)
        {
            while (true)
            {
                Console.Write(thongBao);
                int v;
                if (int.TryParse(Console.ReadLine(), out v) && v >= min && v <= max)
                    return v;
                Console.WriteLine("Giá trị phải là số nguyên trong [" + min + ", " + max + "], nhập lại.");
            }
        }

        static double DocDouble(string thongBao, double min, double max)
        {
            while (true)
            {
                Console.Write(thongBao);
                double v;
                if (double.TryParse(Console.ReadLine(), out v) && v >= min && v <= max)
                    return v;
                Console.WriteLine("Giá trị không hợp lệ, nhập lại.");
            }
        }
    }
}
