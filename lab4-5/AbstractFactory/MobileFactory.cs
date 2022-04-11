using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.AbstractFactory
{
    public class MobileFactory : IFactory
    {
        public IAuthor CreateAuthor()
        {
            return new AuthorBelarus();
        }

        public IBook CreateBook()
        {
            return new BookMobile();
        }
    }
}
