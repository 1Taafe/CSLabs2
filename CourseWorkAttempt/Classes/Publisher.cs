using CourseWorkAttempt.Auth;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseWorkAttempt.Classes
{
    public class Publisher
    {
        public int ID { get; set; }
        public string? Name { get; set;}
        public string? Country { get; set; }

        public override string ToString()
        {
            return Name + " " + Country;
        }

        public static bool IsExists(string pubName)
        {
            using (SqlConnection connection = new SqlConnection(Authorization.connectionString))
            {
                bool isSuccessful = false;
                connection.Open();
                string sqlExpression = $"select count(PublisherName) from Publishers where PublisherName = '{pubName}'";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                try
                {
                    var state = Convert.ToInt32(command.ExecuteScalar());
                    if (state > 0)
                    {
                        isSuccessful = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    //AddReviewWindow.link.ErrorMessageBlock.Text = "* " + ex.Message;
                }
                return isSuccessful;
            }
        }

        public static bool Add(string name, string country)
        {
            using (SqlConnection connection = new SqlConnection(Authorization.connectionString))
            {
                bool isSuccessful = false;
                connection.Open();
                //MessageBox.Show(DateTime.Now.ToShortDateString());
                string sqlExpression = $"insert into Publishers values('{name}', '{country}')";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                try
                {
                    var state = command.ExecuteNonQuery();
                    //MessageBox.Show("Игра добавлена!", "Новая игра", MessageBoxButton.OK, MessageBoxImage.Information);
                    isSuccessful = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    //AddGameWindow.link.ErrorMessageBlock.Text = "* " + ex.Message;
                }
                return isSuccessful;
            }
        }

        public static int GetID(string pubName)
        {
            using (SqlConnection connection = new SqlConnection(Authorization.connectionString))
            {
                int id = 0;
                connection.Open();
                string sqlExpression = $"select PublisherID from Publishers where PublisherName = '{pubName}'";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    if (reader.HasRows) // если есть данные
                    {
                        if (reader.Read()) // построчно считываем данные
                        {
                            id = (int)reader["PublisherID"];
                        }
                    }
                }
                return id;
            }
        }

    }
}
