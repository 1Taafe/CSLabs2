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
using System.Threading;
using System.Windows.Threading;

namespace CourseWorkAttempt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public NavigationService navigationService;
        public Profile ProfilePage = Profile.GetPage();
        public Games GamesPage = Games.GetPage();
        public MainPage MainPage = MainPage.GetPage();
        public Users UsersPage = Users.GetPage();
        public static MainWindow link;

        private DispatcherTimer timer = null;
        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(Auth.Authorization.CheckConnection);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 5000);
            timer.Start();
        }
        public MainWindow()
        {
            InitializeTimer();
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
