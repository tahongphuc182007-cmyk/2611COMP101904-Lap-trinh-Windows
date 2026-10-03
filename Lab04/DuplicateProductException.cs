using System;

namespace Lab04
{
    public class DuplicateProductException : Exception
    {
        public string ProductId { get; }

        public DuplicateProductException(string productId)
            : base($"San pham co ma '{productId}' da ton tai.")
        {
            ProductId = productId;
        }
    }
}
