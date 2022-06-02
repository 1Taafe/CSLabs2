using SampleMVVM.Commands;
using SampleMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace SampleMVVM.ViewModels
{
    class StudentViewModel : ViewModelBase
    {
        public Student Student;

        public StudentViewModel(Student student)
        {
            Student = student;
        }

        public string Name
        {
            get { return Student.Name; }
            set
            {
                Student.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Course
        {
            get { return Student.Course; }
            set
            {
                Student.Course = value;
                OnPropertyChanged("Course");
            }
        }

        public int Group
        {
            get { return Student.Group; }
            set
            {
                Student.Group = value;
                OnPropertyChanged("Group");
            }
        }

        public int Subgroup
        {
            get { return Student.Subgroup; }
            set
            {
                Student.Subgroup = value;
                OnPropertyChanged("Subgroup");
            }
        }

        public string Spec
        {
            get { return Student.Spec; }
            set
            {
                Student.Spec = value;
                OnPropertyChanged("Spec");
            }
        }

        public int Skips
        {
            get { return Student.Skips; }
            set
            {
                if(value >= 0)
                {
                    Student.Skips = value;
                    OnPropertyChanged("Skips");
                }
                else
                {
                    MessageBox.Show("Количество часов пропусков не может быть отрицательным!");
                }
                
            }
        }

        public int Marks5
        {
            get { return Student.Marks5; }
            set
            {
                if (value >= 0)
                {
                    Student.Marks5 = value;
                    OnPropertyChanged("Marks5");
                }
                else
                {
                    MessageBox.Show("Количество не может быть отрицательным!");
                }
            }
        }

        public int Marks4
        {
            get { return Student.Marks4; }
            set
            {
                if (value >= 0)
                {
                    Student.Marks4 = value;
                    OnPropertyChanged("Marks4");
                }
                else
                {
                    MessageBox.Show("Количество не может быть отрицательным!");
                }
            }
        }

        public int Marks3
        {
            get { return Student.Marks3; }
            set
            {
                if (value >= 0)
                {
                    Student.Marks3 = value;
                    OnPropertyChanged("Marks3");
                }
                else
                {
                    MessageBox.Show("Количество не может быть отрицательным!");
                }
            }
        }

        public int Marks2
        {
            get { return Student.Marks2; }
            set
            {
                if (value >= 0)
                {
                    Student.Marks2 = value;
                    OnPropertyChanged("Marks2");
                }
                else
                {
                    MessageBox.Show("Количество не может быть отрицательным!");
                }
            }
        }

        public int Marks1
        {
            get { return Student.Marks1; }
            set
            {
                if (value >= 0)
                {
                    Student.Marks1 = value;
                    OnPropertyChanged("Marks1");
                }
                else
                {
                    MessageBox.Show("Количество не может быть отрицательным!");
                }
            }
        }

        private DelegateCommand add5Command;

        public ICommand Add5Command
        {
            get
            {
                if (add5Command == null)
                {
                    add5Command = new DelegateCommand(Add5);
                }
                return add5Command;
            }
        }

        private void Add5()
        {
            Marks5++;
        }

        private DelegateCommand remove5Command;

        public ICommand Remove5Command
        {
            get
            {
                if (remove5Command == null)
                {
                    remove5Command = new DelegateCommand(Remove5);
                }
                return remove5Command;
            }
        }

        private void Remove5()
        {
            Marks5--;
        }

        private DelegateCommand add4Command;

        public ICommand Add4Command
        {
            get
            {
                if (add4Command == null)
                {
                    add4Command = new DelegateCommand(Add4);
                }
                return add4Command;
            }
        }

        private void Add4()
        {
            Marks4++;
        }

        private DelegateCommand remove4Command;

        public ICommand Remove4Command
        {
            get
            {
                if (remove4Command == null)
                {
                    remove4Command = new DelegateCommand(Remove4);
                }
                return remove4Command;
            }
        }

        private void Remove4()
        {
            Marks4--;
        }

        private DelegateCommand add3Command;

        public ICommand Add3Command
        {
            get
            {
                if (add3Command == null)
                {
                    add3Command = new DelegateCommand(Add3);
                }
                return add3Command;
            }
        }

        private void Add3()
        {
            Marks3++;
        }

        private DelegateCommand remove3Command;

        public ICommand Remove3Command
        {
            get
            {
                if (remove3Command == null)
                {
                    remove3Command = new DelegateCommand(Remove3);
                }
                return remove3Command;
            }
        }

        private void Remove3()
        {
            Marks3--;
        }

        private DelegateCommand add2Command;

        public ICommand Add2Command
        {
            get
            {
                if (add2Command == null)
                {
                    add2Command = new DelegateCommand(Add2);
                }
                return add2Command;
            }
        }

        private void Add2()
        {
            Marks2++;
        }

        private DelegateCommand remove2Command;

        public ICommand Remove2Command
        {
            get
            {
                if (remove2Command == null)
                {
                    remove2Command = new DelegateCommand(Remove2);
                }
                return remove2Command;
            }
        }

        private void Remove2()
        {
            Marks2--;
        }

        private DelegateCommand add1Command;

        public ICommand Add1Command
        {
            get
            {
                if (add1Command == null)
                {
                    add1Command = new DelegateCommand(Add1);
                }
                return add1Command;
            }
        }

        private void Add1()
        {
            Marks1++;
        }

        private DelegateCommand remove1Command;

        public ICommand Remove1Command
        {
            get
            {
                if (remove1Command == null)
                {
                    remove1Command = new DelegateCommand(Remove1);
                }
                return remove1Command;
            }
        }

        private void Remove1()
        {
            Marks1--;
        }

        private DelegateCommand addSkipCommand;

        public ICommand AddSkipCommand
        {
            get
            {
                if (addSkipCommand == null)
                {
                    addSkipCommand = new DelegateCommand(AddSkip);
                }
                return addSkipCommand;
            }
        }

        private void AddSkip()
        {
            Skips += 2;
        }

        private DelegateCommand removeSkipCommand;

        public ICommand RemoveSkipCommand
        {
            get
            {
                if (removeSkipCommand == null)
                {
                    removeSkipCommand = new DelegateCommand(RemoveSkip);
                }
                return removeSkipCommand;
            }
        }

        private void RemoveSkip()
        {
            Skips -= 2;
        }
    }
}
