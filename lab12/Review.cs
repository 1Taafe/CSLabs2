using System;
using System.Collections.Generic;

namespace lab11
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public string Text { get; set; } = null!;
        public DateTime UploadDate { get; set; }
        public byte Rating { get; set; }

        public virtual Game Game { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
