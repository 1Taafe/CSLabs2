using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;

namespace lab10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable dt = new DataTable();
        public MainWindow()
        {
            InitializeComponent();
            //TableComboBox.SelectedIndex = 0;
        }

        private void TableComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SaveButton.IsEnabled = true;
            UpdateButton.IsEnabled = true;
            string sql;
            switch (TableComboBox.SelectedIndex)
            {
                case 0:
                    sql = "select * from Games";
                    dt = Database.Get(sql);

                    ObservableCollection<MyImage> items = new ObservableCollection<MyImage>();

                    foreach (DataRow r in dt.Rows)
                    {
                        items.Add(new MyImage()
                        {
                            Image = new BitmapImage(new Uri(r[9] as string, UriKind.Absolute))
                        }) ;
                    }
                    //dataGrid2.ItemsSource = null;
                    
                    dataGrid2.ItemsSource = items;
                    dataGrid.ItemsSource = dt.DefaultView;
                    break;
                case 1:
                    sql = "select * from Developers";
                    dt = Database.Get(sql);
                    dataGrid2.ItemsSource = null;
                    dataGrid.ItemsSource = dt.DefaultView;
                    break;
                case 2:
                    sql = "select * from Publishers";
                    dt = Database.Get(sql);
                    dataGrid2.ItemsSource = null;
                    dataGrid.ItemsSource = dt.DefaultView;
                    break;
                case 3:
                    sql = "select * from Reviews";
                    dt = Database.Get(sql);
                    dataGrid2.ItemsSource = null;
                    dataGrid.ItemsSource = dt.DefaultView;
                    break;
                case 4:
                    sql = "select * from Users";
                    dt = Database.Get(sql);
                    dataGrid2.ItemsSource = null;
                    dataGrid.ItemsSource = dt.DefaultView;
                    break;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Database.Update(dt);
                MessageBox.Show("Сохранение изменений выполнено успешно!", "База данных", MessageBoxButton.OK, MessageBoxImage.Information);
            } 
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedIndex != dataGrid.Items.Count - 1)
            {
                dataGrid.SelectedIndex++;
            }
            else
            {
                if (TableComboBox.SelectedIndex == 4)
                {
                    TableComboBox.SelectedIndex = 0;
                }
                else if(TableComboBox.SelectedIndex < 4)
                {
                    TableComboBox.SelectedIndex++;
                }
            }
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            if(dataGrid.SelectedIndex != -1)
            {
                dataGrid.SelectedIndex--;
            }
            else
            {
                if(TableComboBox.SelectedIndex > 0)
                {
                    TableComboBox.SelectedIndex--;
                    dataGrid.SelectedIndex = dataGrid.Items.Count - 1;
                }
                
            }
        }

        private void SqlButton_Click(object sender, RoutedEventArgs e)
        {
            dataGrid2.ItemsSource = null;
            if (SqlCheck.IsChecked == false)
            {
                string sql = SqlBox.Text;
                if (string.IsNullOrEmpty(sql))
                {
                    MessageBox.Show("Введите запрос!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (sql.Split(' ')[0].ToLower() == "select")
                {
                    dt = Database.Get(sql);
                    TableComboBox.SelectedIndex = 5;
                    dataGrid.ItemsSource = dt.DefaultView;
                    SaveButton.IsEnabled = false;
                    UpdateButton.IsEnabled = false;
                }
                else
                {
                    Database.Execute(sql);
                }
            }
            else
            {
                string sql1 = SqlBox.Text;
                string sql2 = SqlBox2.Text;
                if (sql1.Split(' ')[0].ToLower() == "select" || sql2.Split(' ')[0].ToLower() == "select")
                {
                    MessageBox.Show("Транзакция недоступна для SELECT запросов.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Database.ExecuteTwo(sql1, sql2);
                }
            }
            
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string sql;
            switch (TableComboBox.SelectedIndex)
            {
                case 0:
                    sql = "select * from Games";
                    dt = Database.Get(sql);

                    ObservableCollection<MyImage> items = new ObservableCollection<MyImage>();

                    foreach (DataRow r in dt.Rows)
                    {
                        items.Add(new MyImage()
                        {
                            Image = new BitmapImage(new Uri(r[9] as string, UriKind.Absolute))
                        });
                    }
                    //dataGrid2.ItemsSource = null;

                    dataGrid2.ItemsSource = items;
                    dataGrid.ItemsSource = dt.DefaultView;
                    break;
                case 1:
                    sql = "select * from Developers";
                    dt = Database.Get(sql);
                    dataGrid2.ItemsSource = null;
                    dataGrid.ItemsSource = dt.DefaultView;
                    break;
                case 2:
                    sql = "select * from Publishers";
                    dt = Database.Get(sql);
                    dataGrid2.ItemsSource = null;
                    dataGrid.ItemsSource = dt.DefaultView;
                    break;
                case 3:
                    sql = "select * from Reviews";
                    dt = Database.Get(sql);
                    dataGrid2.ItemsSource = null;
                    dataGrid.ItemsSource = dt.DefaultView;
                    break;
                case 4:
                    sql = "select * from Users";
                    dt = Database.Get(sql);
                    dataGrid2.ItemsSource = null;
                    dataGrid.ItemsSource = dt.DefaultView;
                    break;
            }
        }

        private void SqlCheck_Checked(object sender, RoutedEventArgs e)
        {
            SqlBox2.IsEnabled = true;
        }

        private void SqlCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            SqlBox2.IsEnabled = false;
        }
    }
}
