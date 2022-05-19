using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11.Repository
{
    public class PublisherRepository : IRepository<Publisher>
    {
        private AgregatoContext db;

        public PublisherRepository(AgregatoContext ac)
        {
            db = ac;
        }
        public void Create(Publisher item)
        {
            db.Publishers.Add(item);
        }

        public void Delete(int id)
        {
            Publisher publisher = db.Publishers.Find(id);
            if (publisher != null)
                db.Publishers.Remove(publisher);
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

        public Publisher GetItem(int id)
        {
            return db.Publishers.Find(id);
        }

        public IEnumerable<Publisher> GetList()
        {
            db.Publishers.Load();
            MainWindow.link.OutputTable.ItemsSource = db.Publishers.Local.ToBindingList();
            return db.Publishers;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Publisher publisher)
        {
            db.Entry(publisher).State = EntityState.Modified;
        }
    }
}
