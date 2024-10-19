using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    class Boooks
    {
        public string Name { get; set; }
        public string Author { get; set; }

        private Boooks() { }

        public Boooks(string name, string author)
        {
            Name = name;
            Author = author;
        }

        public override string ToString()
        {
            return $"Название книги: {Name}, Автор: {Author}";
        }
    }
}
