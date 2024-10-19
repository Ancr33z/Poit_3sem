using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    class BooksCollection : IDictionary<int, Boooks>
    {
        private Dictionary<int, Boooks> _books;
        private int _currentIndex;

        public BooksCollection()
        {
            _books = new Dictionary<int, Boooks>();
            _currentIndex = 0;
        }

        // Реализация IDictionary
        public void Add(Boooks value)
        {
            _books.Add(_currentIndex++, value);
        }
        public void Insert(int index, Boooks value)
        {
            if (_books.ContainsKey(index))
            {
                throw new ArgumentException("Index already in use.");
            }
            _books[index] = value;
        }

        public void RemoveAt(int index)
        {
            _books.Remove(index);
        }

        public void Show()
        {
            foreach (var book in _books)
            {
                Console.WriteLine($"{book.Key}: {book.Value}");
            }
        }

        // Реализация IDictionary
        public void Add(int key, Boooks value) => _books.Add(key, value);

        public bool ContainsKey(int key) => _books.ContainsKey(key);

        public bool Remove(int key) => _books.Remove(key);

        public bool TryGetValue(int key, out Boooks value) => _books.TryGetValue(key, out value);

        public Boooks this[int key]
        {
            get => _books[key];
            set => _books[key] = value;
        }

        public ICollection<int> Keys => _books.Keys;

        public ICollection<Boooks> Values => _books.Values;

        public void Add(KeyValuePair<int, Boooks> item) => _books.Add(item.Key, item.Value);

        public void Clear() => _books.Clear();

        public bool Contains(KeyValuePair<int, Boooks> item) => _books.Contains(item);

        public void CopyTo(KeyValuePair<int, Boooks>[] array, int arrayIndex)
        {
            foreach (var item in _books)
            {
                array[arrayIndex++] = item;
            }
        }

        public bool Remove(KeyValuePair<int, Boooks> item) => _books.Remove(item.Key);

        public int Count => _books.Count;

        public bool IsReadOnly => false;

        public IEnumerator<KeyValuePair<int, Boooks>> GetEnumerator() => _books.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
