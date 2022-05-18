using CourseWorkAttempt.Auth;
using CourseWorkAttempt.Classes;
using CourseWorkAttempt.Pages;
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
    /// Логика взаимодействия для AddReviewWindow.xaml
    /// </summary>
    public partial class AddReviewWindow : Window
    {
        public static bool isOpened = false;
        Game CurrentGameObject;
        public static AddReviewWindow link;
        public AddReviewWindow()
        {
            InitializeComponent();
        }

        public AddReviewWindow(Game currentGame)
        {
            InitializeComponent();
            link = this;
            NicknameBox.Text = Authorization.CurrentUser.Nickname;
            GameBox.Text = currentGame.Name;
            CurrentGameObject = currentGame;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            isOpened = false;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddReviewButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(TextBox.Text.Count() > 0)
                {
                    int rating = 5;
                    rating = Convert.ToInt32((RateBox.SelectedItem as ComboBoxItem).Content);
                    if(Review.IsExists(CurrentGameObject.ID) == false)
                    {
                        Review.AddReview(CurrentGameObject.ID, TextBox.Text, rating);
                        CurrentGame.link.ReviewList.ItemsSource = null;
                        CurrentGame.link.ReviewList.ItemsSource = Review.GetCurrentGameReviews(CurrentGameObject.ID);
                    }
                    else
                    {
                        Review.Update(CurrentGameObject.ID, TextBox.Text, rating);
                        CurrentGame.link.ReviewList.ItemsSource = null;
                        CurrentGame.link.ReviewList.ItemsSource = Review.GetCurrentGameReviews(CurrentGameObject.ID);
                    }

                    if (Review.GetAverageRate(CurrentGameObject.ID) != -1.0)
                    {
                        CurrentGame.link.AverageRateBlock.Text = "Общий рейтинг: " + Convert.ToString(Review.GetAverageRate(CurrentGameObject.ID));
                    }
                    else
                    {
                        CurrentGame.link.AverageRateBlock.Text = "Общий рейтинг: не определен (отзывы отсутствуют) ";
                    }


                    Close();
                }
                else
                {
                    throw new Exception("Текст отзыва пуст. Напишите ваш отзыв и повторите попытку.");
                }
                
            }
            catch(Exception ex)
            {
                ErrorMessageBlock.Text = "* " + ex.Message;
            }
        }
    }
}
