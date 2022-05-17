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
using System.Windows.Shapes;

namespace CourseWorkAttempt.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddGameWindow.xaml
    /// </summary>
    public partial class AddGameWindow : Window
    {
        public static bool isOpened = false;
        public static AddGameWindow link;
        public AddGameWindow()
        {
            InitializeComponent();
            ReleaseDatePicker.SelectedDate = DateTime.Now;
            GenreBox.ItemsSource = Game.GetGenres();
            link = this;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            isOpened = false;
        }

        private void AddGameButton_Click(object sender, RoutedEventArgs e)
        {
            var game = new Game();
            game.Developer = new Developer();
            game.Publisher = new Publisher();
            try
            {
                if (NameBox.Text.Length < 1)
                {
                    throw new Exception("Введите название игры");
                }
                else
                {
                    string part1, part2, input, output;
                    input = NameBox.Text;
                    part1 = NameBox.Text[0].ToString().ToUpper();
                    part2 = input.Substring(1);
                    output = part1 + part2;
                    NameBox.Text = output;
                    game.Name = NameBox.Text;
                }

                if (ImageBox.Text.Length < 1)
                {
                    throw new Exception("Укажите ссылку на изображение");
                }
                else
                {
                    var uriSource = new Uri(ImageBox.Text, UriKind.Absolute);
                    game.ImageURL = ImageBox.Text;
                }

                if (BuyBox.Text.Length < 1)
                {
                    throw new Exception("Укажите ссылку на магазин");
                }
                else
                {
                    var uriSource = new Uri(BuyBox.Text, UriKind.Absolute);
                    game.BuyURL = BuyBox.Text;
                }

                if (PlatformBox.Text.Length < 1)
                {
                    throw new Exception("Укажите платформу");
                }
                else
                {
                    game.Platform = PlatformBox.Text;
                }

                if(GenreBox.SelectedIndex == -1)
                {
                    throw new Exception("Выберите жанр игры");
                }
                else
                {
                    string genre = (GenreBox.SelectedItem as ComboBoxItem).Content.ToString();
                    game.Genre = genre;
                }

                game.ReleaseDate = ReleaseDatePicker.SelectedDate;

                if (DescriptionBox.Text.Length < 1)
                {
                    throw new Exception("Введите описание игры");
                }
                else
                {
                    game.Description = DescriptionBox.Text;
                }

                if (DevBox.Text.Length < 1)
                {
                    throw new Exception("Введите название разработчика");
                }
                else
                {
                    string part1, part2, input, output;
                    input = DevBox.Text;
                    part1 = DevBox.Text[0].ToString().ToUpper();
                    part2 = input.Substring(1);
                    output = part1 + part2;
                    DevBox.Text = output;
                    game.Developer.Name = DevBox.Text;
                }

                if (DevCountryBox.Text.Length < 1)
                {
                    throw new Exception("Введите страну разработчика");
                }
                else
                {
                    string part1, part2, input, output;
                    input = DevCountryBox.Text;
                    part1 = DevCountryBox.Text[0].ToString().ToUpper();
                    part2 = input.Substring(1);
                    output = part1 + part2;
                    DevCountryBox.Text = output;
                    game.Developer.Country = DevCountryBox.Text;

                }

                if (PubBox.Text.Length < 1)
                {
                    throw new Exception("Введите название издателя");
                }
                else
                {
                    string part1, part2, input, output;
                    input = PubBox.Text;
                    part1 = PubBox.Text[0].ToString().ToUpper();
                    part2 = input.Substring(1);
                    output = part1 + part2;
                    PubBox.Text = output;
                    game.Publisher.Name = PubBox.Text;
                }

                if (PubCountryBox.Text.Length < 1)
                {
                    throw new Exception("Введите страну издателя");
                }
                else
                {
                    string part1, part2, input, output;
                    input = PubCountryBox.Text;
                    part1 = PubCountryBox.Text[0].ToString().ToUpper();
                    part2 = input.Substring(1);
                    output = part1 + part2;
                    PubCountryBox.Text = output;
                    game.Publisher.Country = PubCountryBox.Text;
                }

                if (Developer.IsExists(game.Developer.Name))
                {
                    game.Developer.ID = Developer.GetID(game.Developer.Name);
                }
                else
                {
                    Developer.Add(game.Developer.Name, game.Developer.Country);
                    game.Developer.ID = Developer.GetID(game.Developer.Name);
                }

                if (Publisher.IsExists(game.Publisher.Name))
                {
                    game.Publisher.ID = Publisher.GetID(game.Publisher.Name);
                }
                else
                {
                    Publisher.Add(game.Publisher.Name, game.Publisher.Country);
                    game.Publisher.ID = Publisher.GetID(game.Publisher.Name);
                }

                if (Game.AddGame(game))
                {
                    Close();
                    //ErrorMessageBlock.Text = "";
                }
            }
            catch(Exception ex)
            {
                if (ex.Message.Contains("URI"))
                {
                    ErrorMessageBlock.Text = "* " + "Ссылка на изображение в неверном формате";
                }
                else
                {
                    ErrorMessageBlock.Text = "* " + ex.Message;
                }
            }
            
            

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ImageBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (ImageBox.Text.Length > 8)
                {
                    var uriSource = new Uri(ImageBox.Text, UriKind.Absolute);
                    ImageObject.Source = new BitmapImage(uriSource);
                }
            }
            catch
            {

            }
        }

        private void NewGenreButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NewGenreBox.Text.Length < 1)
                {
                    throw new Exception("Введите жанр");
                }
                else
                {
                    Game.AddGenre(NewGenreBox.Text);
                }
            }
            
            catch(Exception ex)
            {
                ErrorMessageBlock.Text = "* " + ex.Message;
            }
        }
    }
}
