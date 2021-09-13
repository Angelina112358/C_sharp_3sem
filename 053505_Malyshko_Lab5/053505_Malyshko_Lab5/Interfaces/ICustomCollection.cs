using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053505_Malyshko_Lab5.Interfaces
{
    public interface ICustomCollection<T>
    {
        void Add(T item);
        void Remove(T item);
        int Count { get; }
        T this[int index] { get;set; }
        void PrintItems();
        bool Contains(T item);
        T Current();
        void Next();
        void Reset();
        T RemoveCurrent();
    }
}
