using RepositoryDesignPattern.Interfaces;
using System.Collections.Generic;

namespace RepositoryDesignPattern.Repository
{
    public interface IRepo<T> where T : IIdentifiable
    {
        bool Add(T item);

        bool Update(T item);

        bool Remove(T item);

        T Get(int id);

        IEnumerable<T> GetAll();
    }
}
