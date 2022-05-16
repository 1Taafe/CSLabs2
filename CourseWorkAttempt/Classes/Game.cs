using CourseWorkAttempt.Auth;
using CourseWorkAttempt.Pages;
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
        public override string ToString()
        {
            return Name + " " + Genre + " " + Platform;
        }

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
                        while (reader.Read()) // построчно считываем данные
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
                        }
                    }
                }
                return GamesCollection;
            }
        }

        public static bool AddGame(Game game)
        {
            using (SqlConnection connection = new SqlConnection(Authorization.connectionString))
            {
                bool isSuccessful = false;
                connection.Open();
                string sqlExpression = @$"insert into Games values('{game.Name}', '{game.ReleaseDate}', 
'{game.Description}', '{game.BuyURL}', {game.Publisher.ID}, {game.Developer.ID}, '{game.Platform}', '{game.Genre}', '{game.ImageURL}')";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                try
                {
                    var state = command.ExecuteNonQuery();
                    MessageBox.Show("Игра добавлена!", "Новая игра", MessageBoxButton.OK, MessageBoxImage.Information);
                    isSuccessful = true;
                    Games.link.GameList.ItemsSource = null;
                    Games.link.GameList.ItemsSource = GetList();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    if (ex.Message.Contains("UNIQUE"))
                    {
                        AddGameWindow.link.ErrorMessageBlock.Text = "* Игра с таким названием уже находится в базе данных";
                    }
                    else
                    {
                        AddGameWindow.link.ErrorMessageBlock.Text = "* " + ex.Message;
                    }
                    
                }
                return isSuccessful;
            }
        }

        public static bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(Authorization.connectionString))
            {
                bool isSuccessful = false;
                connection.Open();
                string sqlExpression = $"delete Games where GameID = {id}";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                try
                {
                    var state = command.ExecuteNonQuery();
                    MessageBox.Show("Игра удалена!", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                    isSuccessful = true;
                    Games.link.GameList.ItemsSource = null;
                    Games.link.GameList.ItemsSource = GetList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                return isSuccessful;
            }
        }
    }
}
