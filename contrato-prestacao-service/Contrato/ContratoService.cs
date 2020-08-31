using contrato_prestacao_models.Contrato;
using contrato_prestacao_models.Enum;
using contrato_prestacao_models.Prestacao;
using contrato_prestacao_models.Response;
using contrato_prestacao_repository.Contrato;
using contrato_prestacao_repository.Data;
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

            if (contrato.QtdParcelas <= 0)
                throw new Exception("Parcelas inválidas!");

            if (contrato.ValorFinanciado <= 0)
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

        public ContratoModel Insert(ContratoModel contrato)
        {
            IsValid(contrato);

            var servicePrestacoes = new PrestacaoService(contrato.Prestacoes);
            contrato.Data = DateTime.Now;
            contrato.Prestacoes = servicePrestacoes.CalculaStatus(contrato.Prestacoes);

            repository.Insert(contrato);

            return contrato;
        }

        public void Update(ContratoModel obj)
        {
            repository.Update(obj);
        }

        public void Delete(int id)
        {
            repository.DeleteById(id);
        }

        public ResponseContratoModel PopulaResponseContrato(ContratoModel contrato)
        {
            var responseContrato = new ResponseContratoModel();
            if (contrato.ContratoId > 0)
            {
                responseContrato.ContratoId = contrato.ContratoId;
                responseContrato.Mensagem = "Contrato inserido com sucesso!";
            }
            else
            {
                responseContrato.Mensagem = "Erro ao inserir contrato!";
            }

            return responseContrato;
        }
    }
}

