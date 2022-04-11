using lab2.AbstractFactory;
using lab2.Proxy.Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Proxy
{
    public class ProxyContainer
    {
        private BooksContainer BookCollection = new BooksContainer();
        public void Push(IBook book)
        {
            BookCollection.shelf.Add(book);
            this.Export();
        }

        public void Export()
        {
            File.Delete(BooksContainer.source);
            using (FileStream fs = new FileStream(BooksContainer.source, FileMode.OpenOrCreate))
            {
                BooksContainer.formatter.Serialize(fs, BookCollection.shelf);
            }
        }

        public void Import()
        {
            using (FileStream fs = new FileStream(BooksContainer.source, FileMode.OpenOrCreate))
            {
                try
                {
                    BookCollection.shelf = (List<IBook>)BooksContainer.formatter.Deserialize(fs);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message} \n Вероятно, Библиотека пуста! Загрузите новые книги!", "Error");
                }
            }
        }

        public LibraryMemento SaveState()
        {
            List<IBook> temp = new();
            foreach(var b in BookCollection.shelf)
            {
                temp.Add(b);
            }
            return new LibraryMemento(temp);
        }

        public void RestoreState(LibraryMemento memento)
        {
            BookCollection.shelf.Clear();
            foreach(var b in memento.shelf)
            {
                BookCollection.shelf.Add(b);
            }
        }

        public List<IBook> Get()
        {
            return BookCollection.shelf;
        }
    }
}
