using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;

namespace lab67
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///
    public partial class MainWindow : Window
    {
        public static ListBox BooksList;
        public static MainWindow mainWindow;
        public string languagePath;
        public string WindowLanguage = "Russian";

        string magentaStyle = "Styles/Magenta";
        string blueStyle = "Styles/Blue";
        string currentStyle = "Styles/Magenta";

        public MainWindow()
        {
            InitializeComponent();
            BooksList = booksList;
            mainWindow = this;
            DataContext = new ApplicationsViewModel();

            ResourceDictionary language = new ResourceDictionary();
            languagePath = "Russian.xaml";
            language.Source = new Uri(languagePath, UriKind.Relative);

            Book.Import();
            foreach (var b in Book.Collection)
            {
                Book.currentCollection.Add(b);
            }


            State.undoStack.Push(Book.GetListFromXML());
            //MessageBox.Show($"{Book.GetListFromXML().First().Title}");

        }

        public void SwitchLanguageRussian() // Меняем язык на русский
        {
            languagePath = "Russian.xaml";
            ResourceDictionary language = new ResourceDictionary();
            language.Source = new Uri(languagePath, UriKind.Relative);
            Resources.MergedDictionaries.Add(language);
        }

        public void SwitchLanguageEng() // Меняем язык на англ
        {
            languagePath = "English.xaml";
            ResourceDictionary language = new ResourceDictionary();
            language.Source = new Uri(languagePath, UriKind.Relative);
            Resources.MergedDictionaries.Add(language);
        }

        /*private void AddButton_Click(object sender, RoutedEventArgs e)
        {      
            AddWindow addWindow = new AddWindow();
            if(AddWindow.isOpened == false)
            {
                addWindow.Show();
                AddWindow.isOpened = true;
            }
        }*/

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            booksList.ItemsSource = Book.Collection;
            
        }

        public void GenreBox_DropDownClosed(object sender, EventArgs e)
        {
            InputFunc();
        }

        /*
         * <TextBlock>Не сортировать</TextBlock>
                <TextBlock>По названию ▲</TextBlock>
                <TextBlock>По названию ▼</TextBlock>
                <TextBlock>По цене ▲</TextBlock>
                <TextBlock>По цене ▼</TextBlock>
         */
        public void SortBox_DropDownClosed(object sender, EventArgs e)
        {
            InputFunc();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFunc();
        }

        public void InputFunc()
        {
            booksList.ItemsSource = null;
            List<Book> tempo = new List<Book>();
            if (GenreBox.Text == "Все")
            {
                Book.currentCollection = Book.Collection;
                booksList.ItemsSource = Book.currentCollection;
                tempo = Book.currentCollection;
            }
            else if(GenreBox.Text == "All")
            {
                Book.currentCollection = Book.Collection;
                booksList.ItemsSource = Book.currentCollection;
                tempo = Book.currentCollection;
            }
            else
            {
                Book.currentCollection = Book.Collection.Where(b => b.Genre == GenreBox.Text).ToList();
                booksList.ItemsSource = Book.currentCollection;
                tempo = Book.currentCollection;
            }

            if (SortBox.Text == "Не сортировать")
            {
                booksList.ItemsSource = Book.currentCollection;
                tempo = Book.currentCollection;
            }
            else if (SortBox.Text == "По названию ▲")
            {
                booksList.ItemsSource = Book.currentCollection.OrderBy(b => b.Title).ToList();
                tempo = Book.currentCollection.OrderBy(b => b.Title).ToList();
            }
            else if (SortBox.Text == "По названию ▼")
            {
                booksList.ItemsSource = Book.currentCollection.OrderByDescending(b => b.Title).ToList();
                tempo = Book.currentCollection.OrderByDescending(b => b.Title).ToList();
            }
            else if (SortBox.Text == "По цене ▲")
            {
                booksList.ItemsSource = Book.currentCollection.OrderBy(b => b.Cost).ToList();
                tempo = Book.currentCollection.OrderBy(b => b.Cost).ToList(); 
            }
            else if (SortBox.Text == "По цене ▼")
            {
                booksList.ItemsSource = Book.currentCollection.OrderByDescending(b => b.Cost).ToList();
                tempo = Book.currentCollection.OrderByDescending(b => b.Cost).ToList();
            }

            if (SortBox.Text == "Without sort")
            {
                booksList.ItemsSource = Book.currentCollection;
                tempo = Book.currentCollection;
            }
            else if (SortBox.Text == "By Title ▲")
            {
                booksList.ItemsSource = Book.currentCollection.OrderBy(b => b.Title).ToList();
                tempo = Book.currentCollection.OrderBy(b => b.Title).ToList();
            }
            else if (SortBox.Text == "By Title ▼")
            {
                booksList.ItemsSource = Book.currentCollection.OrderByDescending(b => b.Title).ToList();
                tempo = Book.currentCollection.OrderByDescending(b => b.Title).ToList();
            }
            else if (SortBox.Text == "By Cost ▲")
            {
                booksList.ItemsSource = Book.currentCollection.OrderBy(b => b.Cost).ToList();
                tempo = Book.currentCollection.OrderBy(b => b.Cost).ToList();
            }
            else if (SortBox.Text == "By Cost ▼")
            {
                booksList.ItemsSource = Book.currentCollection.OrderByDescending(b => b.Cost).ToList();
                tempo = Book.currentCollection.OrderByDescending(b => b.Cost).ToList();
            }

            List<Book> temp = new List<Book>();
            Regex regex = new Regex(SearchBox.Text);
            foreach (var b in tempo)
            {
                MatchCollection matches = regex.Matches(b.Title);
                if (matches.Count > 0)
                {
                    temp.Add(b);
                }
            }
            booksList.ItemsSource = temp;
        }

        private void booksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(booksList.SelectedIndex != -1)
            {
                Book book = (Book)booksList.SelectedItem;
                AboutWindow aboutWindow = new AboutWindow(book);
                aboutWindow.Show();
            }
        }

        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            if (State.undoStack.Count <= 1)
            {
                Book.Collection = State.undoStack.Peek();
                //MessageBox.Show($"{State.undoStack.Peek().First().Title}");
                MessageBox.Show("Не удалось отменить действие", "UndoStack пуст", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (State.undoStack.Count > 1)
            {
                State.redoStack.Push(State.undoStack.Peek());
                State.undoStack.Pop();
                Book.Collection = State.undoStack.Peek();
                MessageBox.Show($"{State.undoStack.Peek().First().Title}");
                Book.Export();
                MainWindow.BooksList.ItemsSource = null;
                MainWindow.BooksList.ItemsSource = Book.Collection;
            }
        }

        private void RedoButton_Click(object sender, RoutedEventArgs e)
        {
            if(State.redoStack.Count >= 1)
            {
                var tempState = State.redoStack.Pop();
                State.undoStack.Push(tempState);
                Book.Collection = tempState;
                MessageBox.Show($"{State.undoStack.Peek().First().Title}");
                Book.Export();
                MainWindow.BooksList.ItemsSource = null;
                MainWindow.BooksList.ItemsSource = Book.Collection;
            }
            else
            {
                MessageBox.Show("Не удалось повторить действие", "RedoStack пуст", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ThemeButton_Click(object sender, RoutedEventArgs e)
        {
            if(currentStyle == "Styles/Magenta")
            {
                var uri = new Uri(blueStyle + ".xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
                currentStyle = "Styles/Blue";
            }
            else
            {
                var uri = new Uri(magentaStyle + ".xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
                currentStyle = "Styles/Magenta";
            }
            
        }
    }
}
