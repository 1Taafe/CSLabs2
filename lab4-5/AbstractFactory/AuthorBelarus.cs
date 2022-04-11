using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.AbstractFactory
{
    [Serializable]
    public class AuthorBelarus : IAuthor
    {
        public string? Name { get; set; }
        public string Country => "Беларусь";

        public override string ToString()
        {
            return $"{Name} ({Country})";
        }
    }
}
