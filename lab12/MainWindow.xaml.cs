using lab11.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private UnitOfWork unit = new UnitOfWork();
        public MainWindow()
        {
            InitializeComponent();
            link = this;
        }

        private void TableSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(TableSelector.SelectedIndex != -1)
            {
                var item = TableSelector.SelectedItem as ComboBoxItem;
                string tableName = item.Content.ToString();
                if(tableName == "Users")
                {
                    unit.UserRepository.GetList();
                }
                else if (tableName == "Reviews")
                {
                    unit.ReviewRepository.GetList();
                }
                else if (tableName == "Games")
                {
                    unit.GameRepository.GetList();
                }
                else if (tableName == "Developers")
                {
                    unit.DeveloperRepository.GetList();
                }
                else if (tableName == "Publishers")
                {
                    unit.PublisherRepository.GetList();
                }
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            unit.Save();
            var item = TableSelector.SelectedItem as ComboBoxItem;
            string tableName = item.Content.ToString();
            if (tableName == "Users")
            {
                OutputTable.ItemsSource = null;
                unit.UserRepository.GetList();
            }
            else if (tableName == "Reviews")
            {
                OutputTable.ItemsSource = null;
                unit.ReviewRepository.GetList();
            }
            else if (tableName == "Games")
            {
                OutputTable.ItemsSource = null;
                unit.GameRepository.GetList();
            }
            else if (tableName == "Developers")
            {
                OutputTable.ItemsSource = null;
                unit.DeveloperRepository.GetList();
            }
            else if (tableName == "Publishers")
            {
                OutputTable.ItemsSource = null;
                unit.PublisherRepository.GetList();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            unit.Dispose();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            unit.SearchByDevAndPub(DeveloperBox.Text, PublisherBox.Text);
        }

        private void PublisherBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
