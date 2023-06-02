using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SPOAPAKmmReceiver.Entities.Base;
using SPOAPAKmmReceiver.Interfaces;

namespace SPOAPAKmmReceiver.Data.Stores.InDb
{
    internal class DbStore<T> : IStore<T> where T : Entity
    {
        private readonly SPOAPAKmmDB _db;

        public DbStore(SPOAPAKmmDB db)
        {
            _db = db;
            Set = db.Set<T>();
        }

        private DbSet<T> Set { get; }

        public IEnumerable<T> GetAll()
        {
            return Set;
        }

        public T GetById(int id)
        {
            return Set.Find(id);
        }

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