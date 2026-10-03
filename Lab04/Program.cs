using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            ProductService service = new ProductService();
            service.ProductAdded += p => Console.WriteLine($"[EVENT] Da them san pham: {p.TenSP} ({p.MaSP})");
            service.ProductRemoved += p => Console.WriteLine($"[EVENT] Da xoa san pham: {p.TenSP} ({p.MaSP})");

            bool running = true;
            while (running)
            {
                ShowMenu();
                string choice = Console.ReadLine()?.Trim();

                try
                {
                    switch (choice)
                    {
                        case "1": HandleAdd(service); break;
                        case "2": HandleShowAll(service); break;
                        case "3": HandleFindById(service); break;
                        case "4": HandleSearchByName(service); break;
                        case "5": HandleFilterByPrice(service); break;
                        case "6": HandleRemove(service); break;
                        case "7": Console.WriteLine($"Tong gia tri kho: {service.GetTotalValue():N0}"); break;
                        case "0": running = false; Console.WriteLine("Tam biet!"); break;
                        default: Console.WriteLine("Lua chon khong hop le."); break;
                    }
                }
                catch (DuplicateProductException ex)
                {
                    Console.WriteLine("Loi: " + ex.Message);
                }
                catch (ProductNotFoundException ex)
                {
                    Console.WriteLine("Loi: " + ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Du lieu khong hop le: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Loi khong xac dinh: " + ex.Message);
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== PRODUCT MANAGER =====");
            Console.WriteLine("1. Them san pham");
            Console.WriteLine("2. Xuat danh sach");
            Console.WriteLine("3. Tim theo ma");
            Console.WriteLine("4. Tim theo ten");
            Console.WriteLine("5. Loc theo khoang gia");
            Console.WriteLine("6. Xoa san pham");
            Console.WriteLine("7. Tinh tong gia tri kho");
            Console.WriteLine("0. Thoat");
            Console.Write("Chon: ");
        }

        static void HandleAdd(ProductService service)
        {
            string id = ReadString("Nhap ma: ");
            string name = ReadString("Nhap ten: ");
            decimal price = ReadDecimal("Nhap don gia: ");
            int quantity = ReadInt("Nhap so luong: ");

            service.AddProduct(new Product(id, name, price, quantity));
        }

        static void HandleShowAll(ProductService service)
        {
            PrintList(service.GetAll(), "Danh sach san pham rong.");
        }

        static void HandleFindById(ProductService service)
        {
            string id = ReadString("Nhap ma can tim: ");
            Product product = service.FindById(id);
            Console.WriteLine(product != null ? product.ToString() : "Khong tim thay san pham.");
        }

        static void HandleSearchByName(ProductService service)
        {
            string keyword = ReadString("Nhap tu khoa: ");
            PrintList(service.Search(keyword), "Khong co san pham nao phu hop.");
        }

        static void HandleFilterByPrice(ProductService service)
        {
            decimal min = ReadDecimal("Nhap gia nho nhat: ");
            decimal max = ReadDecimal("Nhap gia lon nhat: ");
            if (min > max)
            {
                Console.WriteLine("Gia nho nhat phai nho hon hoac bang gia lon nhat.");
                return;
            }
            PrintList(service.Filter(min, max), "Khong co san pham nao trong khoang gia nay.");
        }

        static void HandleRemove(ProductService service)
        {
            string id = ReadString("Nhap ma can xoa: ");
            service.RemoveProduct(id);
        }

        static void PrintList(List<Product> products, string emptyMessage)
        {
            if (products.Count == 0)
            {
                Console.WriteLine(emptyMessage);
                return;
            }
            foreach (Product p in products)
                Console.WriteLine(p);
        }

        static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? "";
        }

        static decimal ReadDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out decimal value))
                    return value;
                Console.WriteLine("Vui long nhap mot so hop le.");
            }
        }

        static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value))
                    return value;
                Console.WriteLine("Vui long nhap mot so nguyen hop le.");
            }
        }
    }
}
