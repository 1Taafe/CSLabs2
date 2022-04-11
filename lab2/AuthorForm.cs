using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace lab2
{
    public partial class AuthorForm : Form
    {
        public AuthorForm()
        {
            InitializeComponent();
        }

        private void AddAuthorButton_Click(object sender, EventArgs e)
        {
            try
            {
                Author myAuthor = new Author();
                if(NameField.Text.Length < 1)
                {
                    throw new Exception("Введите имя автора!");
                }
                else
                {
                    myAuthor.Name = NameField.Text;
                }
                if (CountryField.Text.Length < 1)
                {
                    throw new Exception("Введите страну");
                }
                else
                {
                    myAuthor.Country = CountryField.Text;
                }
                if (IDField.Text.Length < 1)
                {
                    throw new Exception("Введите ID");
                }
                else
                {
                    myAuthor.ID = Convert.ToInt32(IDField.Text);
                    AuthorControl.Add(myAuthor);
                }
                NameField.Text = "";
                CountryField.Text = "";
                IDField.Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void AuthorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AuthorControl.isFormOpened = false;
        }
    }
}
