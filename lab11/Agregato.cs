using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lab11
{
    /*	Scaffold-DbContext "строка подключения" провайдер_бд*/
    public static class Agregato
    {
        public static AgregatoContext db;

        public static void Open()
        {
            db = new AgregatoContext();
        }

        public static void Close()
        {
            db.Dispose();
        }

        public static async void GetUsers()
        {
            // получаем объекты из бд и выводим на консоль
            await db.Users.LoadAsync(); // загружаем данные
            MainWindow.link.OutputTable.ItemsSource = db.Users.Local.ToBindingList(); // устанавливаем привязку к кэшу
        }

        public static async void GetReviews()
        {
            // получаем объекты из бд и выводим на консоль
            await db.Reviews.LoadAsync(); // загружаем данные
            MainWindow.link.OutputTable.ItemsSource = db.Reviews.Local.ToBindingList(); // устанавливаем привязку к кэшу
        }

        public static async void GetGames()
        {
            // получаем объекты из бд и выводим на консоль
            await db.Games.LoadAsync(); // загружаем данные
            MainWindow.link.OutputTable.ItemsSource = db.Games.Local.ToBindingList(); // устанавливаем привязку к кэшу
        }

        public static async void GetDevelopers()
        {
            // получаем объекты из бд и выводим на консоль
            await db.Developers.LoadAsync(); // загружаем данные
            MainWindow.link.OutputTable.ItemsSource = db.Developers.Local.ToBindingList(); // устанавливаем привязку к кэшу
        }

        public static async void GetPublishers()
        {
            // получаем объекты из бд и выводим на консоль
            await db.Publishers.LoadAsync(); // загружаем данные
            MainWindow.link.OutputTable.ItemsSource = db.Publishers.Local.ToBindingList(); // устанавливаем привязку к кэшу
        }

        public static void SearchByDevAndPub(string dev, string pub)
        {
            if (dev == "*" && pub == "*")
            {
                var games = db.Games.Include(g => g.Developer)
                                    .Include(g => g.Publisher)
                                    .ToList();
                MainWindow.link.OutputTable.ItemsSource = games;
            }
            else if (dev.Length < 1)
            {
                var games = db.Games.Include(g => g.Developer)
                                    .Include(g => g.Publisher)
                                    .Where(g => g.Publisher.PublisherName == pub)
                                    .ToList();
                MainWindow.link.OutputTable.ItemsSource = games;
            }
            else if (pub.Length < 1)
            {
                var games = db.Games.Include(g => g.Developer)
                                    .Include(g => g.Publisher)
                                    .Where(g => g.Developer.DeveloperName == dev)
                                    .ToList();
                MainWindow.link.OutputTable.ItemsSource = games;
            }
            else if (dev != "*" && pub == "*")
            {
                var games = db.Games.Include(g => g.Publisher)
                                    .ToList();
                MainWindow.link.OutputTable.ItemsSource = games;
            }
            else
            {
                var games = db.Games.Include(g => g.Developer)
                                    .Include(g => g.Publisher)
                                    .Where(g => g.Developer.DeveloperName == dev && g.Publisher.PublisherName == pub)
                                    .ToList();
                MainWindow.link.OutputTable.ItemsSource = games;
            }
        }



        public static async void SaveChanges()
        {
            using(var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    await db.SaveChangesAsync();
                    transaction.Commit();
                    MessageBox.Show("Сохранение выполнено.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"{ex.Message} \n Уникальные поля должны быть заполнены \n Отмена транзакции");
                }
            }

        }
    }
}
