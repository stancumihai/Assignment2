using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public interface IGenericService<T>
    {
        List<T> GetAll();
        void Add(T t);
        void Delete(long Id);
        T GetById(long Id);
        void Update(long Id, T t);

    }
}
