using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SPOAPAKmmReceiver.Interfaces;
using SPOAPAKmmReceiver.Models.Base;

namespace SPOAPAKmmReceiver.Data.Stores.InDb
{
    internal class DbStore<T> : IStore<T> where T : Entity
    {
        private readonly SPOAPAKmmDB _db;
        private DbSet<T> Set { get; }

        public DbStore(SPOAPAKmmDB db)
        {
            _db = db;
            Set = db.Set<T>();
        }

        public IEnumerable<T> GetAll() => Set;

        public T GetById(int id) => Set.Find(id);

        public T Add(T item)
        {
            _db.Add(item);
            _db.SaveChanges();
            return item;
        }

        public void Update(T item)
        {
            _db.Update(item);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            _db.Remove(item);
            _db.SaveChanges();
        }
    }
}
