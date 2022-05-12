using CourseWorkAttempt.Auth;
using CourseWorkAttempt.Classes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseWorkAttempt.Pages
{
    /// <summary>
    /// Логика взаимодействия для CurrentUser.xaml
    /// </summary>
    public partial class CurrentUser : Page
    {
        User? openedUser;
        public CurrentUser()
        {
            InitializeComponent();
        }

        public CurrentUser(object user)
        {
            InitializeComponent();
            openedUser = user as User;
            ProfileUsername.Text = openedUser.Nickname;
            NameLabel.Text = openedUser.Name;
            SurnameLabel.Text = openedUser.Surname;
            EmailLabel.Text = openedUser.Email;
            PhoneLabel.Text = "";
            if (openedUser.ImageURL.Length > 8)
            {
                var uriSource = new Uri(openedUser.ImageURL, UriKind.Absolute);
                ImageObject.Source = new BitmapImage(uriSource);
            }
            UserGamesList.ItemsSource = Review.GetTopGames(openedUser.ID);
        }

        private void UserGamesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserGamesList.SelectedIndex != -1)
            {
                var review = UserGamesList.SelectedItem as Review;
                Game game = new();
                foreach(var g in Game.GetList())
                {
                    if(g.ID == review.Game.ID)
                    {
                        game = g;
                        break;
                    }
                }
                CurrentGame currentGamePage = new(game);
                MainWindow.link.navigationService.Navigate(currentGamePage);
                UserGamesList.SelectedIndex = -1;
            }
        }
    }
}
