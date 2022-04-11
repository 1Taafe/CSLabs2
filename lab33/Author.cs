using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab2
{
    public class Author
    {
        public string? Name { get; set; }
        public string? Country { get; set; }
        public int ID { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Country}) [{ID}]";
        }
    }
    public static class AuthorControl
    {
        public static bool isFormOpened = false;
        public static List<Author> Authors = new List<Author>();
        public static string source = @"C:\Users\dima7\source\repos\lab33\authors.xml";
        public static XmlSerializer formatter = new XmlSerializer(typeof(List<Author>));
        public static void Add(Author a)
        {
            int c = 0;
            foreach(var s in Authors)
            {
                if(s.Name == a.Name)
                {
                    c++;
                }
            }
            if (c <= 0)
            {
                Authors.Add(a);
                File.Delete(source);
                using (FileStream fs = new FileStream(source, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, Authors);
                }
                MessageBox.Show("Автор успешно добавлен!", "Добавление автора");
            }
            else
            {
                MessageBox.Show("Данный автор уже существует!", "Ошибка");
            }
        }

        public static void TakeFromXML()
        {
            using (FileStream fs = new FileStream(source, FileMode.OpenOrCreate))
            {
                try
                {
                    Authors = (List<Author>)formatter.Deserialize(fs);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message} \n Вероятно, Xml-документ пуст!", "Error");
                }
            }
        }
    }
}
