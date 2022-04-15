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
    /// Логика взаимодействия для AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        int BookID;
        public Book windowBook;
        public static bool isOpened = false;
        public AboutWindow()
        {
            InitializeComponent();
            ResourceDictionary language = new ResourceDictionary();
            language.Source = new Uri(MainWindow.mainWindow.languagePath, UriKind.Relative);
            Resources.MergedDictionaries.Add(language);
        }

        public AboutWindow(Book book)
        {
            InitializeComponent();

            ResourceDictionary language = new ResourceDictionary();
            language.Source = new Uri(MainWindow.mainWindow.languagePath, UriKind.Relative);
            Resources.MergedDictionaries.Add(language);

            DataContext = new ApplicationsViewModel();
            if(book != null)
            {
                this.Title = book.Title;
                windowBook = book;
                BookID = book.ID;
                TitleField.Text = book.Title;
                CountryField.Text = book.Country;
                GenreField.Text = book.Genre;
                DescriptionField.Text = book.Description;
                AuthorField.Text = book.Author;
                YearField.Text = book.Year.ToString();
                PublisherField.Text = book.Publisher;
                CostField.Text = book.Cost.ToString();
                AmountField.Text = book.Amount.ToString();
                AvailabilityField.Text = book.Availability;
                ImageField.Source = BitmapFrame.Create(new Uri(book.ImagePath));
            }
            
        }

        public void Update(Book book)
        {
            this.Title = book.Title;
            windowBook = book;
            BookID = book.ID;
            TitleField.Text = book.Title;
            GenreField.Text = book.Genre;
            DescriptionField.Text = book.Description;
            AuthorField.Text = book.Author;
            CountryField.Text = book.Country;
            YearField.Text = book.Year.ToString();
            PublisherField.Text = book.Publisher;
            CostField.Text = book.Cost.ToString();
            AmountField.Text = book.Amount.ToString();
            AvailabilityField.Text = book.Availability;
            ImageField.Source = BitmapFrame.Create(new Uri(book.ImagePath));
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow.BooksList.SelectedIndex = -1;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            windowBook.Amount--;
            AmountField.Text = windowBook.Amount.ToString();
            AvailabilityField.Text = windowBook.Availability;
            Book.Export();
            MainWindow.BooksList.ItemsSource = null;
            MainWindow.BooksList.ItemsSource = Book.Collection;
            MainWindow.mainWindow.InputFunc();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            windowBook.Amount++;
            AmountField.Text = windowBook.Amount.ToString();
            AvailabilityField.Text = windowBook.Availability;
            Book.Export();
            MainWindow.BooksList.ItemsSource = null;
            MainWindow.BooksList.ItemsSource = Book.Collection;
            MainWindow.mainWindow.InputFunc();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditWindow editWindow = new EditWindow(windowBook, this);
            editWindow.Show();
        }
    }
}
