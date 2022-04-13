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
        public MainPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            bool isConnected = Login.TryToConnect(UsernameBox.Text, PasswordBox.Password.ToString());
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
            }
        }

        private void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            bool isDisconnected = Login.Disconnect();
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
