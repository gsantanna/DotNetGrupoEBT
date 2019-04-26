using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DG.Framework.Data.Contract
{
    public interface IRepository<T>
        where T : IDomain<T>
    {
        void AddOrUpdate(T domain);

        void Add(T domain);

        void Update(T domain);

        void Delete(int id);

        T GetByID(int id);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetByQuery(string query);

    }
}

