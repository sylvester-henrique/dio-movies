using System.Collections.Generic;

namespace DIO.Movies
{
    public interface IRepository<T>
    {
        int Insert(T item);
        IEnumerable<T> List(int? id = null);
        void Update(T item);
        void Delete(int id);
    }
}