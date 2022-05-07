using CourseWorkAttempt.Auth;
using CourseWorkAttempt.Classes;
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
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : Page
    {
        public Users()
        {
            InitializeComponent();
            UsersList.ItemsSource = User.GetList();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex regex = new Regex(SearchBox.Text);
            List<User> tempList = new();
            foreach (var u in User.GetList())
            {
                MatchCollection matches = regex.Matches(u.ToNickname());
                if (matches.Count > 0)
                {
                    tempList.Add(u);
                }
            }
            UsersList.ItemsSource = null;
            UsersList.ItemsSource = tempList;
        }

        private void UsersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UsersList.SelectedIndex != -1)
            {
                CurrentUser currentUserPage = new(UsersList.SelectedItem);
                MainWindow.link.navigationService.Navigate(currentUserPage);
                UsersList.SelectedIndex = -1;
            }
        }
    }
}
