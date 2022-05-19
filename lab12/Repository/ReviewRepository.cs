using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11.Repository
{
    public class ReviewRepository : IRepository<Review>
    {
        private AgregatoContext db;

        public ReviewRepository(AgregatoContext ac)
        {
            db = ac;
        }
        public void Create(Review item)
        {
            db.Reviews.Add(item);
        }

        public void Delete(int id)
        {
            Review review = db.Reviews.Find(id);
            if (review != null)
                db.Reviews.Remove(review);
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Review GetItem(int id)
        {
            return db.Reviews.Find(id);
        }

        public IEnumerable<Review> GetList()
        {
            db.Reviews.Load();
            MainWindow.link.OutputTable.ItemsSource = db.Reviews.Local.ToBindingList();
            return db.Reviews;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Review review)
        {
            db.Entry(review).State = EntityState.Modified;
        }
    }
}
