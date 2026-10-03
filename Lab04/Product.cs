using System;

namespace Lab04
{
    public class Product : IEntity
    {
        private string _maSP;
        private string _tenSP;
        private decimal _price;
        private int _quantity;

        public string Id => MaSP;

        public string MaSP
        {
            get => _maSP;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Ma san pham khong duoc rong.");
                _maSP = value.Trim();
            }
        }

        public string TenSP
        {
            get => _tenSP;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Ten san pham khong duoc rong.");
                _tenSP = value.Trim();
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Don gia khong duoc am.");
                _price = value;
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value < 0)
                    throw new ArgumentException("So luong khong duoc am.");
                _quantity = value;
            }
        }

        public Product(string maSP, string tenSP, decimal price, int quantity)
        {
            MaSP = maSP;
            TenSP = tenSP;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"Ma: {MaSP} | Ten: {TenSP} | Gia: {Price:N0} | SL: {Quantity}";
        }
    }
}
