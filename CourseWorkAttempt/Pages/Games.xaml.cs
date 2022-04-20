using CourseWorkAttempt.Classes;
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

namespace CourseWorkAttempt.Pages
{
    /// <summary>
    /// Логика взаимодействия для Games.xaml
    /// </summary>
    public partial class Games : Page
    {
        public Games()
        {
            InitializeComponent();
            
            GameList.ItemsSource = Game.GetList();
        }

        private void GameList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(GameList.SelectedIndex != -1)
            {
                CurrentGame currentGamePage = new(GameList.SelectedItem);
                MainWindow.link.navigationService.Navigate(currentGamePage);
                GameList.SelectedIndex = -1;
            }
        }
    }
}
