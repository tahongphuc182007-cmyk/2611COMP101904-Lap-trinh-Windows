using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab04
{
    public class Repository<T> where T : IEntity
    {
        private readonly List<T> _items = new List<T>();

        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            _items.Add(item);
        }

        public bool Remove(string id)
        {
            T item = FindById(id);
            if (item == null)
                return false;
            return _items.Remove(item);
        }

        public T FindById(string id)
        {
            return _items.FirstOrDefault(x =>
                string.Equals(x.Id, id, StringComparison.OrdinalIgnoreCase));
        }

        public List<T> Find(Func<T, bool> predicate)
        {
            return _items.Where(predicate).ToList();
        }

        public List<T> GetAll()
        {
            return new List<T>(_items);
        }
    }
}
