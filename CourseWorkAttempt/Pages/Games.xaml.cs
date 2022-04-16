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
            Game game = new Game();
            game.Name = "jekrgeigkei";
            game.ImageURL = "https://www.global-esports.news/wp-content/uploads/2022/01/League-of-Legends-2022.jpg";
            Game.Collection.Add(game);
            Game.Collection.Add(game);
            Game.Collection.Add(game);
            Game.Collection.Add(game);

            Game.Collection.Add(game);
            Game.Collection.Add(game);
            Game.Collection.Add(game);
            Game.Collection.Add(game);
            GameList.ItemsSource = Game.Collection;
        }
    }
}
