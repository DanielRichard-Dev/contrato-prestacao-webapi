using contrato_prestacao_models.Prestacao;
using contrato_prestacao_repository.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace contrato_prestacao_repository.Prestacao
{
    public class PrestacaoRepository : IPrestacaoRepository
    {
        public DataContext DataContext { get; set; }

        public PrestacaoRepository(DataContext datacontext)
        {
            DataContext = datacontext;
        }

        public IList<PrestacaoModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public PrestacaoModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public PrestacaoModel Insert(PrestacaoModel obj)
        {
            var teste = DataContext.Add(obj);            
            DataContext.SaveChanges();
            obj.PrestacaoId = teste.Entity.PrestacaoId;

            return obj;
        }

        public void Update(PrestacaoModel obj)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
