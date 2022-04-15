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
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    /// 
    public partial class AddWindow : Window
    {
        public static bool isOpened = false;
        public AddWindow()
        {
            InitializeComponent();
            ResourceDictionary language = new ResourceDictionary();
            language.Source = new Uri(MainWindow.mainWindow.languagePath, UriKind.Relative);
            Resources.MergedDictionaries.Add(language);
        }

        private void AddWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            isOpened = false;
        }

        private void AddingCancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddingButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Book newBook = new Book();
                if(TitleField.Text.Length < 1)
                {
                    throw new Exception("Введите название книги!");
                }
                else
                {
                    newBook.Title = TitleField.Text;
                }
                if (GenreField.SelectedValue == null)
                {
                    throw new Exception("Введите жанр");
                }
                else
                {
                    newBook.Genre = GenreField.Text;
                }
                if(DiscriptionField.Text.Length < 1)
                {
                    throw new Exception("Введите описание!");
                }
                else
                {
                    newBook.Description = DiscriptionField.Text;
                }
                if(AuthorField.Text.Length < 1)
                {
                    throw new Exception("Введите автора!");
                }
                else
                {
                    newBook.Author = AuthorField.Text;
                }
                if(PublisherField.Text.Length < 1)
                {
                    throw new Exception("Введите издательство!");
                }
                else
                {
                    newBook.Publisher = PublisherField.Text;
                }
                if (CountryField.Text.Length < 1)
                {
                    throw new Exception("Введите страну!");
                }
                else
                {
                    newBook.Country = CountryField.Text;
                }
                if (YearField.Text.Length < 1)
                {
                    throw new Exception("Введите год издания!");
                }
                else
                {
                    int year = Convert.ToInt32(YearField.Text);
                    if(year < 1600 || year > 2200)
                    {
                        throw new Exception("Введите год издания!");
                    }
                    else
                    {
                        newBook.Year = year;
                    }
                }
                if (CostField.Text.Length < 1)
                {
                    throw new Exception("Введите цену!");
                }
                else
                {
                    newBook.Cost = Convert.ToDouble(CostField.Text);
                }
                if(AmountField.Text.Length < 1)
                {
                    throw new Exception("Введите количество");
                }
                else
                {
                    newBook.Amount = Convert.ToInt32(AmountField.Text);
                }
                if(imageLabel.Content.ToString() == "Не выбрано")
                {
                    throw new Exception("Выберите картинку!");
                }
                else
                {
                    newBook.ImagePath = imageLabel.Content.ToString();
                }
                Book.Push(newBook);
                MainWindow.mainWindow.SortBox_DropDownClosed(sender, e);
                MainWindow.mainWindow.GenreBox_DropDownClosed(sender, e);
            }
            catch(Exception ex)
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
