using lab2.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Proxy
{
    public interface IContainer
    {
        void Push(IBook book);
        void Export();
        void Import();
    }
}
