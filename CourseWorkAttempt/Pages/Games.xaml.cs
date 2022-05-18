using CourseWorkAttempt.Classes;
using CourseWorkAttempt.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseWorkAttempt.Pages
{
    /// <summary>
    /// Логика взаимодействия для Games.xaml
    /// </summary>
    public partial class Games : Page
    {
        public static Games link;
        public Games()
        {
            InitializeComponent();
            GenreBox.ItemsSource = Game.GetGenresWithAll();
            GenreBox.SelectedIndex = 0;
            GameList.ItemsSource = Game.GetList();
            AddGameButton.IsEnabled = false;
            AddGameButton.Visibility = Visibility.Hidden;
            link = this;
        }

        private void GameList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(GameList.SelectedIndex != -1)
            {
                CurrentGame currentGamePage = new(GameList.SelectedItem);
                MainWindow.link.navigationService.Navigate(currentGamePage);
                GameList.SelectedIndex = -1;
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var selectedItem = GenreBox.SelectedItem;
            SearchFunc(selectedItem);
        }
        private void GenreBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = GenreBox.SelectedItem;
            SearchFunc(selectedItem);
        }

        void SearchFunc(object selectedItem)
        {
            if (GenreBox.SelectedIndex != 0)
            {
                string genre = "void";
                Regex regex = new Regex(SearchBox.Text, RegexOptions.IgnoreCase);
                List<Game> tempList = new();
                foreach (var g in Game.GetList())
                {
                    MatchCollection matches = regex.Matches(g.ToString());
                    if (matches.Count > 0)
                    {
                        tempList.Add(g);
                    }
                }
                if(selectedItem != null)
                {
                    genre = (selectedItem as ComboBoxItem).Content.ToString();
                }          
                List<Game> tempList2 = new();
                foreach(var g in tempList)
                {
                    if(g.Genre == genre)
                    {
                        tempList2.Add(g);
                    }
                }
                GameList.ItemsSource = null;
                GameList.ItemsSource = tempList2;
            }
            else
            {
                Regex regex = new Regex(SearchBox.Text, RegexOptions.IgnoreCase);
                List<Game> tempList = new();
                foreach (var g in Game.GetList())
                {
                    MatchCollection matches = regex.Matches(g.ToString());
                    if (matches.Count > 0)
                    {
                        tempList.Add(g);
                    }
                }
                GameList.ItemsSource = null;
                GameList.ItemsSource = tempList;
            }
        }

        private void AddGameButton_Click(object sender, RoutedEventArgs e)
        {
            if(AddGameWindow.isOpened == false)
            {
                AddGameWindow.isOpened = true;
                AddGameWindow agw = new();
                agw.Show();
            }
        }
    }
}
