using System;
using System.Collections.Generic;
using System.Text;

namespace contrato_prestacao_models
{
    public interface IService<T>
    {
        T Insert(T obj);

        T Get(int id);

        IList<T> GetAll();

        void Update(T obj);

        void Delete(int id);
    }
}
