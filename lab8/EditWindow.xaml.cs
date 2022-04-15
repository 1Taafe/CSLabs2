using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace lab67
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        Book windowBook;
        AboutWindow parentWindow;
        public EditWindow()
        {
            InitializeComponent();
            ResourceDictionary language = new ResourceDictionary();
            language.Source = new Uri(MainWindow.mainWindow.languagePath, UriKind.Relative);
            Resources.MergedDictionaries.Add(language);
        }

        /*
         <TextBlock Padding="0,4,0,4">Детектив</TextBlock>
                <TextBlock Padding="0,4,0,4">Приключения</TextBlock>
                <TextBlock Padding="0,4,0,4">Сказки</TextBlock>
                <TextBlock Padding="0,4,0,4">Фантастика</TextBlock>
                <TextBlock Padding="0,4,0,4">Наука</TextBlock>
         */
        public EditWindow(Book book, AboutWindow aboutWindow)
        {
            InitializeComponent();

            ResourceDictionary language = new ResourceDictionary();
            language.Source = new Uri(MainWindow.mainWindow.languagePath, UriKind.Relative);
            Resources.MergedDictionaries.Add(language);

            parentWindow = aboutWindow;
            windowBook = book;
            TitleField.Text = book.Title;
            foreach(var s in GenreField.Items)
            {
                if((s as TextBlock).Text == book.Genre)
                {
                    GenreField.SelectedItem = s;
                }
            }
            DiscriptionField.Text = book.Description;
            AuthorField.Text = book.Author;
            PublisherField.Text = book.Publisher;
            CountryField.Text = book.Country;
            YearField.Text = book.Year.ToString();
            CostField.Text = book.Cost.ToString();
            AmountField.Text = book.Amount.ToString();
            imageLabel.Content = book.ImagePath;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TitleField.Text.Length < 1)
                {
                    throw new Exception("Введите название книги!");
                }
                else
                {
                    windowBook.Title = TitleField.Text;
                }
                if (GenreField.SelectedValue == null)
                {
                    throw new Exception("Введите жанр");
                }
                else
                {
                    windowBook.Genre = GenreField.Text;
                }
                if (DiscriptionField.Text.Length < 1)
                {
                    throw new Exception("Введите описание!");
                }
                else
                {
                    windowBook.Description = DiscriptionField.Text;
                }
                if (AuthorField.Text.Length < 1)
                {
                    throw new Exception("Введите автора!");
                }
                else
                {
                    windowBook.Author = AuthorField.Text;
                }
                if (PublisherField.Text.Length < 1)
                {
                    throw new Exception("Введите издательство!");
                }
                else
                {
                    windowBook.Publisher = PublisherField.Text;
                }
                if (CountryField.Text.Length < 1)
                {
                    throw new Exception("Введите страну!");
                }
                else
                {
                    windowBook.Country = CountryField.Text;
                }
                if (YearField.Text.Length < 1)
                {
                    throw new Exception("Введите год издания!");
                }
                else
                {
                    int year = Convert.ToInt32(YearField.Text);
                    if (year < 1600 || year > 2200)
                    {
                        throw new Exception("Введите год от 1600 до 2200!");
                    }
                    else
                    {
                        windowBook.Year = year;
                    }
                }
                if (CostField.Text.Length < 1)
                {
                    throw new Exception("Введите цену!");
                }
                else
                {
                    windowBook.Cost = Convert.ToDouble(CostField.Text);
                }
                if (AmountField.Text.Length < 1)
                {
                    throw new Exception("Введите количество");
                }
                else
                {
                    windowBook.Amount = Convert.ToInt32(AmountField.Text);
                }
                if (imageLabel.Content.ToString() == "Не выбрано")
                {
                    throw new Exception("Выберите картинку!");
                }
                else
                {
                    windowBook.ImagePath = imageLabel.Content.ToString();
                }
                parentWindow.Update(windowBook);
                Book.Export();
                State.undoStack.Push(Book.GetListFromXML());
                MainWindow.BooksList.ItemsSource = null;
                MainWindow.BooksList.ItemsSource = Book.Collection;
                MainWindow.mainWindow.InputFunc();
                MessageBox.Show("Редактирование выполнено!", "Изменение", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == false)
                return;
            // получаем выбранный файл
            string filename = opf.FileName;
            // читаем файл в строку
            imageLabel.Content = filename;
        }
    }
}
