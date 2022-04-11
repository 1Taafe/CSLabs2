using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab2
{
    [Serializable]
    public static class BooksContainer
    {
        public static string source = @"C:\Users\dima7\source\repos\lab2\library.xml";
        public static XmlSerializer formatter = new XmlSerializer(typeof(List<Book>));
        public static List<Book> shelf = new();

        public static void ImportXML()
        {
            File.Delete(source);
            using (FileStream fs = new FileStream(source, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, shelf);
            }
        }

        public static void ExportXML()
        {
            using (FileStream fs = new FileStream(source, FileMode.OpenOrCreate))
            {
                try
                {
                    shelf = (List<Book>)formatter.Deserialize(fs);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message} \n Вероятно, Xml-документ пуст!", "Error");
                }
            }
        }
    }
    [Serializable]
    public class Book
    {
        public string? Title { get; set; }
        public string? Type { get; set; }
        public double FileSize { get; set; }
        public string? UDC { get; set; }
        public int Pages { get; set; }
        public string? Publisher { get; set; }
        public int Year { get; set; }
        public DateTime UploadTime { get; set; }
        public Author? Author { get; set; }

        public override string ToString()
        {
            return $"{Title} \n {Type} \n {FileSize} \n {UDC} \n Всего страниц: {Pages} \n Издатель: {Publisher} \n {Year} \n Автор: {Author}";
        }
    }
}
