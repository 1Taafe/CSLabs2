using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab2
{
    [Serializable]
    public static class BooksContainer
    {
        public static string source = @"C:\Users\dima7\source\repos\lab33\library.xml";
        public static string sourceByName = @"C:\Users\dima7\source\repos\lab33\librarySortedByName.xml";
        public static string sourceByTime = @"C:\Users\dima7\source\repos\lab33\librarySortedByTime.xml";
        public static XmlSerializer formatter = new XmlSerializer(typeof(List<Book>));
        public static List<Book> shelf = new();
        public static List<Book> shelfByName = new();
        public static List<Book> shelfByTime = new();

        public static void SortByName()
        {
            ExportXML();
            shelfByName = shelf.OrderBy(b => b.Title).ToList();
            File.Delete(sourceByName);
            using (FileStream fs = new FileStream(sourceByName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, shelfByName);
            }
        }

        public static void SortByTime()
        {
            ExportXML();
            shelfByTime = shelf.OrderByDescending(b => b.UploadTime).ToList();
            File.Delete(sourceByTime);
            using (FileStream fs = new FileStream(sourceByTime, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, shelfByTime);
            }
        }

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

    public class UDCAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is string UDC)
            {
                if (UDC.Length <= 9)    
                    return true;
                else
                    ErrorMessage = "Некорректное УДК";
            }
            return false;
        }
    }

    [Serializable]
    public class Book
    {
        [Required(ErrorMessage = "Укажите название книги!")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Укажите формат файла!")]
        public string? Type { get; set; }
        [Required(ErrorMessage = "Укажите размер файла!")]
        [Range(0, 1048576)]
        public double FileSize { get; set; }
        [UDC]
        [Required(ErrorMessage = "Укажите UDC!")]
        public string? UDC { get; set; }
        [Required(ErrorMessage = "Укажите количество страниц!")]
        public int Pages { get; set; }
        [Required(ErrorMessage = "Укажите издательство!")]
        public string? Publisher { get; set; }
        [Required(ErrorMessage = "Укажите год издания!")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Укажите время загрузки!")]
        public DateTime UploadTime { get; set; }
        [Required(ErrorMessage = "Укажите автора!")]
        public Author? Author { get; set; }

        public override string ToString()
        {
            return $"{Title} \n {Type} \n {FileSize} \n {UDC} \n Всего страниц: {Pages} \n Издатель: {Publisher} \n {Year} \n Автор: {Author}";
        }
    }
}
