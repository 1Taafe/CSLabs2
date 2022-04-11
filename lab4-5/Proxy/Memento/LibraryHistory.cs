using lab2.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Proxy.Memento
{
    public class LibraryHistory
    {
        public Stack<LibraryMemento> History { get; private set; }
        public Stack<LibraryMemento> ForwardHistory { get; private set; }
        public LibraryHistory()
        {
            History = new Stack<LibraryMemento>();
            ForwardHistory = new Stack<LibraryMemento>();
        }
    }
}
