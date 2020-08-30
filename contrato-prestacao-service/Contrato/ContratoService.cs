using contrato_prestacao_models.Contrato;
using contrato_prestacao_models.Enum;
using contrato_prestacao_models.Prestacao;
using contrato_prestacao_service.Prestacao;
using System;
using System.Collections.Generic;

namespace contrato_prestacao_service.Contrato
{
    public class ContratoService : IContratoService
    {
        private IContratoRepository repository { get; set; }

        private void IsValid(ContratoModel contrato)
        {
            if (contrato.Prestacoes == null)
                throw new Exception("Prestações inválidas!");

            if (contrato.QtdParcelas > 0)
                throw new Exception("Parcelas inválidas!");

            if (contrato.ValorFinanciado > 0)
                throw new Exception("Valor Financiado inválido!");
        }

        public ContratoService(IContratoRepository repository)
        {
            this.repository = repository;
        }

        public ContratoModel Get(int id)
        {
            return repository.GetById(id);
        }

        public IList<ContratoModel> GetAll()
        {
            return repository.GetAll();
        }

        public IList<ContratoModel> GetByStatus(StatusPrestacaoEnum status)
        {
            return repository.GetByStatus(status);
        }

        public ContratoModel Save(ContratoModel obj)
        {
            IsValid(obj);

            if (obj.ContratoId == 0)
            {
                var servicePrestacoes = new PrestacaoService(obj.Prestacoes);
                obj.Data = DateTime.Now;
                obj.Prestacoes = servicePrestacoes.CalculaStatus(obj.Prestacoes);

                repository.Insert(obj);
            }
            else
            {
                repository.Update(obj);
            }

            return obj;
        }

        public void Delete(int id)
        {
            repository.DeleteById(id);
        }
    }
}

