using CourseWorkAttempt.Windows;
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
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void EditWindowButton_Click(object sender, RoutedEventArgs e)
        {
            if(EditProfileWindow.isOpened == false)
            {
                EditProfileWindow editProfileWindow = new();
                EditProfileWindow.isOpened = true;
                editProfileWindow.Show();
            }
        }
    }
}
