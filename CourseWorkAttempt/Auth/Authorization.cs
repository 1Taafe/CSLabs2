using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CourseWorkAttempt.Classes;
using CourseWorkAttempt.Pages;
using CourseWorkAttempt.Windows;
using Microsoft.Data.SqlClient;

namespace CourseWorkAttempt.Auth
{
    public static class Authorization
    {
        public static string connectionString = "Server=.;Database=Agregato;Encrypt=False;Trusted_Connection=True;";
        public static User? CurrentUser;

        public static async void CheckConnection(object sender, EventArgs e)
        {
            var client = new HttpClient();
            try
            {
                var result = await client.GetAsync("http://google.com");
                if (result.StatusCode.ToString() != "OK")
                {
                    MainWindow.link.StatusBlock.Text = "Оффлайн режим \n Изображения недоступны";
                }
                else
                {
                    MainWindow.link.StatusBlock.Text = "";
                }
            }
            catch
            {
                MainWindow.link.StatusBlock.Text = "Оффлайн режим \n Изображения недоступны";
            }
            
        }
        public static bool TryToLogin(string nickname, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string passwordHash = Crypto.GetHash(password);
                connection.Open();
                string sqlExpression = $"SELECT * FROM Users WHERE Password = @passwordHash and Nickname = @nickname";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add(new SqlParameter("@passwordHash", passwordHash));
                command.Parameters.Add(new SqlParameter("@nickname", nickname));
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        if (reader.Read()) // построчно считываем данные
                        {
                            object ID = reader["UserID"];
                            object Nickname = reader["Nickname"];
                            object Name = reader["Name"];
                            object Surname = reader["Surname"];
                            object Password = reader["Password"];
                            object PhoneNumber = reader["PhoneNumber"];
                            object Email = reader["Email"];
                            object isAdmin = reader["isAdmin"];
                            object ImageURL = reader["UserImage"];
                            CurrentUser = new User();
                            CurrentUser.ID = (int)ID;
                            CurrentUser.Nickname = Nickname as string;
                            CurrentUser.Name = Name as string;
                            CurrentUser.Surname = Surname as string;
                            CurrentUser.Password = Password as string;
                            CurrentUser.PhoneNumber = PhoneNumber as string;
                            CurrentUser.Email = Email as string;
                            CurrentUser.IsAdmin = (bool)isAdmin;
                            CurrentUser.ImageURL = ImageURL as string;
                        }
                    }
                    else
                    {
                        MainPage.GetPage().ErrorBlock.Text = "* Неверный логин или пароль";
                    }
                }
                if(CurrentUser != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool RegisterAccount(User newUser)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                bool isSuccessful = false;
                connection.Open();
                string sqlExpression = "Insert into Users values (@nickname, @password, @surname, @name, @email, @phone, 0, @image)";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add(new SqlParameter("@nickname", newUser.Nickname));
                command.Parameters.Add(new SqlParameter("@password", newUser.Password));
                command.Parameters.Add(new SqlParameter("@surname", newUser.Surname));
                command.Parameters.Add(new SqlParameter("@name", newUser.Name));
                command.Parameters.Add(new SqlParameter("@email", newUser.Email));
                command.Parameters.Add(new SqlParameter("@phone", newUser.PhoneNumber));
                command.Parameters.Add(new SqlParameter("@image", newUser.ImageURL));
                try
                {
                    var state = command.ExecuteNonQuery();
                    MessageBox.Show("Новый пользователь добавлен!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
                    isSuccessful = true;
                }
                catch(Exception ex)
                {
                    if (ex.Message.Contains("\"UQ_Nickname\""))
                    {
                        RegisterWindow.link.ErrorMessageBlock.Text = "* " + "Данное имя пользователя уже используется и не доступно. Введите другое имя (Nickname) и повторите попытку";
                    }
                    else
                    {
                        RegisterWindow.link.ErrorMessageBlock.Text = "* " + ex.Message;
                    }
                    
                }
                return isSuccessful;
            }
        }

        public static bool DeleteAccount()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                bool isSuccessful = false;
                connection.Open();
                string sqlExpression = $"delete from users where Nickname = @nickname";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add(new SqlParameter("@nickname", CurrentUser.Nickname));
                try
                {
                    var state = command.ExecuteNonQuery();
                    MessageBox.Show("Учетная запись удалена", "Удаления профиля", MessageBoxButton.OK, MessageBoxImage.Information);
                    isSuccessful = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                return isSuccessful;
            }
        }

        public static bool Disconnect()
        {
            if (CurrentUser != null)
            {
                CurrentUser = null;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
