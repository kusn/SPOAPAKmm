using SPOAPAKmmReceiver.Entities.Base;
using System.Collections.Generic;

namespace SPOAPAKmmReceiver.Interfaces
{
    public interface IStore<T> where T : Entities.Base.Entity
    {
        IEnumerable<T> GetAll();
        
        T GetById(int id);

        T Add(T item);

        void Update(T item);

        void Delete(int id);
    }
}
