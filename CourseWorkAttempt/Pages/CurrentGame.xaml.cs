using CourseWorkAttempt.Auth;
using CourseWorkAttempt.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public static CurrentGame link;
        string ShopURL;
        public CurrentGame()
        {
            InitializeComponent();
            link = this;
        }

        public CurrentGame(object game)
        {
            InitializeComponent();

            List<Review> rlist = new();
            Review review = new Review();
            review.User = new User();
            review.User.Nickname = "Test";
            review.Rate = 5;
            review.Text = "DCgiejgoiwlgohiwhgohorugorbgrbughwoughwoehgwoehwouthoweth";
            review.UploadDate = DateTime.Now;
            rlist.Add(review);
            rlist.Add(review);
            rlist.Add(review);
            rlist.Add(review);
            rlist.Add(review);
            rlist.Add(review);
            rlist.Add(review);

            ReviewList.ItemsSource = rlist;

            Game currentGame = game as Game;
            link = this;
            ShopURL = currentGame.BuyURL;
            if (currentGame != null)
            {
                if(Authorization.CurrentUser != null)
                {
                    CommentButton.IsEnabled = true;
                }
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

        private void ShopButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo(ShopURL) { UseShellExecute = true});
        }
    }
}
