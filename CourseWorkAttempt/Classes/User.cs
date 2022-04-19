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

        public override string ToString()
        {
            return $"{ID} {Nickname} {Name} {Surname} {Password} {PhoneNumber} {Email} {IsAdmin}";
        }

        public static bool UpdateUser()
        {
            using (SqlConnection connection = new SqlConnection(Authorization.connectionString))
            {
                User updatedUser = Authorization.CurrentUser;
                bool isSuccessful = false;
                connection.Open();
                string sqlExpression = @$"update Users set 
Nickname = '{updatedUser.Nickname}',
Password = '{updatedUser.Password}',
Surname = '{updatedUser.Surname}',
Name = '{updatedUser.Name}',
Email = '{updatedUser.Email}',
PhoneNumber = '{updatedUser.PhoneNumber}'
where UserID = {updatedUser.ID}";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                try
                {
                    var state = command.ExecuteNonQuery();
                    isSuccessful = true;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    EditProfileWindow.link.ErrorMessageBlock.Text = "* " + ex.Message;
                }
                return isSuccessful;
            }
        }
    }
}
