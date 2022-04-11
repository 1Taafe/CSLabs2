using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.AbstractFactory
{
    public interface IAuthor
    {
        string Country { get; }
        string? Name { get; set; }
    }
}
