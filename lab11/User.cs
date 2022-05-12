using System;
using System.Collections.Generic;

namespace lab11
{
    public partial class User
    {
        public User()
        {
            Reviews = new HashSet<Review>();
        }

        public int UserId { get; set; }
        public string Nickname { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public bool IsAdmin { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
