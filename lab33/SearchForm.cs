using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace lab2
{
    public partial class SearchForm : Form
    {
        private void ShowBooks(List<Book> books)
        {
            BooksTable.Rows.Clear();
            foreach (var b in books)
            {
                BooksTable.Rows.Add(b.Title, b.Type, b.FileSize, b.UDC, b.Pages, b.Publisher, b.Year, b.UploadTime, b.Author);
            }
        }

        private void SearchFunc()
        {
            if (RegCheckBox.Checked == false && YearCheckBox.Checked == false && PublisherCheckBox.Checked == true)
            {
                ShowBooks(SearchControl.Search(PublisherField.Text));
            }
            else if (RegCheckBox.Checked == true && YearCheckBox.Checked == false && PublisherCheckBox.Checked == true)
            {
                ShowBooks(SearchControl.SearchByPublisherAndPages(PublisherField.Text, RegField.Text));
            }
            else if (RegCheckBox.Checked == false && YearCheckBox.Checked == true && PublisherCheckBox.Checked == true)
            {
                ShowBooks(SearchControl.SearchByPublisherAndYear(PublisherField.Text, (int)YearField.Value));
            }
            else if (RegCheckBox.Checked == true && YearCheckBox.Checked == true && PublisherCheckBox.Checked == true)
            {
                ShowBooks(SearchControl.Search(PublisherField.Text, (int)YearField.Value, RegField.Text));
            }
            else if (RegCheckBox.Checked == true && YearCheckBox.Checked == false && PublisherCheckBox.Checked == false)
            {
                ShowBooks(SearchControl.SearchByPages(RegField.Text));
            }
            else if (RegCheckBox.Checked == false && YearCheckBox.Checked == true && PublisherCheckBox.Checked == false)
            {
                ShowBooks(SearchControl.SearchByYear((int)YearField.Value));
            }
            else if (RegCheckBox.Checked == true && YearCheckBox.Checked == true && PublisherCheckBox.Checked == false)
            {
                ShowBooks(SearchControl.SearchByPagesAndYear(RegField.Text, (int)YearField.Value));
            }
            else
            {
                MessageBox.Show("Возможно, вы не выбрали ни одного критерия поиска.","Что-то пошло не так! :(");
            }
        }
        public SearchForm()
        {
            InitializeComponent();
        }

        private void PublisherField_TextChanged(object sender, EventArgs e)
        {
            SearchFunc();
        }

        private void PublisherCheckBox_Click(object sender, EventArgs e)
        {
            if(PublisherCheckBox.Checked == true)
            {
                PublisherField.Enabled = true;
            }
            else
            {
                PublisherField.Enabled = false;
            }
            SearchFunc();
        }

        private void YearCheckBox_Click(object sender, EventArgs e)
        {
            if (YearCheckBox.Checked == true)
            {
                YearField.Enabled = true;
            }
            else
            {
                YearField.Enabled = false;
            }
            SearchFunc();
        }

        private void YearField_ValueChanged(object sender, EventArgs e)
        {
            SearchFunc();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            BooksContainer.ExportXML();
        }

        private void SearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SearchControl.isFormOpened = false;
        }

        private void RegCheckBox_Click(object sender, EventArgs e)
        {
            if(RegCheckBox.Checked == true)
            {
                RegField.Enabled = true;
            }
            else
            {
                RegField.Enabled = false;
            }
            SearchFunc();
        }

        private void RegField_TextChanged(object sender, EventArgs e)
        {
            SearchFunc();
        }
    }

    public static class SearchControl
    {
        public static bool isFormOpened = false;
        public static string source = @"C:\Users\dima7\source\repos\lab33\search.xml";
        public static XmlSerializer formatter = new XmlSerializer(typeof(List<Book>));

        public static void SaveSearch(List<Book> books)
        {
            File.Delete(source);
            using (FileStream fs = new FileStream(source, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, books);
            }
        }

        public static List<Book> Search(string publisher)
        {
            var foundItems = BooksContainer.shelf.Where(b => b.Publisher == publisher).ToList();
            SaveSearch(foundItems);
            return foundItems;
        }

        public static List<Book> SearchByPages(string pages)
        {
            int minValue = 0, maxValue = 2000;
            string match;
            Regex pagesReg = new Regex(@"^[0-9]+-[0-9]+$");
            Regex minPages = new Regex(@"^[0-9]+-");
            Regex maxPages = new Regex(@"-[0-9]+$");
            Regex Pages = new Regex(@"[0-9]+");
            var foundItems = new List<Book>();
            if (pagesReg.IsMatch(pages))
            {
                if (minPages.IsMatch(pages))
                {
                    match = minPages.Match(pages).Value;
                    minValue = Convert.ToInt32(Pages.Match(match).Value);
                }
                if (maxPages.IsMatch(pages))
                {
                    match = maxPages.Match(pages).Value;
                    maxValue = Convert.ToInt32(Pages.Match(match).Value);
                }
            }
            foreach (var book in BooksContainer.shelf)
            {
                if (book.Pages >= minValue && book.Pages <= maxValue)
                {
                    foundItems.Add(book);
                }
            }
            SaveSearch(foundItems);
            return foundItems;
        }

        public static List<Book> SearchByYear(int year)
        {
            var foundItems = BooksContainer.shelf.Where(b => b.Year == year).ToList();
            SaveSearch(foundItems);
            return foundItems;
        }

        public static List<Book> SearchByPagesAndYear(string pages, int year)
        {
            var foundItems = BooksContainer.shelf.Where(b => b.Year == year).ToList();
            var endItems = new List<Book>();
            int minValue = 0, maxValue = 2000;
            string match;
            Regex pagesReg = new Regex(@"^[0-9]+-[0-9]+$");
            Regex minPages = new Regex(@"^[0-9]+-");
            Regex maxPages = new Regex(@"-[0-9]+$");
            Regex Pages = new Regex(@"[0-9]+");
            if (pagesReg.IsMatch(pages))
            {
                if (minPages.IsMatch(pages))
                {
                    match = minPages.Match(pages).Value;
                    minValue = Convert.ToInt32(Pages.Match(match).Value);
                }
                if (maxPages.IsMatch(pages))
                {
                    match = maxPages.Match(pages).Value;
                    maxValue = Convert.ToInt32(Pages.Match(match).Value);
                }
            }
            foreach (var book in foundItems)
            {
                if (book.Pages >= minValue && book.Pages <= maxValue)
                {
                    endItems.Add(book);
                }
            }
            SaveSearch(endItems);
            return endItems;
        }

        public static List<Book> SearchByPublisherAndYear(string publisher, int year)
        {
            var foundItems = BooksContainer.shelf.Where(b => b.Year == year && b.Publisher == publisher).ToList();
            SaveSearch(foundItems);
            return foundItems;
        }

        public static List<Book> SearchByPublisherAndPages(string publisher, string pages)
        {
            var foundItems = BooksContainer.shelf.Where(b => b.Publisher == publisher).ToList();
            var endItems = new List<Book>();
            int minValue = 0, maxValue = 2000;
            string match;
            Regex pagesReg = new Regex(@"^[0-9]+-[0-9]+$");
            Regex minPages = new Regex(@"^[0-9]+-");
            Regex maxPages = new Regex(@"-[0-9]+$");
            Regex Pages = new Regex(@"[0-9]+");
            if (pagesReg.IsMatch(pages))
            {
                if (minPages.IsMatch(pages))
                {
                    match = minPages.Match(pages).Value;
                    minValue = Convert.ToInt32(Pages.Match(match).Value);
                }
                if (maxPages.IsMatch(pages))
                {
                    match = maxPages.Match(pages).Value;
                    maxValue = Convert.ToInt32(Pages.Match(match).Value);
                }
            }
            foreach (var book in foundItems)
            {
                if (book.Pages >= minValue && book.Pages <= maxValue)
                {
                    endItems.Add(book);
                }
            }
            SaveSearch(endItems);
            return endItems;
        }

        public static List<Book> Search(string publisher, int year, string pages)
        {
            var foundItems = BooksContainer.shelf.Where(b => b.Year == year && b.Publisher == publisher).ToList();
            var endItems = new List<Book>();
            int minValue = 0, maxValue = 2000;
            string match;
            Regex pagesReg = new Regex(@"^[0-9]+-[0-9]+$");
            Regex minPages = new Regex(@"^[0-9]+-");
            Regex maxPages = new Regex(@"-[0-9]+$");
            Regex Pages = new Regex(@"[0-9]+");
            if (pagesReg.IsMatch(pages))
            {
                if (minPages.IsMatch(pages))
                {
                    match = minPages.Match(pages).Value;
                    minValue = Convert.ToInt32(Pages.Match(match).Value);
                }
                if (maxPages.IsMatch(pages))
                {
                    match = maxPages.Match(pages).Value;
                    maxValue = Convert.ToInt32(Pages.Match(match).Value);
                }
            }
            foreach (var book in foundItems)
            {
                if (book.Pages >= minValue && book.Pages <= maxValue)
                {
                    endItems.Add(book);
                }
            }
            SaveSearch(endItems);
            return endItems;
        }
    }
}
