using CourseWorkAttempt.Auth;
using CourseWorkAttempt.Classes;
using CourseWorkAttempt.Pages;
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
                    newUser.Password = Crypto.GetHash(PasswordBox.Password.ToString());
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
                    Regex regex = new Regex(@"^\+375[0-9]{9}$");
                    MatchCollection mc = regex.Matches(PhoneBox.Text);
                    if(mc.Count > 0)
                    {
                        newUser.PhoneNumber = PhoneBox.Text;
                    }
                    else
                    {
                        throw new Exception("Введите номер телефона в указанном формате.");
                    }
                }
                else
                {
                    throw new Exception("Введите номер телефона и повторите попытку.");
                }

                if (EmailBox.Text.Count() > 0)
                {
                    Regex regex = new Regex(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$");
                    MatchCollection mc = regex.Matches(EmailBox.Text);
                    if (mc.Count > 0)
                    {
                        newUser.Email = EmailBox.Text;
                    }
                    else
                    {
                        throw new Exception("Введите корректный адрес электронной почты и повторите попытку.");
                    }

                }
                else
                {
                    throw new Exception("Введите адрес электронной почты и повторите попытку.");
                }


                if (ImageBox.Text.Count() > 0)
                {
                    var uriSource = new Uri(ImageBox.Text, UriKind.Absolute);
                    newUser.ImageURL = ImageBox.Text;
                }
                else
                {
                    newUser.ImageURL = @"https://tattoo-stickers.ru/42743-large_default/pokemon-charmander.jpg"; //default
                }
                if (Authorization.RegisterAccount(newUser))
                {
                    if (Users.link != null)
                    {
                        Users.link.UsersList.ItemsSource = null;
                        Users.link.UsersList.ItemsSource = User.GetList();
                    }
                    MainPage.link.UsernameBox.Text = newUser.Nickname;
                    Close();
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message, "Ошибка заполнения формы", MessageBoxButton.OK, MessageBoxImage.Warning);
                if (ex.Message.Contains("URI"))
                {
                    ErrorMessageBlock.Text = "* " + "Ссылка на изображение в неверном формате";
                }
                else
                {
                    ErrorMessageBlock.Text = "* " + ex.Message;
                }
                
            }
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            isOpened = false;
        }

        private void ImageBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (ImageBox.Text.Length > 8)
                {
                    var uriSource = new Uri(ImageBox.Text, UriKind.Absolute);
                    ImageObject.Source = new BitmapImage(uriSource);
                }
            }
            catch
            {

            }
        }
    }
}
