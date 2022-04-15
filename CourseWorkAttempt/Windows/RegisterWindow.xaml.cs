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
using System.Windows.Shapes;

namespace CourseWorkAttempt.Windows
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public static bool isOpened = false;
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            User newUser = new User();
            newUser.Nickname = NicknameBox.Text;
            newUser.Password = PasswordBox.Password.ToString();
            newUser.Surname = SurnameBox.Text;
            newUser.Name = NameBox.Text;
            newUser.Email = EmailBox.Text;
            newUser.PhoneNumber = PhoneBox.Text;
            Authorization.RegisterAccount(newUser);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            isOpened = false;
        }
    }
}
