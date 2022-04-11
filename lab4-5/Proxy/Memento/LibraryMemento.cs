using lab2.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Proxy.Memento
{
    public class LibraryMemento
    {
        public List<IBook> shelf { get; private set; }

        public LibraryMemento(List<IBook> newShelf)
        {
            shelf = newShelf;
        }
    }
}
