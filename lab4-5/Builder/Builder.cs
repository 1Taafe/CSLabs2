using lab2.AbstractFactory;
using lab2.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class KitBuilder : IBuilder
    {
        private List<IBook> kit = new List<IBook> ();
        public IBuilder BuildFirstBook(IBook first)
        {
            kit.Add (first);
            return this;
        }
        public IBuilder BuildSecondBook(IBook second)
        {
            kit.Add(second);
            return this;
        }
        public List<IBook> GetResult()
        {
            return kit;
        }
    }
}
