using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CourseWorkAttempt.Classes;
using Microsoft.Data.SqlClient;

namespace CourseWorkAttempt.Auth
{
    public static class Login
    {
        static string connectionString = "Server=.;Database=Agregato;Encrypt=False;Trusted_Connection=True;";
        public static User? CurrentUser;
        public static bool TryToConnect(string nickname, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = $"SELECT * FROM Users WHERE Password = '{password}' and Nickname = '{nickname}'";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
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
                            CurrentUser = new User();
                            CurrentUser.ID = (int)ID;
                            CurrentUser.Nickname = Nickname as string;
                            CurrentUser.Name = Name as string;
                            CurrentUser.Surname = Surname as string;
                            CurrentUser.Password = Password as string;
                            CurrentUser.PhoneNumber = PhoneNumber as string;
                            CurrentUser.Email = Email as string;
                            CurrentUser.IsAdmin = (bool)isAdmin;
                            MessageBox.Show(CurrentUser.ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ты хто такой?");
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
