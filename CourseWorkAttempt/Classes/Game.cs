using CourseWorkAttempt.Auth;
using CourseWorkAttempt.Pages;
using CourseWorkAttempt.Windows;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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

        public static List<ComboBoxItem> GetGenres()
        {
            using (SqlConnection connection = new SqlConnection(Authorization.connectionString))
            {
                connection.Open();
                string sqlExpression = $"select * from genres";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                List<ComboBoxItem> genreCollection = new();
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            string genre = reader["GenreName"] as string;
                            ComboBoxItem item = new();
                            item.Content = genre;
                            genreCollection.Add(item);
                        }
                    }
                }
                return genreCollection;
            }
        }

        public static List<ComboBoxItem> GetGenresWithAll()
        {
            using (SqlConnection connection = new SqlConnection(Authorization.connectionString))
            {
                connection.Open();
                string sqlExpression = $"select * from genres";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                List<ComboBoxItem> genreCollection = new();
                ComboBoxItem fitem = new();
                fitem.Content = "Все";
                genreCollection.Add(fitem);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            string genre = reader["GenreName"] as string;
                            ComboBoxItem item = new();
                            item.Content = genre;
                            genreCollection.Add(item);
                        }
                    }
                }
                return genreCollection;
            }
        }

        public static bool AddGenre(string genre)
        {
            using (SqlConnection connection = new SqlConnection(Authorization.connectionString))
            {
                bool isSuccessful = false;
                connection.Open();
                string sqlExpression = @$"insert into Genres values(@genre)";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add(new SqlParameter("@genre", genre));
                try
                {
                    var state = command.ExecuteNonQuery();
                    MessageBox.Show("Жанр добавлен!", "Новая жанр", MessageBoxButton.OK, MessageBoxImage.Information);
                    isSuccessful = true;
                    if (AddGameWindow.link != null)
                    {
                        AddGameWindow.link.GenreBox.ItemsSource = GetGenres();
                    }
                    Games.GetPage().GameList.ItemsSource = null;
                    Games.GetPage().GameList.ItemsSource = GetList();
                    Games.GetPage().GenreBox.ItemsSource = GetGenresWithAll();
                    Games.GetPage().GenreBox.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    if (ex.Message.Contains("UNIQUE"))
                    {
                        AddGameWindow.link.ErrorMessageBlock.Text = "* Жанр уже находится в базе данных";
                    }
                    else
                    {
                        AddGameWindow.link.ErrorMessageBlock.Text = "* " + ex.Message;
                    }

                }
                return isSuccessful;
            }
        }

        public static bool DeleteGenre(string genre)
        {
            using (SqlConnection connection = new SqlConnection(Authorization.connectionString))
            {
                bool isSuccessful = false;
                connection.Open();
                string sqlExpression = @$"delete from Genres where GenreName = @genre";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add(new SqlParameter("@genre", genre));
                try
                {
                    var state = command.ExecuteNonQuery();
                    MessageBox.Show("Жанр удален!", "Удаление жанра", MessageBoxButton.OK, MessageBoxImage.Information);
                    isSuccessful = true;
                    if (AddGameWindow.link != null)
                    {
                        AddGameWindow.link.GenreBox.ItemsSource = GetGenres();
                    }
                    Games.GetPage().GameList.ItemsSource = null;
                    Games.GetPage().GameList.ItemsSource = GetList();
                    Games.GetPage().GenreBox.ItemsSource = GetGenresWithAll();
                    Games.GetPage().GenreBox.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    if (ex.Message.Contains("UNIQUE"))
                    {
                        AddGameWindow.link.ErrorMessageBlock.Text = "* Жанр уже находится в базе данных";
                    }
                    else
                    {
                        AddGameWindow.link.ErrorMessageBlock.Text = "* " + ex.Message;
                    }

                }
                return isSuccessful;
            }
        }



        public static bool AddPlatform(string platform)
        {
            using (SqlConnection connection = new SqlConnection(Authorization.connectionString))
            {
                bool isSuccessful = false;
                connection.Open();
                string sqlExpression = @$"insert into Platforms values(@platform)";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add(new SqlParameter("@platform", platform));
                try
                {
                    var state = command.ExecuteNonQuery();
                    MessageBox.Show("Платформа добавлена!", "Новая платформа", MessageBoxButton.OK, MessageBoxImage.Information);
                    isSuccessful = true;
                    if (AddGameWindow.link != null)
                    {
                        AddGameWindow.link.PlatformBox.ItemsSource = GetPlatforms();
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    if (ex.Message.Contains("UNIQUE"))
                    {
                        AddGameWindow.link.ErrorMessageBlock.Text = "* Платформа уже находится в базе данных";
                    }
                    else
                    {
                        AddGameWindow.link.ErrorMessageBlock.Text = "* " + ex.Message;
                    }

                }
                return isSuccessful;
            }
        }

        public static bool DeletePlatform(string platform)
        {
            using (SqlConnection connection = new SqlConnection(Authorization.connectionString))
            {
                bool isSuccessful = false;
                connection.Open();
                string sqlExpression = @$"delete from Platforms where PlatformName = @platform";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add(new SqlParameter("@platform", platform));
                try
                {
                    var state = command.ExecuteNonQuery();
                    MessageBox.Show("Платформа удалена!", "Удаление платформы", MessageBoxButton.OK, MessageBoxImage.Information);
                    isSuccessful = true;
                    if (AddGameWindow.link != null)
                    {
                        AddGameWindow.link.PlatformBox.ItemsSource = GetPlatforms();
                    }
                    Games.GetPage().GameList.ItemsSource = null;
                    Games.GetPage().GameList.ItemsSource = GetList();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    if (ex.Message.Contains("UNIQUE"))
                    {
                        AddGameWindow.link.ErrorMessageBlock.Text = "* Платформа уже находится в базе данных";
                    }
                    else
                    {
                        AddGameWindow.link.ErrorMessageBlock.Text = "* " + ex.Message;
                    }

                }
                return isSuccessful;
            }
        }


        public static List<ComboBoxItem> GetPlatforms()
        {
            using (SqlConnection connection = new SqlConnection(Authorization.connectionString))
            {
                connection.Open();
                string sqlExpression = $"select * from platforms";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                List<ComboBoxItem> platformCollection = new();
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            string platform = reader["PlatformName"] as string;
                            ComboBoxItem item = new();
                            item.Content = platform;
                            platformCollection.Add(item);
                        }
                    }
                }
                return platformCollection;
            }
        }

        public static List<Game> GetList()
        {
            using (SqlConnection connection = new SqlConnection(Authorization.connectionString))
            {
                connection.Open();
                string sqlExpression = @$"select * from Games 
inner join Developers on Games.DeveloperID = Developers.DeveloperID
inner join Publishers on Publishers.PublisherID = Games.PublisherID
inner join Genres on Genres.GenreID = Games.GenreID
inner join Platforms on Platforms.PlatformID = Games.PlatformID";
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
                            game.Genre = reader["GenreName"] as string;
                            game.ImageURL = reader["GameImage"] as string;
                            game.Platform = reader["PlatformName"] as string;
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
                string sqlExpression = @$"insert into Games values(@name, @releaseDate, 
@description, @buyURL, @publisherID, @developerID, @image, @genreID, @platformID)";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add(new SqlParameter("@name", game.Name));
                command.Parameters.Add(new SqlParameter("@releaseDate", game.ReleaseDate));
                command.Parameters.Add(new SqlParameter("@description", game.Description));
                command.Parameters.Add(new SqlParameter("@buyURL", game.BuyURL));
                command.Parameters.Add(new SqlParameter("@publisherID", game.Publisher.ID));
                command.Parameters.Add(new SqlParameter("@developerID", game.Developer.ID));
                command.Parameters.Add(new SqlParameter("@image", game.ImageURL));

                int platformID = -1, genreID = -1;
                string platformSql = "select PlatformID, GenreID from Platforms, Genres where PlatformName = @platform and GenreName = @genre";
                var platformCommand = new SqlCommand(platformSql, connection);
                platformCommand.Parameters.Add(new SqlParameter("@platform", game.Platform));
                platformCommand.Parameters.Add(new SqlParameter("@genre", game.Genre));
                using (SqlDataReader reader = platformCommand.ExecuteReader())
                {

                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            platformID = (int)reader["PlatformID"];
                            genreID = (int)reader["GenreID"];
                        }
                    }
                }

                command.Parameters.Add(new SqlParameter("@platformID", platformID));
                command.Parameters.Add(new SqlParameter("@genreID", genreID));
                try
                {
                    var state = command.ExecuteNonQuery();
                    MessageBox.Show("Игра добавлена!", "Новая игра", MessageBoxButton.OK, MessageBoxImage.Information);
                    isSuccessful = true;
                    Games.GetPage().GameList.ItemsSource = null;
                    Games.GetPage().GameList.ItemsSource = GetList();
                    Games.GetPage().GenreBox.ItemsSource = GetGenresWithAll();
                    Games.GetPage().GenreBox.SelectedIndex = 0;
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
                string sqlExpression = $"delete Games where GameID = @id";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add(new SqlParameter("@id", id));
                try
                {
                    var state = command.ExecuteNonQuery();
                    MessageBox.Show("Игра удалена!", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                    isSuccessful = true;
                    Games.GetPage().GameList.ItemsSource = null;
                    Games.GetPage().GameList.ItemsSource = GetList();
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
