using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11.Repository
{
    public class UserRepository : IRepository<User>
    {
        private AgregatoContext db;

        public UserRepository(AgregatoContext ac)
        {
            db = ac;
        }
        public void Create(User item)
        {
            db.Users.Add(item);
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
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

        public User GetItem(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<User> GetList()
        {
            db.Users.Load();
            MainWindow.link.OutputTable.ItemsSource = db.Users.Local.ToBindingList();
            return db.Users;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }
    }
}
