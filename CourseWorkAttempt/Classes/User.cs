using CourseWorkAttempt.Auth;
using CourseWorkAttempt.Windows;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseWorkAttempt.Classes
{
    public class User
    {
        public int ID { get; set; }
        public string? Nickname { get; set; }

        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public bool IsAdmin { get; set; }
        
        public string? ImageURL { get; set; }

        public override string ToString()
        {
            return $"{ID} {Nickname} {Name} {Surname} {Email}";
        }

        public string ToNickname()
        {
            return Nickname;
        }

        public static bool UpdateUser()
        {
            using (SqlConnection connection = new SqlConnection(Authorization.connectionString))
            {
                User updatedUser = Authorization.CurrentUser;
                bool isSuccessful = false;
                connection.Open();
                string sqlExpression = @$"update Users set 
Nickname = @nickname,
Password = @password,
Surname = @surname,
Name = @name,
Email = @email,
PhoneNumber = @phone,
UserImage = @image
where UserID = @userID";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add(new SqlParameter("@nickname", updatedUser.Nickname));
                command.Parameters.Add(new SqlParameter("@password", updatedUser.Password));
                command.Parameters.Add(new SqlParameter("@surname", updatedUser.Surname));
                command.Parameters.Add(new SqlParameter("@name", updatedUser.Name));
                command.Parameters.Add(new SqlParameter("@email", updatedUser.Email));
                command.Parameters.Add(new SqlParameter("@phone", updatedUser.PhoneNumber));
                command.Parameters.Add(new SqlParameter("@image", updatedUser.ImageURL));
                command.Parameters.Add(new SqlParameter("@userID", updatedUser.ID));
                try
                {
                    var state = command.ExecuteNonQuery();
                    isSuccessful = true;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    if (ex.Message.Contains("\"UQ_Nickname\""))
                    {
                        EditProfileWindow.link.ErrorMessageBlock.Text = "* " + "Данное имя пользователя уже используется и не доступно. Введите другое имя (Nickname) и повторите попытку";
                    }
                    else
                    {
                        EditProfileWindow.link.ErrorMessageBlock.Text = "* " + ex.Message;
                    }
                    
                }
                return isSuccessful;
            }
        }

        public static List<User> GetList()
        {
            using (SqlConnection connection = new SqlConnection(Authorization.connectionString))
            {
                connection.Open();
                string sqlExpression = $"select * from Users";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                List<User> usersCollection = new();
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            var user = new User();
                            user.ID = (int)reader["UserID"];
                            user.Nickname = reader["Nickname"] as string;
                            user.Name = reader["Name"] as string;
                            user.Surname = reader["Surname"] as string;
                            user.PhoneNumber = reader["PhoneNumber"] as string;
                            user.Email = reader["Email"] as string;
                            user.IsAdmin = (bool)reader["IsAdmin"];
                            user.ImageURL = reader["UserImage"] as string;
                            usersCollection.Add(user);
                            //var game = new Game();
                            //var publisher = new Publisher();
                            //var developer = new Developer();
                            //publisher.ID = (int)reader["PublisherID"];
                            //publisher.Name = reader["PublisherName"] as string;
                            //publisher.Country = reader["PublisherCountry"] as string;

                            //developer.ID = (int)reader["DeveloperID"];
                            //developer.Name = reader["DeveloperName"] as string;
                            //developer.Country = reader["DeveloperCountry"] as string;

                            //game.ID = (int)reader["GameID"];
                            //game.Developer = developer;
                            //game.Publisher = publisher;
                            //game.Name = reader["GameName"] as string;
                            //game.Description = reader["Description"] as string;
                            //game.Genre = reader["Genre"] as string;
                            //game.ImageURL = reader["GameImage"] as string;
                            //game.Platform = reader["Platform"] as string;
                            //game.BuyURL = reader["BuyURL"] as string;

                            //DateTime releaseDate = Convert.ToDateTime(reader["ReleaseDate"].ToString());
                            //game.ReleaseDate = releaseDate;
                            //GamesCollection.Add(game);
                        }
                    }
                }
                return usersCollection;
            }
        }
    }
}
