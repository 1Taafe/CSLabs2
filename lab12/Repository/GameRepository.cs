using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11.Repository
{
    public class GameRepository : IRepository<Game>
    {
        private AgregatoContext db;

        public GameRepository(AgregatoContext ac)
        {
            db = ac;
        }
        public void Create(Game item)
        {
            db.Games.Add(item);
        }

        public void Delete(int id)
        {
            Game game = db.Games.Find(id);
            if (game != null)
                db.Games.Remove(game);
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

        public Game GetItem(int id)
        {
            return db.Games.Find(id);
        }

        public IEnumerable<Game> GetList()
        {
            db.Games.Load();
            MainWindow.link.OutputTable.ItemsSource = db.Games.Local.ToBindingList();
            return db.Games;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Game game)
        {
            db.Entry(game).State = EntityState.Modified;
        }
    }
}
