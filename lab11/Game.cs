using System;
using System.Collections.Generic;

namespace lab11
{
    public partial class Game
    {
        public Game()
        {
            Reviews = new HashSet<Review>();
        }

        public string? GameName { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Description { get; set; }
        public string? BuyUrl { get; set; }
        public int PublisherId { get; set; }
        public int DeveloperId { get; set; }
        public string? Platform { get; set; }
        public string? Genre { get; set; }
        public int GameId { get; set; }
        public string? GameImage { get; set; }

        public virtual Developer Developer { get; set; } = null!;
        public virtual Publisher Publisher { get; set; } = null!;
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
