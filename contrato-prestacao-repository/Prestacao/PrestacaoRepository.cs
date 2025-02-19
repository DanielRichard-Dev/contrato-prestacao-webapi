﻿using contrato_prestacao_models.Prestacao;
using contrato_prestacao_repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IList<PrestacaoModel> GetByContratoId(int contratoId)
        {
            return DataContext.Prestacao.Where(x => x.ContratoId == contratoId).ToList();
        }

        public PrestacaoModel Insert(PrestacaoModel obj)
        {
            var prestacao = DataContext.Add(obj);            
            DataContext.SaveChanges();
            obj.PrestacaoId = prestacao.Entity.PrestacaoId;

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
