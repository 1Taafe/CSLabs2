using CourseWorkAttempt.Pages;
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
using Microsoft.Data.SqlClient;
using CourseWorkAttempt.Auth;
using System.Net;
using System.Net.Http;

namespace CourseWorkAttempt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public NavigationService navigationService;
        public Profile ProfilePage = new Profile();
        public Games GamesPage = new Games();
        public MainPage MainPage = new MainPage();
        public Users UsersPage = new Users();
        public static MainWindow link;
        public MainWindow()
        {
            Auth.Authorization.CheckConnection();
            InitializeComponent();
            navigationService = MainFrame.NavigationService;
            navigationService.Navigate(MainPage);
            link = this;
        }

        private void MainPageButton_Click(object sender, RoutedEventArgs e)
        {
            navigationService.Navigate(MainPage);
        }

        private void ProfilePageButton_Click(object sender, RoutedEventArgs e)
        {
            navigationService.Navigate(ProfilePage);
        }

        private void GamesPageButton_Click(object sender, RoutedEventArgs e)
        {
            navigationService.Navigate(GamesPage);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                navigationService.GoBack();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void ForeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                navigationService.GoForward();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void UsersPageButton_Click(object sender, RoutedEventArgs e)
        {
            navigationService.Navigate(UsersPage);
        }
    }
}
