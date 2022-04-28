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

namespace lab9
{
    /// <summary>
    /// Логика взаимодействия для EventsWindow.xaml
    /// </summary>
    public partial class EventsWindow : Window
    {
        public EventsWindow()
        {
            InitializeComponent();
        }

        private void FirstRoutedBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RoutedTextBox1.Text = RoutedTextBox1.Text + "Sender: " + sender.ToString() + "\n";
            //RoutedTextBox1.Text = RoutedTextBox1.Text + "Source: " + e.Source.ToString() + "\n\n";
        }

        private void SecondRoutedBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RoutedTextBox2.Text = RoutedTextBox2.Text + "Sender: " + sender.ToString() + "\n";
            //RoutedTextBox2.Text = RoutedTextBox2.Text + "Source: " + e.Source.ToString() + "\n\n";
        }
    }

    
}
