using lab2.AbstractFactory;
using lab2.Proxy;
using lab2.Proxy.Memento;
using System.Xml.Serialization;

namespace lab2
{
    public partial class Library : Form
    {
        LibraryHistory lib = new LibraryHistory();
        public Library()
        {
            InitializeComponent();
        }

        private ProxyContainer BookCollection = new ProxyContainer();

        private Info Info { get; set; }
        private void getInfo()
        {
            Info = Info.getInstance(this.Name, this.BackColor.ToString(), this.Font.ToString());
        }

        private void AddBookButton_Click(object sender, EventArgs e)
        {
            try
            {
                MobileFactory mf = new MobileFactory();
                DesktopFactory df = new DesktopFactory();

                if (FormatPicker.Text.Length < 1)
                {
                    throw new Exception("Формат файла не выбран!");
                }
                else if (FormatPicker.Text == "epub")
                {
                    var newBook = mf.CreateBook();
                    if (TitleField.Text.Length < 1)
                    {
                        throw new Exception("Название книги не введено!");
                    }
                    else
                    {
                        newBook.Title = TitleField.Text;
                    }
                    if (SizeFormatField.Text.Length < 1)
                    {
                        throw new Exception("Формат размера файла не выбран!");
                    }
                    else if (SizeFormatField.Text == "MB")
                    {
                        newBook.FileSize = Convert.ToDouble(SizeField.Text) * 1024;
                    }
                    else
                    {
                        newBook.FileSize = Convert.ToDouble(SizeField.Text);
                    }

                    if (UDCField.Text.Length < 1)
                    {
                        throw new Exception("Введите УДК!");
                    }
                    else
                    {
                        newBook.UDC = UDCField.Text;
                    }

                    if (PublisherField.Text.Length < 1)
                    {
                        throw new Exception("Введите название издательства!");
                    }
                    else
                    {
                        newBook.Publisher = PublisherField.Text;
                    }

                    newBook.Pages = (int)PagesField.Value;
                    newBook.Year = (int)YearField.Value;
                    newBook.UploadTime = UploadTimePicker.Value;

                    if (NameField.Text.Length < 1 || CountryField.Text.Length < 1)
                    {
                        throw new Exception("Введите имя автора и страну!");
                    }
                    else
                    {
                        if (CountryField.Text == "Беларусь")
                        {
                            var author = mf.CreateAuthor();
                            author.Name = NameField.Text;
                            newBook.Author = author;
                        }
                        else
                        {
                            var author = df.CreateAuthor();
                            author.Name = NameField.Text;
                            newBook.Author = author;
                        }
                    }

                    MessageBox.Show(newBook.ToString(), "Книга добавлена");
                    BookCollection.Push(newBook);
                    //BooksContainer.ImportXML();
                }
                else if (FormatPicker.Text == "pdf")
                {
                    var newBook = df.CreateBook();
                    if (TitleField.Text.Length < 1)
                    {
                        throw new Exception("Название книги не введено!");
                    }
                    else
                    {
                        newBook.Title = TitleField.Text;
                    }
                    if (SizeFormatField.Text.Length < 1)
                    {
                        throw new Exception("Формат размера файла не выбран!");
                    }
                    else if (SizeFormatField.Text == "MB")
                    {
                        newBook.FileSize = Convert.ToDouble(SizeField.Text) * 1024;
                    }
                    else
                    {
                        newBook.FileSize = Convert.ToDouble(SizeField.Text);
                    }

                    if (UDCField.Text.Length < 1)
                    {
                        throw new Exception("Введите УДК!");
                    }
                    else
                    {
                        newBook.UDC = UDCField.Text;
                    }

                    if (PublisherField.Text.Length < 1)
                    {
                        throw new Exception("Введите название издательства!");
                    }
                    else
                    {
                        newBook.Publisher = PublisherField.Text;
                    }

                    newBook.Pages = (int)PagesField.Value;
                    newBook.Year = (int)YearField.Value;
                    newBook.UploadTime = UploadTimePicker.Value;

                    if (NameField.Text.Length < 1 || CountryField.Text.Length < 1)
                    {
                        throw new Exception("Введите имя автора и страну!");
                    }
                    else
                    {
                        if (CountryField.Text == "Беларусь")
                        {
                            var author = mf.CreateAuthor();
                            author.Name = NameField.Text;
                            newBook.Author = author;
                        }
                        else
                        {
                            var author = df.CreateAuthor();
                            author.Name = NameField.Text;
                            newBook.Author = author;
                        }
                    }

                    MessageBox.Show(newBook.ToString(), "Книга добавлена");
                    BookCollection.Push(newBook);
                    lib.History.Push(BookCollection.SaveState());
                    //BooksContainer.ImportXML();
                }


            }
            catch (FormatException ex)
            {
                MessageBox.Show($"{ex.Message} \n Размер файла указан в неверном формате!", "Ошибка");
            }
            catch (Exception exc)
            {
                MessageBox.Show($"{exc.Message}", "Ошибка");
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            //BooksContainer.ExportXML();
            BooksTable.Rows.Clear();
            foreach (var b in BookCollection.Get())
            {
                BooksTable.Rows.Add(b.Title, b.Type, b.FileSize, b.UDC, b.Pages, b.Publisher, b.Year, b.UploadTime, b.Author);
            }
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            getInfo();
            MessageBox.Show($"Название формы: {Info.AppName} \n Цвет: {Info.BackColor} \n Шрифт: {Info.Font}");
        }

        private void CloneButton_Click(object sender, EventArgs e)
        {
            if (BookCollection.Get().Count > 0)
            {
                var lastBook = BookCollection.Get().Last();
                if (lastBook.Type == "pdf")
                {
                    var book = lastBook as BookDesktop;
                    var clonedBook = book.DeepCopy() as BookDesktop;
                    MessageBox.Show(clonedBook.ToString(), "Клонирование книги");
                    BookCollection.Push(clonedBook);
                    lib.History.Push(BookCollection.SaveState());
                }
                else
                {
                    var book = lastBook as BookMobile;
                    var clonedBook = book.DeepCopy() as BookMobile;
                    MessageBox.Show(clonedBook.ToString(), "Клонирование книги");
                    BookCollection.Push(clonedBook);
                    lib.History.Push(BookCollection.SaveState());
                }
                BooksTable.Rows.Clear();
                foreach (var b in BookCollection.Get())
                {
                    BooksTable.Rows.Add(b.Title, b.Type, b.FileSize, b.UDC, b.Pages, b.Publisher, b.Year, b.UploadTime, b.Author);
                }
            }
            else
            {
                MessageBox.Show("Коллекция пуста");
            }
        }

        private void BuilderButton_Click(object sender, EventArgs e)
        {
            if (BookCollection.Get().Count() >= 2)
            {
                KitBuilder newKit = new KitBuilder();
                var books = BookCollection.Get().TakeLast(2);
                IBook[] newBooks = books.ToArray();
                newKit.BuildFirstBook(newBooks[0]);
                newKit.BuildSecondBook(newBooks[1]);
                var result = newKit.GetResult();
                foreach (var s in result)
                {
                    MessageBox.Show(s.ToString());
                }
            }
            else
            {
                MessageBox.Show("Книг не найдено!");
            }

        }

        private void Library_Load(object sender, EventArgs e)
        {
            BookCollection.Import();
            lib.History.Push(BookCollection.SaveState());
        }

        private void BackwardButton_Click(object sender, EventArgs e)
        {
            if(lib.History.Count <= 1)
            {
                BookCollection.RestoreState(lib.History.Peek());
                BooksTable.Rows.Clear();
                foreach (var b in BookCollection.Get())
                {
                    BooksTable.Rows.Add(b.Title, b.Type, b.FileSize, b.UDC, b.Pages, b.Publisher, b.Year, b.UploadTime, b.Author);
                }
                BookCollection.Export();
            }
            if(lib.History.Count > 1)
            {
                lib.ForwardHistory.Push(lib.History.Pop());
                BookCollection.RestoreState(lib.History.Peek());
                BooksTable.Rows.Clear();
                foreach (var b in BookCollection.Get())
                {
                    BooksTable.Rows.Add(b.Title, b.Type, b.FileSize, b.UDC, b.Pages, b.Publisher, b.Year, b.UploadTime, b.Author);
                }
                BookCollection.Export();
            }
        }

        private void ForewardButton_Click(object sender, EventArgs e)
        {
            if(lib.ForwardHistory.Count() > 0)
            {
                var temp = lib.ForwardHistory.Pop();
                BookCollection.RestoreState(temp);
                lib.History.Push(temp);
                BooksTable.Rows.Clear();
                foreach (var b in BookCollection.Get())
                {
                    BooksTable.Rows.Add(b.Title, b.Type, b.FileSize, b.UDC, b.Pages, b.Publisher, b.Year, b.UploadTime, b.Author);
                }
                BookCollection.Export();
            }
            
        }
    }
}