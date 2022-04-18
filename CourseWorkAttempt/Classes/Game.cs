using CourseWorkAttempt.Auth;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkAttempt.Classes
{
    public class Game
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Description { get; set; }
        public string? BuyURL { get; set; }
        public Publisher? Publisher { get; set; }
        public Developer? Developer { get; set; }
        public string? Genre { get; set; }
        public string? Platform { get; set; }

        public string? ImageURL { get; set; }

        //public static List<Game> Collection = new List<Game>();
        static Game()
        {

        }
        public static List<Game> GetList()
        {
            using (SqlConnection connection = new SqlConnection(Authorization.connectionString))
            {
                connection.Open();
                string sqlExpression = $"select * from Games inner join Developers on Games.DeveloperID = Developers.DeveloperID inner join Publishers on Publishers.PublisherID = Games.PublisherID";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                List<Game> GamesCollection = new();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    
                    if (reader.HasRows) // если есть данные
                    {
                        if (reader.Read()) // построчно считываем данные
                        {
                            var game = new Game();
                            var publisher = new Publisher();
                            var developer = new Developer();
                            publisher.ID = (int)reader["PublisherID"];
                            publisher.Name = reader["PublisherName"] as string;
                            publisher.Country = reader["PublisherCountry"] as string;

                            developer.ID = (int)reader["DeveloperID"];
                            developer.Name = reader["DeveloperName"] as string;
                            developer.Country = reader["DeveloperCountry"] as string;

                            game.ID = (int)reader["GameID"];
                            game.Developer = developer;
                            game.Publisher = publisher;
                            game.Name = reader["GameName"] as string;
                            game.Description = reader["Description"] as string;
                            game.Genre = reader["Genre"] as string;
                            game.ImageURL = reader["GameImage"] as string;
                            game.Platform = reader["Platform"] as string;
                            game.BuyURL = reader["BuyURL"] as string;

                            DateTime releaseDate = Convert.ToDateTime(reader["ReleaseDate"].ToString());
                            game.ReleaseDate = releaseDate;
                            GamesCollection.Add(game);
                            /*object ID = reader["UserID"];
                            object Nickname = reader["Nickname"];
                            object Name = reader["Name"];
                            object Surname = reader["Surname"];
                            object Password = reader["Password"];
                            object PhoneNumber = reader["PhoneNumber"];
                            object Email = reader["Email"];
                            object isAdmin = reader["isAdmin"];
                            CurrentUser = new User();
                            CurrentUser.ID = (int)ID;
                            CurrentUser.Nickname = Nickname as string;
                            CurrentUser.Name = Name as string;
                            CurrentUser.Surname = Surname as string;
                            CurrentUser.Password = Password as string;
                            CurrentUser.PhoneNumber = PhoneNumber as string;
                            CurrentUser.Email = Email as string;
                            CurrentUser.IsAdmin = (bool)isAdmin;*/
                            //MessageBox.Show(CurrentUser.ToString());
                        }
                    }
                    else
                    {
                        //MessageBox.Show("Ты хто такой?");
                        
                    }
                }
                return GamesCollection;
            }
        }
    }
}
