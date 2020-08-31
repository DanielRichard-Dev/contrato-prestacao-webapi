using contrato_prestacao_models;
using contrato_prestacao_models.Contrato;
using contrato_prestacao_models.Enum;
using contrato_prestacao_repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace contrato_prestacao_repository.Contrato
{
    public class ContratoRepository : IContratoRepository
    {
        public DataContext DataContext { get; set; }

        public ContratoRepository(DataContext datacontext)
        {
            DataContext = datacontext;
        }

        public ContratoModel GetById(int id)
        {
            return DataContext.Contrato.Where(x => x.ContratoId == id).FirstOrDefault();
        }

        IList<ContratoModel> IRepository<ContratoModel>.GetAll()
        {
            return DataContext.Contrato.ToList();
        }

        public IList<ContratoModel> GetByStatus(StatusPrestacaoEnum status)
        {
            throw new NotImplementedException();
        }

        public IList<ContratoModel> GetByContratoId(int id)
        {
            throw new NotImplementedException();
        }

        public ContratoModel Insert(ContratoModel obj)
        {
            var contrato = DataContext.Add(obj);
            DataContext.SaveChanges();
            obj.ContratoId = contrato.Entity.ContratoId;

            return obj;
        }

        public void Update(ContratoModel obj)
        {
            DataContext.Contrato.Update(obj);
            DataContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var contrato = GetById(id);
            DataContext.Contrato.Remove(contrato);
            DataContext.SaveChanges();
        }
    }
}
