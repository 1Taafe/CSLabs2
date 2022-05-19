using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lab11.Repository
{
    public class UnitOfWork : IDisposable
    {
        private AgregatoContext context = new AgregatoContext();
        private UserRepository userRepository;
        private GameRepository gameRepository;
        private ReviewRepository reviewRepository;
        private DeveloperRepository developerRepository;
        private PublisherRepository publisherRepository;

        public UserRepository UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(context);
                }
                return userRepository;
            }
        }
        public GameRepository GameRepository
        {
            get
            {

                if (this.gameRepository == null)
                {
                    this.gameRepository = new GameRepository(context);
                }
                return gameRepository;
            }
        }

        public ReviewRepository ReviewRepository
        {
            get
            {

                if (this.reviewRepository == null)
                {
                    this.reviewRepository = new ReviewRepository(context);
                }
                return reviewRepository;
            }
        }

        public DeveloperRepository DeveloperRepository
        {
            get
            {

                if (this.developerRepository == null)
                {
                    this.developerRepository = new DeveloperRepository(context);
                }
                return developerRepository;
            }
        }

        public PublisherRepository PublisherRepository
        {
            get
            {

                if (this.publisherRepository == null)
                {
                    this.publisherRepository = new PublisherRepository(context);
                }
                return publisherRepository;
            }
        }

        public void Save()
        {
            using(var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.SaveChanges();
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

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SearchByDevAndPub(string dev, string pub)
        {
            if (dev == "*" && pub == "*")
            {
                var games = context.Games.Include(g => g.Developer)
                                    .Include(g => g.Publisher)
                                    .ToList();
                MainWindow.link.OutputTable.ItemsSource = games;
            }
            else if (dev.Length < 1)
            {
                var games = context.Games.Include(g => g.Developer)
                                    .Include(g => g.Publisher)
                                    .Where(g => g.Publisher.PublisherName == pub)
                                    .ToList();
                MainWindow.link.OutputTable.ItemsSource = games;
            }
            else if (pub.Length < 1)
            {
                var games = context.Games.Include(g => g.Developer)
                                    .Include(g => g.Publisher)
                                    .Where(g => g.Developer.DeveloperName == dev)
                                    .ToList();
                MainWindow.link.OutputTable.ItemsSource = games;
            }
            else if (dev != "*" && pub == "*")
            {
                var games = context.Games.Include(g => g.Publisher)
                                    .ToList();
                MainWindow.link.OutputTable.ItemsSource = games;
            }
            else
            {
                var games = context.Games.Include(g => g.Developer)
                                    .Include(g => g.Publisher)
                                    .Where(g => g.Developer.DeveloperName == dev && g.Publisher.PublisherName == pub)
                                    .ToList();
                MainWindow.link.OutputTable.ItemsSource = games;
            }
        }

    }
}
