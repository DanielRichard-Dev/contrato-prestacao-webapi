using contrato_prestacao_models;
using contrato_prestacao_models.Contrato;
using contrato_prestacao_models.Enum;
using System;
using System.Collections.Generic;

namespace contrato_prestacao_repository.Contrato
{
    public class ContratoRepository : IContratoRepository
    {
        public ContratoModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ContratoModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<ContratoModel> GetByStatus(StatusPrestacaoEnum status)
        {
            throw new NotImplementedException();
        }

        public ContratoModel Insert(ContratoModel obj)
        {
            throw new NotImplementedException();
        }

        public void Update(ContratoModel obj)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        IList<ContratoModel> IRepository<ContratoModel>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
