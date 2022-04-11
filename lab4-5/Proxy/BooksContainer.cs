using lab2.AbstractFactory;
using lab2.Proxy;
using lab2.Proxy.Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab2
{
    //Originator
    [Serializable]
    public class BooksContainer : IContainer
    {
        public static string source = @"C:\Users\dima7\source\repos\lab4\library.data";
        public static BinaryFormatter formatter = new BinaryFormatter();
        public List<IBook> shelf = new();
        
        public void Push(IBook book)
        {
            shelf.Add(book);
            this.Export();
        }

        public void Export()
        {
            File.Delete(source);
            using (FileStream fs = new FileStream(source, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, shelf);
            }
        }

        public void Import()
        {
            using (FileStream fs = new FileStream(source, FileMode.OpenOrCreate))
            {
                try
                {
                    shelf = (List<IBook>)formatter.Deserialize(fs);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message} \n Вероятно, Библиотека пуста! Загрузите новые книги!", "Error");
                }
            }

        }

 
    }
}
