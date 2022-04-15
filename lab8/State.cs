using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab67
{
    public static class State
    {
        public static Stack<List<Book>> undoStack = new Stack<List<Book>>();
        public static Stack<List<Book>> redoStack = new Stack<List<Book>>();
    }
}
