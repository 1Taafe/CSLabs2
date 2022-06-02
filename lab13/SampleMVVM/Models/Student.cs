using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleMVVM.Models
{
    public class Student
    {
        public string Name { get; set; }
        public int Course { get; set; }
        public int Group { get; set; }
        public int Subgroup { get; set; }
        public string Spec { get; set; }

        public int Skips { get; set; }
        public int Marks5 { get; set; }
        public int Marks4 { get; set; }
        public int Marks3 { get; set; }
        public int Marks2 { get; set; }
        public int Marks1 { get; set; }

        public Student()
        {

        }

        public Student(string name, int course, int group, int subgroup, string spec, int skips, int marks5, int marks4, int marks3, int marks2, int marks1)
        {
            Name = name;
            Course = course;
            Group = group;
            Subgroup = subgroup;
            Spec = spec;
            Skips = skips;
            Marks5 = marks5;
            Marks4 = marks4;
            Marks3 = marks3;
            Marks2 = marks2;
            Marks1 = marks1;
        }
    }
}
