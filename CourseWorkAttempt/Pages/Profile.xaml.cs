using CourseWorkAttempt.Auth;
using CourseWorkAttempt.Classes;
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
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        private static Profile profilePage;

        public static Profile GetPage()
        {
            if (profilePage == null)
                profilePage = new Profile();
            return profilePage;
        }
        private Profile()
        {
            InitializeComponent();
        }

        private void EditWindowButton_Click(object sender, RoutedEventArgs e)
        {
            if(EditProfileWindow.isOpened == false)
            {
                EditProfileWindow editProfileWindow = new();
                EditProfileWindow.isOpened = true;
                editProfileWindow.Show();
            }
        }

        private void DeleteProfileButton_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы действительно хотите удалить аккаунт?", "Удаление профиля", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                MainWindow.link.navigationService.Navigate(MainWindow.link.MainPage);
                Authorization.DeleteAccount();
                MainPage.GetPage().DisconnectButton_Click(sender, e);
                if(Users.GetPage() != null)
                {
                    Users.GetPage().UsersList.ItemsSource = null;
                    Users.GetPage().UsersList.ItemsSource = User.GetList();
                }
                
            }
            
        }
    }
}
