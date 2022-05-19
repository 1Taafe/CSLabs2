using System;
using System.Collections.Generic;

namespace lab11
{
    public partial class Publisher
    {
        public Publisher()
        {
            Games = new HashSet<Game>();
        }

        public string? PublisherName { get; set; }
        public string? PublisherCountry { get; set; }
        public int PublisherId { get; set; }

        public override string ToString()
        {
            return PublisherName;
        }

        public virtual ICollection<Game> Games { get; set; }
    }
}
