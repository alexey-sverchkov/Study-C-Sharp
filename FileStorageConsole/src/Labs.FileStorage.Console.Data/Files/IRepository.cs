using System;
using System.Collections.Generic;
using System.Text;

namespace Labs.FileStorage.Console.Data.Files
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetCollection();

        T GetById(object id);

        void Insert(T entity);
        void Delete(T entity);
    }
}
