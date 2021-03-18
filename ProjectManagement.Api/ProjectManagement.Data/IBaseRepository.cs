using ProjectManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement.Data.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IEnumerable<T> Get();

        T Get(long id);

        T Add(T entity);

        T Update(T entity);

        bool Delete(long id);

    }
}
