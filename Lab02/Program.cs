using System;

namespace Lab02_QuanLyMang
{
    internal class Program
    {
        // Mảng số nguyên được quản lý xuyên suốt chương trình.
        // Bằng null nghĩa là người dùng chưa nhập mảng.
        static int[] mang = null;

        static void Main(string[] args)
        {
            int luaChon;

            do
            {
                HienThiMenu();
                luaChon = NhapLuaChonMenu();
                XuLyLuaChon(luaChon);
            } while (luaChon != 0);

            Console.WriteLine("\nCam on ban da su dung chuong trinh. Tam biet!");
        }

        /// <summary>
        /// In menu chức năng ra màn hình theo đúng mẫu đề bài.
        /// </summary>
        static void HienThiMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== MENU =====");
            Console.WriteLine("1. Nhap mang");
            Console.WriteLine("2. Xuat mang");
            Console.WriteLine("3. Tinh tong");
            Console.WriteLine("4. Tim max/min");
            Console.WriteLine("5. Dem chan/le");
            Console.WriteLine("6. Sap xep tang dan");
            Console.WriteLine("7. Tim kiem");
            Console.WriteLine("0. Thoat");
            Console.Write("Chon chuc nang: ");
        }

        /// <summary>
        /// Đọc lựa chọn menu từ người dùng, chỉ chấp nhận số nguyên trong khoảng 0-7.
        /// Nhập sai (chữ, số ngoài khoảng...) sẽ được yêu cầu nhập lại, không làm crash chương trình.
        /// </summary>
        static int NhapLuaChonMenu()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out int luaChon) && luaChon >= 0 && luaChon <= 7)
                {
                    return luaChon;
                }

                Console.Write("Lua chon khong hop le. Vui long nhap lai (0-7): ");
            }
        }

        /// <summary>
        /// Điều hướng và thực hiện chức năng tương ứng với lựa chọn của người dùng.
        /// </summary>
        static void XuLyLuaChon(int luaChon)
        {
            switch (luaChon)
            {
                case 1:
                    mang = NhapMang();
                    Console.WriteLine("Nhap mang thanh cong!");
                    break;

                case 2:
                    if (KiemTraDaNhapMang())
                    {
                        Console.Write("Mang hien tai: ");
                        XuatMang(mang);
                    }
                    break;

                case 3:
                    if (KiemTraDaNhapMang())
                    {
                        Console.WriteLine($"Tong cac phan tu: {TinhTong(mang)}");
                    }
                    break;

                case 4:
                    if (KiemTraDaNhapMang())
                    {
                        Console.WriteLine($"Gia tri lon nhat: {TimMax(mang)}");
                        Console.WriteLine($"Gia tri nho nhat: {TimMin(mang)}");
                    }
                    break;

                case 5:
                    if (KiemTraDaNhapMang())
                    {
                        Console.WriteLine($"So luong phan tu chan: {DemChan(mang)}");
                        Console.WriteLine($"So luong phan tu le: {DemLe(mang)}");
                    }
                    break;

                case 6:
                    if (KiemTraDaNhapMang())
                    {
                        SapXepTangDan(mang);
                        Console.Write("Mang sau khi sap xep tang dan: ");
                        XuatMang(mang);
                    }
                    break;

                case 7:
                    if (KiemTraDaNhapMang())
                    {
                        int x = NhapSoNguyen("Nhap gia tri can tim x: ");
                        int viTri = TimKiem(mang, x);

                        if (viTri != -1)
                        {
                            Console.WriteLine($"Tim thay {x} tai vi tri {viTri} (tinh tu 0).");
                        }
                        else
                        {
                            Console.WriteLine($"Khong tim thay {x} trong mang.");
                        }
                    }
                    break;

                case 0:
                    // Khong lam gi them, vong lap trong Main se ket thuc
                    break;
            }
        }

        /// <summary>
        /// Kiểm tra xem người dùng đã nhập mảng hay chưa (chức năng 1).
        /// Nếu chưa, in thông báo và trả về false để chặn các chức năng còn lại.
        /// </summary>
        static bool KiemTraDaNhapMang()
        {
            if (mang == null)
            {
                Console.WriteLine("Ban chua nhap mang. Vui long chon chuc nang 1 truoc.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Đọc một số nguyên bất kỳ (có thể âm) từ người dùng, lặp lại đến khi nhập đúng định dạng.
        /// </summary>
        static int NhapSoNguyen(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (int.TryParse(input, out int soNguyen))
                {
                    return soNguyen;
                }

                Console.WriteLine("Gia tri khong hop le. Vui long nhap mot so nguyen.");
            }
        }

        /// <summary>
        /// Đọc một số nguyên dương (lớn hơn 0) từ người dùng, lặp lại đến khi hợp lệ.
        /// Dùng cho việc nhập số lượng phần tử n của mảng.
        /// </summary>
        static int NhapSoNguyenDuong(string message)
        {
            while (true)
            {
                int soNguyen = NhapSoNguyen(message);

                if (soNguyen > 0)
                {
                    return soNguyen;
                }

                Console.WriteLine("So luong phan tu phai la so nguyen duong. Vui long nhap lai.");
            }
        }

        /// <summary>
        /// Nhập số lượng phần tử n (số nguyên dương) và lần lượt n phần tử của mảng.
        /// </summary>
        static int[] NhapMang()
        {
            int n = NhapSoNguyenDuong("Nhap so luong phan tu n: ");
            int[] a = new int[n];

            for (int i = 0; i < n; i++)
            {
                a[i] = NhapSoNguyen($"Nhap phan tu thu {i}: ");
            }

            return a;
        }

        /// <summary>
        /// In toàn bộ phần tử của mảng ra màn hình, cách nhau bởi khoảng trắng.
        /// </summary>
        static void XuatMang(int[] a)
        {
            Console.WriteLine(string.Join(" ", a));
        }

        /// <summary>
        /// Tính tổng tất cả các phần tử trong mảng.
        /// </summary>
        static int TinhTong(int[] a)
        {
            int tong = 0;
            foreach (int giaTri in a)
            {
                tong += giaTri;
            }
            return tong;
        }

        /// <summary>
        /// Tìm giá trị lớn nhất trong mảng.
        /// </summary>
        static int TimMax(int[] a)
        {
            int max = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > max)
                {
                    max = a[i];
                }
            }
            return max;
        }

        /// <summary>
        /// Tìm giá trị nhỏ nhất trong mảng.
        /// </summary>
        static int TimMin(int[] a)
        {
            int min = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] < min)
                {
                    min = a[i];
                }
            }
            return min;
        }

        /// <summary>
        /// Đếm số lượng phần tử chẵn trong mảng.
        /// </summary>
        static int DemChan(int[] a)
        {
            int demChan = 0;
            foreach (int giaTri in a)
            {
                if (giaTri % 2 == 0)
                {
                    demChan++;
                }
            }
            return demChan;
        }

        /// <summary>
        /// Đếm số lượng phần tử lẻ trong mảng.
        /// </summary>
        static int DemLe(int[] a)
        {
            int demLe = 0;
            foreach (int giaTri in a)
            {
                if (giaTri % 2 != 0)
                {
                    demLe++;
                }
            }
            return demLe;
        }

        /// <summary>
        /// Sắp xếp mảng theo thứ tự tăng dần tại chỗ (thuật toán Bubble Sort).
        /// </summary>
        static void SapXepTangDan(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = 0; j < a.Length - 1 - i; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        int tam = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = tam;
                    }
                }
            }
        }

        /// <summary>
        /// Tìm kiếm tuần tự giá trị x trong mảng.
        /// Trả về vị trí xuất hiện đầu tiên (tính từ 0), hoặc -1 nếu không tìm thấy.
        /// </summary>
        static int TimKiem(int[] a, int x)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == x)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
