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

        public static DataTable Get(string sql)
        {
            SqlConnection connection = null;
            DataTable table = new();
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                connection.Open();
                adapter.Fill(table);
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
            return table;
        }

        public static void Update(DataTable dt) { 
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(dt);
            dt.Clear();
            adapter.Fill(dt);
        }

        public static void Execute(string sql)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = sql;
                    command.Connection = connection;
                    // выполняем команду
                    int temp = command.ExecuteNonQuery();
                    MessageBox.Show($"Команда выполнена. \n Кол-во затронутых строк {temp}", "База данных", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        public static void ExecuteTwo(string sql1, string sql2)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                try
                {
                    command.CommandText = sql1;
                    int res = 0;
                    res += command.ExecuteNonQuery();
                    command.CommandText = sql2;
                    res += command.ExecuteNonQuery();

                    // подтверждаем транзакцию
                    transaction.Commit();
                    MessageBox.Show($"Команда выполнена. \n Кол-во затронутых строк {res}", "База данных", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    transaction.Rollback();
                    MessageBox.Show($"Произошел откат транзакции!", "База данных", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }
    }
}
