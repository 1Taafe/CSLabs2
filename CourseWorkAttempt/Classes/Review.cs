using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkAttempt.Classes
{
    public class Review
    {
        public int ID { get; set; }
        public User? User { get; set; }
        public Game? Game { get; set; }
        public string? Text { get; set; }

        public DateTime UploadDate { get; set; }

        public int Rate { get; set; }
    }
}
