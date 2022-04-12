using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkAttempt.Classes
{
    public class Game
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? ReleaseDate { get; set; }
        public string? Description { get; set; }
        public string? BuyURL { get; set; }
        public Publisher? Publisher { get; set; }
        public Developer? Developer { get; set; }
        public string? Genre { get; set; }
        public string? Platform { get; set; }
    }
}
