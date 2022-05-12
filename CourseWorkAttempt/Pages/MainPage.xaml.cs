using CourseWorkAttempt.Auth;
using CourseWorkAttempt.Windows;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public static MainPage link;
        public MainPage()
        {
            InitializeComponent();
            link = this;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            bool isConnected = Authorization.TryToLogin(UsernameBox.Text, PasswordBox.Password.ToString());
            if(isConnected == true)
            {
                PasswordLabel.Visibility = Visibility.Hidden;
                PasswordBox.Visibility = Visibility.Hidden;
                UsernameBox.IsEnabled = false;
                PasswordBox.Password = null;
                LoginButton.Visibility = Visibility.Hidden;
                DisconnectButton.Visibility = Visibility.Visible;
                RegisterButton.Visibility = Visibility.Hidden;
                AuthTextBlock.Text = "Вы уже авторизованы! Мы очень рады, что у вас есть учётная запись. Оставляйте свои " +
                    "отзывы и читайте отзывы других людей";

                Profile profilePage = MainWindow.link.ProfilePage;
                profilePage.ProfileUsername.Text = Authorization.CurrentUser.Nickname;
                profilePage.SurnameLabel.Text = Authorization.CurrentUser.Surname;
                profilePage.NameLabel.Text = Authorization.CurrentUser.Name;
                profilePage.EmailLabel.Text = Authorization.CurrentUser.Email;
                profilePage.PhoneLabel.Text = Authorization.CurrentUser.PhoneNumber;
                MainWindow.link.ProfilePageButton.IsEnabled = true;
                ErrorBlock.Text = null;

                if (CurrentGame.link != null)
                {
                    CurrentGame.link.CommentButton.IsEnabled = true;
                }


                if (Authorization.CurrentUser.ImageURL.Length > 8)
                {
                    var uriSource = new Uri(Authorization.CurrentUser.ImageURL, UriKind.Absolute);
                    profilePage.ImageObject.Source = new BitmapImage(uriSource);
                }
                
            }
        }

        public void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            bool isDisconnected = Authorization.Disconnect();
            if(isDisconnected == true)
            {
                PasswordLabel.Visibility = Visibility.Visible;
                PasswordBox.Visibility = Visibility.Visible;
                UsernameBox.IsEnabled = true;
                PasswordBox.Password = null;
                LoginButton.Visibility = Visibility.Visible;
                DisconnectButton.Visibility = Visibility.Hidden;
                RegisterButton.Visibility = Visibility.Visible;
                AuthTextBlock.Text = "Вы можете искать нужные игры и отзывы без регистрации, " +
                    "но если вы хотите написать свой отзыв, мы этому только рады, предложив зарегистрироваться";

                Profile profilePage = MainWindow.link.ProfilePage;
                profilePage.ProfileUsername.Text = null;
                profilePage.SurnameLabel.Text = null;
                profilePage.NameLabel.Text = null;
                profilePage.EmailLabel.Text = null;
                profilePage.PhoneLabel.Text = null;
                MainWindow.link.ProfilePageButton.IsEnabled = false;

                if (CurrentGame.link != null)
                {
                    CurrentGame.link.CommentButton.IsEnabled = false;
                }


                while (MainWindow.link.navigationService.RemoveBackEntry() != null)
                {
                    MainWindow.link.navigationService.RemoveBackEntry();
                }


            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if(RegisterWindow.isOpened == false)
            {
                RegisterWindow registerWindow = new RegisterWindow();
                RegisterWindow.isOpened = true;
                registerWindow.Show();
            }
        }
    }
}
