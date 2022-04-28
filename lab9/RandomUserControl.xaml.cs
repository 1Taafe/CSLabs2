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

namespace lab9
{
    /// <summary>
    /// Логика взаимодействия для RandomUserControl.xaml
    /// </summary>
    public partial class RandomUserControl : UserControl
    {
        public static readonly DependencyProperty FromProperty;
        public static readonly DependencyProperty ToProperty;
        public RandomUserControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        static RandomUserControl()
        {
            //FromProperty = DependencyProperty.Register("From", typeof(int), typeof(RandomUserControl));
            //ToProperty = DependencyProperty.Register("To", typeof(int), typeof(RandomUserControl));

            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            metadata.CoerceValueCallback = new CoerceValueCallback(CorrectValue);

            FrameworkPropertyMetadata metadata2 = new FrameworkPropertyMetadata();
            metadata2.CoerceValueCallback = new CoerceValueCallback(CorrectValue);

            FromProperty = DependencyProperty.Register("From", typeof(int), typeof(RandomUserControl), metadata,
                new ValidateValueCallback(ValidateValue));
            ToProperty = DependencyProperty.Register("To", typeof(int), typeof(RandomUserControl), metadata2,
                new ValidateValueCallback(ValidateValue));
        }

        private static object CorrectValue(DependencyObject d, object baseValue)
        {
            int currentValue = (int)baseValue;
            if (currentValue < 0)  // если больше 1000, возвращаем 1000
                return 0;
            return currentValue; // иначе возвращаем текущее значение
        }

        private static bool ValidateValue(object value)
        {
            int currentValue = (int)value;
            if (currentValue >= 0) // если текущее значение от нуля и выше
                return true;
            return false;
        }

        public int From
        {
            get { return (int)GetValue(FromProperty); }
            set { SetValue(FromProperty, value); }
        }
        public int To
        {
            get { return (int)GetValue(ToProperty); }
            set { SetValue(ToProperty, value);}
        }
        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Random rnd = new Random();
                int result = rnd.Next(From, To);
                ResultField.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
