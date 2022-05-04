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

namespace lab10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //TableComboBox.SelectedIndex = 0;
        }

        private void TableComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string sql;
            switch (TableComboBox.SelectedIndex)
            {
                case 0:
                    sql = "select * from Games";
                    dataGrid.ItemsSource = Database.GetGames(sql).DefaultView;
                    break;
                case 1:
                    sql = "select * from Developers";
                    dataGrid.ItemsSource = Database.GetGames(sql).DefaultView;
                    break;
                case 2:
                    sql = "select * from Publishers";
                    dataGrid.ItemsSource = Database.GetGames(sql).DefaultView;
                    break;
            }
        }
    }
}
