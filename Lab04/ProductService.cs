using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab04
{
    public class ProductService
    {
        private readonly Repository<Product> _repository = new Repository<Product>();

        public event Action<Product> ProductAdded;
        public event Action<Product> ProductRemoved;

        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (_repository.FindById(product.Id) != null)
                throw new DuplicateProductException(product.Id);

            _repository.Add(product);
            ProductAdded?.Invoke(product);
        }

        public void RemoveProduct(string id)
        {
            Product product = _repository.FindById(id);
            if (product == null)
                throw new ProductNotFoundException(id);

            _repository.Remove(id);
            ProductRemoved?.Invoke(product);
        }

        public List<Product> GetAll()
        {
            return _repository.GetAll();
        }

        public Product FindById(string id)
        {
            return _repository.FindById(id);
        }

        public List<Product> Search(string keyword)
        {
            Func<Product, bool> byName = p =>
                p.TenSP.IndexOf(keyword ?? "", StringComparison.OrdinalIgnoreCase) >= 0;
            return _repository.Find(byName);
        }

        public List<Product> Filter(decimal minPrice, decimal maxPrice)
        {
            Func<Product, bool> byPriceRange = p => p.Price >= minPrice && p.Price <= maxPrice;
            return _repository.Find(byPriceRange);
        }

        public decimal GetTotalValue()
        {
            return _repository.GetAll().Sum(p => p.Price * p.Quantity);
        }
    }
}
