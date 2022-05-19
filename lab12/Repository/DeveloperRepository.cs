using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11.Repository
{
    public class DeveloperRepository : IRepository<Developer>
    {
        private AgregatoContext db;

        public DeveloperRepository(AgregatoContext ac)
        {
            db = ac;
        }
        public void Create(Developer item)
        {
            db.Developers.Add(item);
        }

        public void Delete(int id)
        {
            Developer developer = db.Developers.Find(id);
            if (developer != null)
                db.Developers.Remove(developer);
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

        public Developer GetItem(int id)
        {
            return db.Developers.Find(id);
        }

        public IEnumerable<Developer> GetList()
        {
            db.Developers.Load();
            MainWindow.link.OutputTable.ItemsSource = db.Developers.Local.ToBindingList();
            return db.Developers;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Developer developer)
        {
            db.Entry(developer).State = EntityState.Modified;
        }
    }
}
