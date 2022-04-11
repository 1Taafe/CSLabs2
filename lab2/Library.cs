using System.Xml.Serialization;

namespace lab2
{
    public partial class Library : Form
    {
        public Library()
        {
            InitializeComponent();
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

                if (TitleField.Text.Length < 1)
                {
                    throw new Exception("�������� ����� �� �������!");
                }
                else
                {
                    newBook.Title = TitleField.Text;
                }

                if (FormatPicker.Text.Length < 1)
                {
                    throw new Exception("������ ����� �� ������!");
                }
                else
                {
                    newBook.Type = FormatPicker.Text;
                }

                if(SizeFormatField.Text.Length < 1)
                {
                    throw new Exception("������ ������� ����� �� ������!");
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
                    throw new Exception("������� ���!");
                }
                else
                {
                    newBook.UDC = UDCField.Text;
                }

                if (PublisherField.Text.Length < 1)
                {
                    throw new Exception("������� �������� ������������!");
                }
                else
                {
                    newBook.Publisher = PublisherField.Text;
                }

                newBook.Pages = (int)PagesField.Value;
                newBook.Year = (int)YearField.Value;
                newBook.UploadTime = UploadTimePicker.Value;
                
                if(AuthorField.SelectedItem == null)
                {
                    throw new Exception("����� ����� �� ������!");
                }
                else
                {
                    newBook.Author = (Author)AuthorField.SelectedItem;
                }
                
                MessageBox.Show(newBook.ToString(), "����� ���������");
                BooksContainer.shelf.Add(newBook);
                BooksContainer.ImportXML();
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"{ex.Message} \n ������ ����� ������ � �������� �������!", "������");
            }
            catch (Exception exc) 
            {
                MessageBox.Show($"{exc.Message}", "������");
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            BooksContainer.ExportXML();
            BooksTable.Rows.Clear();
            foreach(var b in BooksContainer.shelf)
            {
                BooksTable.Rows.Add(b.Title, b.Type, b.FileSize, b.UDC, b.Pages, b.Publisher, b.Year, b.UploadTime, b.Author);
            }
        }
    }
}