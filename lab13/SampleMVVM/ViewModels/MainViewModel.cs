using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

using SampleMVVM.Commands;
using System.Collections.ObjectModel;
using SampleMVVM.Models;

namespace SampleMVVM.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public ObservableCollection<StudentViewModel> StudentsList { get; set; } 

        #region Constructor

        public MainViewModel(List<Student> students)
        {
            StudentsList = new ObservableCollection<StudentViewModel>(students.Select(s => new StudentViewModel(s)));
        }

        #endregion
    }
}
