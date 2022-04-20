using CourseWorkAttempt.Auth;
using CourseWorkAttempt.Classes;
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
using System.Windows.Shapes;

namespace CourseWorkAttempt.Windows
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public static bool isOpened = false;
        public static RegisterWindow link;
        public RegisterWindow()
        {
            InitializeComponent();
            link = this;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User newUser = new User();
                if(NicknameBox.Text.Count() > 0)
                {
                    newUser.Nickname = NicknameBox.Text;
                }
                else
                {
                    throw new Exception("Имя пользователя не введено! Введите имя пользователя и повторите попытку.");
                }

                if (NicknameBox.Text.Count() <= 15)
                {
                    newUser.Nickname = NicknameBox.Text;
                }
                else
                {
                    throw new Exception("Имя пользователя должно содержать не более 15 символов.");
                }

                if (PasswordBox.Password.ToString().Count() > 0)
                {
                    newUser.Password = PasswordBox.Password.ToString();
                }
                else
                {
                    throw new Exception("Пароль не введен. Введите пароль и повторите попытку.");
                }

                if(SurnameBox.Text.Count() > 0)
                {
                    newUser.Surname = SurnameBox.Text;
                }
                else
                {
                    throw new Exception("Введите фамилию и повторите попытку.");
                }

                if (NameBox.Text.Count() > 0)
                {
                    newUser.Name = NameBox.Text;
                }
                else
                {
                    throw new Exception("Введите имя и повторите попытку.");
                }

                if (PhoneBox.Text.Count() > 0)
                {
                    newUser.PhoneNumber = PhoneBox.Text;
                }
                else
                {
                    throw new Exception("Введите номер телефона и повторите попытку.");
                }

                if (EmailBox.Text.Count() > 0)
                {
                    newUser.Email = EmailBox.Text;
                }
                else
                {
                    throw new Exception("Введите адрес электронной почты и повторите попытку.");
                }

                if (Authorization.RegisterAccount(newUser))
                {
                    MainPage.link.UsernameBox.Text = newUser.Nickname;
                    Close();
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message, "Ошибка заполнения формы", MessageBoxButton.OK, MessageBoxImage.Warning);
                ErrorMessageBlock.Text = "* " + ex.Message;
            }
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            isOpened = false;
        }
    }
}
