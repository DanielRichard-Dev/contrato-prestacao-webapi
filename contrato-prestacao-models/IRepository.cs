using System;
using System.Collections.Generic;
using System.Text;

namespace contrato_prestacao_models
{
    public interface IRepository<T>
    {
        List<T> GetAll();

        T GetById(int id);

        T Insert(T obj);

        void Update(T obj);

        void DeleteById(int id);
    }
}
