using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    public interface IGeneralized<T>
    {
        void AddItem(T item);
        void DeleteItem(T item);
        void Show();
    }
}
