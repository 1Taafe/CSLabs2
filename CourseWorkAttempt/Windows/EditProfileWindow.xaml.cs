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
    /// Логика взаимодействия для EditProfileWindow.xaml
    /// </summary>
    public partial class EditProfileWindow : Window
    {
        public static bool isOpened = false;
        public static EditProfileWindow? link;

        public EditProfileWindow()
        {
            InitializeComponent();
            link = this;
            NameBox.Text = Authorization.CurrentUser.Name;
            SurnameBox.Text = Authorization.CurrentUser.Surname;
            NicknameBox.Text = Authorization.CurrentUser.Nickname;
            EmailBox.Text = Authorization.CurrentUser.Email;
            PhoneBox.Text = Authorization.CurrentUser.PhoneNumber;
            ImageBox.Text = Authorization.CurrentUser.ImageURL;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            isOpened = false;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NicknameBox.Text.Count() > 0)
                {
                    Authorization.CurrentUser.Nickname = NicknameBox.Text;
                }
                else
                {
                    throw new Exception("Имя пользователя не введено! Введите имя пользователя и повторите попытку.");
                }

                if (NicknameBox.Text.Count() <= 15)
                {
                    Authorization.CurrentUser.Nickname = NicknameBox.Text;
                }
                else
                {
                    throw new Exception("Имя пользователя должно содержать не более 15 символов.");
                }

                if (Crypto.GetHash(PasswordBox.Password.ToString()) == Authorization.CurrentUser.Password.ToString())
                {
                    if(NewPasswordBox.Password.ToString().Length > 0)
                    {
                        Authorization.CurrentUser.Password = Crypto.GetHash(NewPasswordBox.Password.ToString());
                    }
                    else
                    {
                        Authorization.CurrentUser.Password = Crypto.GetHash(PasswordBox.Password.ToString());
                    }
                }
                else
                {
                    throw new Exception("Введеный пароль не совпадает с текущим. Введите верный текущий пароль и повторите попытку.");
                }

                if (SurnameBox.Text.Count() > 0)
                {
                    Authorization.CurrentUser.Surname = SurnameBox.Text;
                }
                else
                {
                    throw new Exception("Введите фамилию и повторите попытку.");
                }

                if (NameBox.Text.Count() > 0)
                {
                    Authorization.CurrentUser.Name = NameBox.Text;
                }
                else
                {
                    throw new Exception("Введите имя и повторите попытку.");
                }

                if (PhoneBox.Text.Count() > 0)
                {
                    Regex regex = new Regex(@"^\+375[0-9]{9}$");
                    MatchCollection mc = regex.Matches(PhoneBox.Text);
                    if (mc.Count > 0)
                    {
                        Authorization.CurrentUser.PhoneNumber = PhoneBox.Text;
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
                        Authorization.CurrentUser.Email = EmailBox.Text;
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
                    Authorization.CurrentUser.ImageURL = ImageBox.Text;
                }
                else
                {
                    Authorization.CurrentUser.ImageURL = @"https://tattoo-stickers.ru/42743-large_default/pokemon-charmander.jpg"; //default
                }

                MainPage.GetPage().UsernameBox.Text = Authorization.CurrentUser.Nickname;
                if(User.UpdateUser())
                {
                    MessageBox.Show("Редактирование выполнено.", "Изменение профиля", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow.link.ProfilePage.ProfileUsername.Text = Authorization.CurrentUser.Nickname;
                    MainWindow.link.ProfilePage.SurnameLabel.Text = Authorization.CurrentUser.Surname;
                    MainWindow.link.ProfilePage.NameLabel.Text = Authorization.CurrentUser.Name;
                    MainWindow.link.ProfilePage.PhoneLabel.Text = Authorization.CurrentUser.PhoneNumber;
                    MainWindow.link.ProfilePage.EmailLabel.Text = Authorization.CurrentUser.Email;
                    var uriSource = new Uri(Authorization.CurrentUser.ImageURL, UriKind.Absolute);
                    MainWindow.link.ProfilePage.ImageObject.Source = new BitmapImage(uriSource);

                    if (Users.GetPage() != null)
                    {
                        Users.GetPage().UsersList.ItemsSource = null;
                        Users.GetPage().UsersList.ItemsSource = User.GetList();
                    }
                    Close();
                }
                
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Ошибка заполнения формы", MessageBoxButton.OK, MessageBoxImage.Warning);
                if(ex.Message.Contains("Invalid URI"))
                {
                    ErrorMessageBlock.Text = "* " + "Ссылка на изображение в неверном формате";
                }
                else
                {
                    ErrorMessageBlock.Text = "* " + ex.Message;
                }
                
            }
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
