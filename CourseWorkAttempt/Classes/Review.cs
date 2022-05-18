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
    public class Review
    {
        public int ID { get; set; }
        public User? User { get; set; }
        public Game? Game { get; set; }
        public string? Text { get; set; }

        public DateTime UploadDate { get; set; }
        public string? ShortUploadDate { get; set; }

        public int Rate { get; set; }

        public override string ToString()
        {
            return Text;
        }

        public static List<Review> GetTopGames(int userID)
        {
            using (SqlConnection connection = new SqlConnection(Authorization.connectionString))
            {
                connection.Open();
                string sqlExpression = @$"select top(5) Reviews.GameID, Users.Nickname, Users.UserID, Reviews.UploadDate, Reviews.Rating, Reviews.Text,
Games.GameName, Games.GameImage, Games.GameID
from reviews inner join Games on Reviews.GameID = Games.GameID inner join
users on Users.UserID = Reviews.UserID
where Users.UserID = {userID}
order by Rating desc";
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
                            var game = new Game();
                            game.Name = reader["GameName"] as string;
                            game.ImageURL = reader["GameImage"] as string;
                            game.ID = Convert.ToInt32(reader["GameID"]);
                            user.Nickname = reader["Nickname"] as string;
                            review.Game = game;
                            review.User = user;
                            review.Rate = Convert.ToInt32(reader["Rating"]);
                            review.Text = reader["Text"] as string;
                            DateTime uploadTime = Convert.ToDateTime(reader["UploadDate"].ToString());
                            review.UploadDate = uploadTime;
                            review.ShortUploadDate = uploadTime.ToShortDateString();
                            ReviewsCollection.Add(review);

                        }
                    }
                }
                return ReviewsCollection;
            }
        }

        public static List<Review> GetCurrentGameReviews(int gameID)
        {
            using (SqlConnection connection = new SqlConnection(Authorization.connectionString))
            {
                connection.Open();
                string sqlExpression = $"select Reviews.GameID, Users.Nickname, Reviews.UploadDate, Reviews.Rating, Reviews.Text from users inner join reviews on Users.UserID = Reviews.UserID where Reviews.GameID = {gameID} order by Reviews.UploadDate desc";
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
                            review.Rate = Convert.ToInt32(reader["Rating"]);
                            review.Text = reader["Text"] as string;
                            DateTime uploadTime = Convert.ToDateTime(reader["UploadDate"].ToString());
                            review.UploadDate = uploadTime;
                            review.ShortUploadDate = uploadTime.ToShortDateString();
                            ReviewsCollection.Add(review);
                            
                        }
                    }
                }
                return ReviewsCollection;
            }
        }

        public static bool AddReview(int gameID, string reviewText, int rate)
        {
            using (SqlConnection connection = new SqlConnection(Authorization.connectionString))
            {
                bool isSuccessful = false;
                connection.Open();
                //MessageBox.Show(DateTime.Now.ToShortDateString());
                string sqlExpression = $"insert into Reviews values({Authorization.CurrentUser.ID}, {gameID}, '{reviewText}', '{DateTime.Now.ToShortDateString()}', {rate})";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                try
                {
                    var state = command.ExecuteNonQuery();
                    MessageBox.Show("Отзыв добавлен!", "Новый отзыв", MessageBoxButton.OK, MessageBoxImage.Information);
                    isSuccessful = true;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    AddReviewWindow.link.ErrorMessageBlock.Text = "* " + ex.Message;
                }
                return isSuccessful;
            }
        }

        public static bool Update(int gameID, string text, int rating)
        {
            using (SqlConnection connection = new SqlConnection(Authorization.connectionString))
            {
                User updatedUser = Authorization.CurrentUser;
                bool isSuccessful = false;
                connection.Open();
                string sqlExpression = @$"update Reviews set UploadDate = '{DateTime.Now.ToShortDateString()}',
Text = '{text}',
Rating = {rating}
where GameID = {gameID} and UserID = {updatedUser.ID}";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                try
                {
                    var state = command.ExecuteNonQuery();
                    isSuccessful = true;
                    MessageBox.Show("Последний оставленный отзыв на игру был обновлен", "Обновление отзыва", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    AddReviewWindow.link.ErrorMessageBlock.Text = "* " + ex.Message;
                }
                return isSuccessful;
            }
        }

        public static bool IsExists(int gameID)
        {
            using (SqlConnection connection = new SqlConnection(Authorization.connectionString))
            {
                bool isSuccessful = false;
                connection.Open();
                //MessageBox.Show(DateTime.Now.ToShortDateString());
                string sqlExpression = $"select COUNT(ReviewID) from reviews where UserID = {Authorization.CurrentUser.ID} and GameID = {gameID}";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                try
                {
                    var state = Convert.ToInt32(command.ExecuteScalar());
                    
                    //MessageBox.Show("Отзыв добавлен!", "Новый отзыв", MessageBoxButton.OK, MessageBoxImage.Information);
                    //MessageBox.Show(Convert.ToString(state));
                    if(state > 0)
                    {
                        isSuccessful = true;
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    AddReviewWindow.link.ErrorMessageBlock.Text = "* " + ex.Message;
                }
                return isSuccessful;
            }
        }


        public static double GetAverageRate(int gameid)
        {
            using (SqlConnection connection = new SqlConnection(Authorization.connectionString))
            {
                double rate = 0;
                connection.Open();
                string sqlExpression = $"select AVG(Cast(rating as Float)) as rating from Reviews where GameID = {gameid}";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                try
                {
                    if(command.ExecuteScalar() is DBNull)
                    {
                        rate = -1.0;
                    }
                    else
                    {
                        var state = Convert.ToDouble(command.ExecuteScalar());
                        rate = state;
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    //AddReviewWindow.link.ErrorMessageBlock.Text = "* " + ex.Message;
                }
                if(rate > 0)
                {
                    return Math.Round(rate, 1);
                }
                else
                {
                    return -1.0;
                }
                
            }
        }

    }
}
