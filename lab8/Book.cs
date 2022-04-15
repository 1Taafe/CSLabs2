using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace lab67
{
    public class Book
    {
        static string source = @"C:\Users\dima7\source\repos\lab8\books.xml";
        static XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Book>));
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }

        public int Year { get; set; }
        public string? Publisher { get; set; }
        public string? Country { get; set; }
        public double Cost { get; set;}
        private int amount;
        public int Amount { 
            get { return amount; }
            set
            {
                if(value == 0)
                {
                    Availability = "Нет в наличии";
                }
                else
                {
                    Availability = "Есть в наличии";
                }
                if(value >= 0)
                {
                    amount = value;
                }
                else
                {
                    Availability = "Нет в наличии";
                    MessageBox.Show("Количество не может быть отрицательным!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public string? Availability { get; set; }
        public string? ImagePath { get; set; }

        public Book()
        {
            ID = DateTime.Now.GetHashCode();
        }

        public override string ToString()
        {
            return Title;
        }

        public static List<Book> Collection = new List<Book>();
        public static List<Book> currentCollection = new List<Book>();
        public static void Import()
        {
            using(FileStream fs = new FileStream(source, FileMode.OpenOrCreate))
            {
                try
                {
                    Collection = xmlSerializer.Deserialize(fs) as List<Book>;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n Файл пуст, добавьте книги!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }

        public static List<Book> GetListFromXML()
        {
            using (FileStream fs = new FileStream(source, FileMode.OpenOrCreate))
            {
                    List<Book> temp = new List<Book>();
                    temp = xmlSerializer.Deserialize(fs) as List<Book>;
                    return temp;   
            }
        }

        public static void Export()
        {
            File.Delete(source);
            using (FileStream fs = new FileStream(source, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, Collection);
            }
        }

        public static void Push(Book book)
        {
            Collection.Add(book);
            Export();
            MainWindow.BooksList.ItemsSource = null;
            MainWindow.BooksList.ItemsSource = Collection;
        }
    }
}
