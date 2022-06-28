using System.Collections.Generic;

namespace SongProject.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T Get(int id);// ?
        List<T> GetAll();// ?
    }
}
