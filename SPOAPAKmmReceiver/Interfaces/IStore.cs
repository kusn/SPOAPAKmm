using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPOAPAKmmReceiver.Models.Base;

namespace SPOAPAKmmReceiver.Interfaces
{
    public interface IStore<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        
        T GetById(int id);

        T Add(T item);

        T Update(T item);

        void Delete(T item);
    }
}
