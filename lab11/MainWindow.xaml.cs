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

namespace lab11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow? link;
        public MainWindow()
        {
            InitializeComponent();
            link = this;
            Agregato.Open();
        }

        private void TableSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(TableSelector.SelectedIndex != -1)
            {
                var item = TableSelector.SelectedItem as ComboBoxItem;
                string tableName = item.Content.ToString();
                if(tableName == "Users")
                {
                    Agregato.GetUsers();
                }
                else if (tableName == "Reviews")
                {
                    Agregato.GetReviews();
                }
                else if (tableName == "Games")
                {
                    Agregato.GetGames();
                }
                else if (tableName == "Developers")
                {
                    Agregato.GetDevelopers();
                }
                else if (tableName == "Publishers")
                {
                    Agregato.GetPublishers();
                }
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Agregato.SaveChanges();
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Agregato.Close();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Agregato.SearchByDevAndPub(DeveloperBox.Text, PublisherBox.Text);
        }

        private void PublisherBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
