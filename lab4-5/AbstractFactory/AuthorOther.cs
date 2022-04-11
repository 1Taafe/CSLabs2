using lab2.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab2
{
    [Serializable]
    public class AuthorOther : IAuthor 
    {
        public string? Name { get; set; }
        public string Country => "Другая страна";

        public override string ToString()
        {
            return $"{Name} ({Country})";
        }
    }

}
