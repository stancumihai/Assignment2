using System.Collections.Generic;

namespace BusinessLayer.Contracts
{
    public interface IGenericService<T>
    {
        List<T> GetAll();
        void Add(T t);
        void Delete(int Id);
        T GetById(int Id);
        void Update(int Id, T t);

    }
}
