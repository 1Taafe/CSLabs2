using System;
using System.Collections.Generic;

namespace lab11
{
    public partial class Developer
    {
        public Developer()
        {
            Games = new HashSet<Game>();
        }

        public string? DeveloperName { get; set; }
        public string? DeveloperCountry { get; set; }
        public int DeveloperId { get; set; }

        public override string ToString()
        {
            return DeveloperName;
        }

        public virtual ICollection<Game> Games { get; set; }
    }
}
