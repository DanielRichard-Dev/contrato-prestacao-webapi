using System;
using System.Collections.Generic;
using System.Text;

namespace contrato_prestacao_models
{
    public interface IService<T>
    {
        T Get(int id);

        IList<T> GetAll();

        T Save(T obj);

        void Delete(int id);
    }
}
