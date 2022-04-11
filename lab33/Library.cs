using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Timer = System.Windows.Forms.Timer;

namespace lab2
{ 
    
    public partial class Library : Form
    {
        Timer timer;

        public Library()
        {
            InitializeComponent();
            InfoLabel.Text = "Текущие дата и время:";

            timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            DateLabel.Text = DateTime.Now.ToLongDateString();
            TimeLabel.Text = DateTime.Now.ToLongTimeString();
            BooksLabel.Text = BooksContainer.shelf.Count.ToString();
        }

        private void AddAuthorButton_Click(object sender, EventArgs e)
        {
            AuthorForm authorForm = new AuthorForm();
            if (AuthorControl.isFormOpened == false)
            {
                authorForm.Show();
                AuthorControl.isFormOpened = true;
            }
        }

        private void Library_Load(object sender, EventArgs e)
        {
            AuthorControl.TakeFromXML();
            BooksContainer.ExportXML();
        }

        private void AuthorField_Click(object sender, EventArgs e)
        {
            AuthorField.Items.Clear();
            AuthorControl.TakeFromXML();
            foreach (var s in AuthorControl.Authors)
            {
                AuthorField.Items.Add(s);
            }
        }

        private void AddBookButton_Click(object sender, EventArgs e)
        {
            try
            {
                Book newBook = new Book();
                newBook.Title = TitleField.Text;
                newBook.Type = FormatPicker.Text;
                if (SizeFormatField.Text == "MB")
                {
                    newBook.FileSize = Convert.ToDouble(SizeField.Text) * 1024;
                }
                else if(SizeFormatField.Text == "KB")
                {
                    newBook.FileSize = Convert.ToDouble(SizeField.Text);
                }
                else
                {
                    throw new Exception("Выберите размерность файла (МБ/КБ)!");
                }
                newBook.UDC = UDCField.Text;
                newBook.Publisher = PublisherField.Text;
                newBook.Pages = (int)PagesField.Value;
                newBook.Year = (int)YearField.Value;
                newBook.UploadTime = UploadTimePicker.Value;
                newBook.Author = (Author)AuthorField.SelectedItem;

                if(newBook != null)
                {
                    ValidationContext context = new ValidationContext(newBook);
                    IList<ValidationResult> errors = new List<ValidationResult>();
                    if(!Validator.TryValidateObject(newBook, context, errors, true))
                    {
                        foreach(ValidationResult result in errors)
                        {
                            MessageBox.Show(result.ErrorMessage, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show(newBook.ToString(), "Книга добавлена");
                        LastActionLabel.Text = "Добавление книги";
                        BooksContainer.shelf.Add(newBook);
                        BooksContainer.ImportXML();
                    }
                }
                
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"{ex.Message} \n Размер файла указан в неверном формате!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception exc) 
            {
                MessageBox.Show($"{exc.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            LastActionLabel.Text = "Извлечение из XML";
            BooksContainer.ExportXML();
            BooksTable.Rows.Clear();
            foreach(var b in BooksContainer.shelf)
            {
                BooksTable.Rows.Add(b.Title, b.Type, b.FileSize, b.UDC, b.Pages, b.Publisher, b.Year, b.UploadTime, b.Author);
            }
        }

        private void SearchFormButton_Click(object sender, EventArgs e)
        {
            if(SearchControl.isFormOpened == false)
            {
                SearchForm Form = new SearchForm();
                Form.Show();
                SearchControl.isFormOpened = true;
                LastActionLabel.Text = "Поиск";
            }
        }

        private void SortByName_Click(object sender, EventArgs e)
        {
            LastActionLabel.Text = "Сортировка по названию";
            BooksTable.Rows.Clear();
            BooksContainer.SortByName();
            foreach (var b in BooksContainer.shelfByName)
            {
                BooksTable.Rows.Add(b.Title, b.Type, b.FileSize, b.UDC, b.Pages, b.Publisher, b.Year, b.UploadTime, b.Author);
            }
        }

        private void SortByTime_Click(object sender, EventArgs e)
        {
            LastActionLabel.Text = "Сортировка по времени загрузки";
            BooksTable.Rows.Clear();
            BooksContainer.SortByTime();
            foreach (var b in BooksContainer.shelfByTime)
            {
                BooksTable.Rows.Add(b.Title, b.Type, b.FileSize, b.UDC, b.Pages, b.Publisher, b.Year, b.UploadTime, b.Author);
            }
        }

        private void AboutTool_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Электронная библиотека \n Разработчик: Заянковский Дмитрий Владимирович \n v1.0 \n 2022", "О программе");
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            LastActionLabel.Text = "Очистка";
            BooksTable.Rows.Clear();
            TitleField.Text =  "";
            SizeField.Text = "";
            FormatPicker.SelectedItem = null;
            SizeFormatField.SelectedItem = null;
            UDCField.Text = "";
            PublisherField.Text = "";
            PagesField.Value = 8;
            YearField.Value = 2022;
            UploadTimePicker.Value = DateTime.Now;
            AuthorField.SelectedItem = null;
            StateControl.redoStack.Clear();
            StateControl.undoStack.Clear();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if(BooksTable.CurrentRow as object == null)
            {
                MessageBox.Show("Книга не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string? bookTitle = BooksTable[0, BooksTable.CurrentRow.Index].Value as string;
                if (bookTitle != null)
                {
                    string caption = "Удаление книги";
                    string message = $"Вы действительно хотите удалить книгу [{bookTitle}] из библиотеки?";
                    DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        foreach (var s in BooksContainer.shelf)
                        {
                            if (s.Title == bookTitle)
                            {
                                BooksContainer.shelf.Remove(s);
                                LastActionLabel.Text = "Удаление книги";
                                break;
                            }
                        }
                        BooksContainer.ImportXML();
                        BooksTable.Rows.Clear();
                        foreach (var b in BooksContainer.shelf)
                        {
                            BooksTable.Rows.Add(b.Title, b.Type, b.FileSize, b.UDC, b.Pages, b.Publisher, b.Year, b.UploadTime, b.Author);
                        }
                    }
                }
            }
            
        }

        private void TitleField_TextChanged(object sender, EventArgs e)
        {
            State state = new State("TitleField", TitleField.Text);
            StateControl.undoStack.Push(state);

        }

        private void UndoAction()
        {
            if (StateControl.undoStack.Count > 1)
            {
                State temp1 = StateControl.undoStack.Pop();
                StateControl.redoStack.Push(temp1);
                temp1 = StateControl.undoStack.Peek();
                if (temp1.Location == "TitleField")
                {
                    TitleField.Text = temp1.Value;
                }
                else if (temp1.Location == "SizeField")
                {
                    SizeField.Text = temp1.Value;
                }
                else if(temp1.Location == "UDCField")
                {
                    UDCField.Text = temp1.Value;
                }
                else if (temp1.Location == "PublisherField")
                {
                    PublisherField.Text = temp1.Value;
                }
            }
        }

        private void RedoAction()
        {
            if (StateControl.redoStack.Count > 0)
            {
                State temp1 = StateControl.redoStack.Pop();
                if (temp1.Location == "TitleField")
                {
                    TitleField.Text = temp1.Value;
                }
                else if (temp1.Location == "SizeField")
                {
                    SizeField.Text = temp1.Value;
                }
                else if(temp1.Location == "UDCField")
                {
                    UDCField.Text = temp1.Value;
                }
                else if(temp1.Location == "PublisherField")
                {
                    PublisherField.Text = temp1.Value;
                }
            }
            
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {

            UndoAction();
            UndoAction();
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            RedoAction();
            RedoAction();
        }

        private void SizeField_TextChanged(object sender, EventArgs e)
        {
            State state = new State("SizeField", SizeField.Text);
            StateControl.undoStack.Push(state);
        }

        private void HideToolsButton_Click(object sender, EventArgs e)
        {
            if(HideToolsButton.Text == "Скрыть панель")
            {
                HideToolsButton.Text = "Показать панель";
                toolStrip.Visible = false;
            }
            else
            {
                HideToolsButton.Text = "Скрыть панель";
                toolStrip.Visible = true;
            }
        }

        private void UDCField_TextChanged(object sender, EventArgs e)
        {
            State state = new State("UDCField", UDCField.Text);
            StateControl.undoStack.Push(state);
        }

        private void PublisherField_TextChanged(object sender, EventArgs e)
        {
            State state = new State("PublisherField", PublisherField.Text);
            StateControl.undoStack.Push(state);
        }
    }
}