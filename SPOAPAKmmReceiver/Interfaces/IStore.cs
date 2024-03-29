﻿using System.Collections.Generic;
using SPOAPAKmmReceiver.Entities.Base;

namespace SPOAPAKmmReceiver.Interfaces
{
    public interface IStore<T> where T : Entity
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        T Add(T item);

        void Update(T item);

        void Delete(int id);
    }
}