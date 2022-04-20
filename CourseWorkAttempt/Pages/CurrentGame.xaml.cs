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
    /// Логика взаимодействия для CurrentGame.xaml
    /// </summary>
    public partial class CurrentGame : Page
    {
        public CurrentGame()
        {
            InitializeComponent();
        }

        public CurrentGame(object game)
        {
            InitializeComponent();
            Game currentGame = game as Game;
            if (currentGame != null)
            {
                GameImage.Source = BitmapFrame.Create(new Uri(currentGame.ImageURL));
                NameBlock.Text = currentGame.Name;
                GenreBlock.Text = currentGame.Genre;
                PlatformBlock.Text = currentGame.Platform;
                DescriptionBlock.Text = currentGame.Description;
                ReleaseDateBlock.Text = "Дата релиза: " + currentGame.ReleaseDate.Value.ToShortDateString();
                DeveloperBlock.Text = "Разработчик: " + currentGame.Developer.Name + $" ({currentGame.Developer.Country})";
                PublisherBlock.Text = "Издатель: " + currentGame.Publisher.Name + $" ({currentGame.Publisher.Country})";
            }
        }
    }
}
