using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace lab2.AbstractFactory
{
    [Serializable]
    public class BookMobile : IBook
    {
        public string? Title { get; set; }
        public string Type => "epub";
        public double FileSize { get; set; }
        public string? UDC { get; set; }
        public int Pages { get; set; }
        public string? Publisher { get; set; }
        public int Year { get; set; }
        public DateTime UploadTime { get; set; }
        public IAuthor? Author { get; set; }

        public object DeepCopy()
        {
            object book = null;
            using (MemoryStream tempStream = new MemoryStream())
            {
                BinaryFormatter binFormatter = new BinaryFormatter(null,
                    new StreamingContext(StreamingContextStates.Clone));

                binFormatter.Serialize(tempStream, this);
                tempStream.Seek(0, SeekOrigin.Begin);

                book = binFormatter.Deserialize(tempStream);
            }
            return book;
        }

        public override string ToString()
        {
            return $"{Title} \n {Type} \n {FileSize} \n {UDC} \n Всего страниц: {Pages} \n Издатель: {Publisher} \n {Year} \n Автор: {Author}";
        }
    }
}
