using CourseWorkAttempt.Auth;
using CourseWorkAttempt.Classes;
using CourseWorkAttempt.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseWorkAttempt.Pages
{
    /// <summary>
    /// Логика взаимодействия для CurrentGame.xaml
    /// </summary>
    public partial class CurrentGame : Page
    {
        public static CurrentGame link;
        string ShopURL;
        Game CurrentGameObject;
        public CurrentGame()
        {
            InitializeComponent();
            link = this;
        }

        public CurrentGame(object game)
        {
            InitializeComponent();
            Game currentGame = game as Game;
            CurrentGameObject = currentGame;
            if(Review.GetAverageRate(CurrentGameObject.ID) != -1.0)
            {
                AverageRateBlock.Text = "Общий рейтинг: " + Convert.ToString(Review.GetAverageRate(CurrentGameObject.ID));
            }
            else
            {
                AverageRateBlock.Text = "Общий рейтинг: не определен (отзывы отсутствуют) ";
            }
            
            ReviewList.ItemsSource = Review.GetCurrentGameReviews(currentGame.ID);
            link = this;
            ShopURL = currentGame.BuyURL;
            if (currentGame != null)
            {
                if(Authorization.CurrentUser != null)
                {
                    CommentButton.IsEnabled = true;
                    if(Authorization.CurrentUser.IsAdmin == true)
                    {
                        RemoveButton.IsEnabled = true;
                        RemoveButton.Visibility = Visibility.Visible;
                    }
                }
                try
                {
                    GameImage.Source = BitmapFrame.Create(new Uri(currentGame.ImageURL));
                }
                catch { }
                
                NameBlock.Text = currentGame.Name;
                GenreBlock.Text = currentGame.Genre;
                PlatformBlock.Text = currentGame.Platform;
                DescriptionBlock.Text = currentGame.Description;
                ReleaseDateBlock.Text = "Дата релиза: " + currentGame.ReleaseDate.Value.ToShortDateString();
                DeveloperBlock.Text = "Разработчик: " + currentGame.Developer.Name + $" ({currentGame.Developer.Country})";
                PublisherBlock.Text = "Издатель: " + currentGame.Publisher.Name + $" ({currentGame.Publisher.Country})";
            }
        }

        private void ShopButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo(ShopURL) { UseShellExecute = true});
        }

        private void CommentButton_Click(object sender, RoutedEventArgs e)
        {
            if(AddReviewWindow.isOpened == false)
            {
                AddReviewWindow.isOpened = true;
                AddReviewWindow arw = new(CurrentGameObject);
                arw.Show();
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить игру?", "Удаление игры", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                MainWindow.link.navigationService.Navigate(MainWindow.link.GamesPage);
                Game.Delete(CurrentGameObject.ID);

            }
        }

        private void ReviewList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ReviewList.SelectedIndex != -1)
            {
                string userNickname = (ReviewList.SelectedItem as Review).User.Nickname;
                User user = new User();
                foreach(var u in User.GetList())
                {
                    if(u.Nickname == userNickname)
                    {
                        user = u;
                        break;
                    }
                }
                CurrentUser currentUserPage = new(user);
                MainWindow.link.navigationService.Navigate(currentUserPage);
                ReviewList.SelectedIndex = -1;
            }
        }
    }
}
