using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
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
        private void OnStartup(object sender, StartupEventArgs e)
        {

            List<Student> students = new List<Student>()
            {
                new Student("Заянковский Дмитрий", 2,7,1, "POIBMC", 0, 4,0,0,0,0),
                new Student("Адамович Антон", 2,7,1, "POIBMC", 0, 4,0,0,0,0),
                new Student("Котович Роман", 2,7,2, "POIBMC", 0, 4,0,0,0,0)
            };

            MainView view = new MainView(); // создали View
            MainViewModel viewModel = new ViewModels.MainViewModel(students); // Создали ViewModel
            view.DataContext = viewModel; // положили ViewModel во View в качестве DataContext
            view.Show();
        }
    }
}
