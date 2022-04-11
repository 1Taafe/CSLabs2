using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.AbstractFactory
{
    public class DesktopFactory : IFactory
    {
        public IAuthor CreateAuthor()
        {
            return new AuthorOther();
        }

        public IBook CreateBook()
        {
            return new BookDesktop();
        }
    }
}
