using CourseWorkAttempt.Auth;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkAttempt.Classes
{
    public class Review
    {
        public int ID { get; set; }
        public User? User { get; set; }
        public Game? Game { get; set; }
        public string? Text { get; set; }

        public DateTime UploadDate { get; set; }

        public int Rate { get; set; }

        public static List<Review> GetList()
        {
            using (SqlConnection connection = new SqlConnection(Authorization.connectionString))
            {
                connection.Open();
                string sqlExpression = $"select Users.Nickname, Reviews.UploadDate, Reviews.Rating, Reviews.Text from users inner join reviews on Users.UserID = Reviews.UserID";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                List<Review> ReviewsCollection = new();
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            var review = new Review();
                            var user = new User();
                            user.Nickname = reader["Nickname"] as string;
                            review.User = user;
                            review.Rate = (int)reader["Rating"];
                            review.Text = reader["Text"] as string;

                            
                            /*var game = new Game();
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
                            GamesCollection.Add(game);*/
                        }
                    }
                }
                return ReviewsCollection;
            }
        }
    }
}
