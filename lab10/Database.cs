using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Windows;

namespace lab10
{
    public static class Database
    {
        public static string? connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static SqlDataAdapter? adapter;

        public static DataTable GetGames(string sql)
        {
            SqlConnection connection = null;
            DataTable gamesTable = new();
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                connection.Open();
                adapter.Fill(gamesTable);
                //dataGrid.ItemsSource = gamesTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }       
            }
            return gamesTable;
        }

        public static void UpdateDB() { }
    }
}
