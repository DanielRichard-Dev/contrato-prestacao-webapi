using System;
using System.Collections.Generic;
using System.Text;

namespace contrato_prestacao_models
{
    public interface IRepository<T>
    {
        T GetById(int id);

        IList<T> GetAll();

        IList<T> GetByContratoId(int id);

        T Insert(T obj);

        void Update(T obj);

        void DeleteById(int id);
    }
}
