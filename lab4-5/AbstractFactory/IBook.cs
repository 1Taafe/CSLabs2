using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.AbstractFactory
{
    public interface IBook
    {
        public string? Title { get; set; }
        string Type { get; }
        public double FileSize { get; set; }
        public string? UDC { get; set; }
        public int Pages { get; set; }
        public string? Publisher { get; set; }
        public int Year { get; set; }
        public DateTime UploadTime { get; set; }
        public IAuthor? Author { get; set; }

    }
}
