using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Serialization;
using SampleMVVM.Models;
using SampleMVVM.ViewModels;
using SampleMVVM.Views;

namespace SampleMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        List<Student> students;
        private void OnStartup(object sender, StartupEventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Student>));
            using (FileStream fs = new FileStream(@"C:\Users\dima7\Desktop\students.xml", FileMode.OpenOrCreate))
            {
                students = formatter.Deserialize(fs) as List<Student>;
            }    

            MainView view = new MainView(); // создали View
            MainViewModel viewModel = new ViewModels.MainViewModel(students); // Создали ViewModel
            view.DataContext = viewModel; // положили ViewModel во View в качестве DataContext
            view.Show();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Student>));
            using (FileStream fs = new FileStream(@"C:\Users\dima7\Desktop\students.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, students);
            }
        }
    }
}
