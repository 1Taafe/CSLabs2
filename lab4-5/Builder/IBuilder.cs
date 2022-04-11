using lab2.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Builder
{
    public interface IBuilder
    {
        IBuilder BuildFirstBook(IBook book);
        IBuilder BuildSecondBook(IBook book);
        List<IBook> GetResult();
    }
}
