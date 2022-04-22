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
    }
}
