using contrato_prestacao_models.Contrato;
using contrato_prestacao_models.Enum;
using contrato_prestacao_models.Prestacao;
using contrato_prestacao_models.Response;
using contrato_prestacao_service.Prestacao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace contrato_prestacao_service.Contrato
{
    public class ContratoService : IContratoService
    {
        private IContratoRepository RepositoryContrato { get; set; }
        private IPrestacaoRepository RepositoryPrestacao { get; set; }

        private void IsValid(ContratoModel contrato)
        {
            if (contrato.Prestacoes == null)
                throw new Exception("Prestações inválidas!");

            if (contrato.QtdParcelas <= 0)
                throw new Exception("Parcelas inválidas!");

            if (contrato.ValorFinanciado <= 0)
                throw new Exception("Valor Financiado inválido!");
        }

        public ContratoService(IContratoRepository repositoryContrato, IPrestacaoRepository repositoryPrestacao)
        {
            this.RepositoryContrato = repositoryContrato;
            this.RepositoryPrestacao = repositoryPrestacao;
        }

        public ContratoModel Get(int id)
        {
            var contrato = RepositoryContrato.GetById(id);

            if (contrato != null)
            {
                contrato.Prestacoes = RepositoryPrestacao.GetByContratoId(contrato.ContratoId).ToList();
                contrato.Prestacoes = new PrestacaoService(contrato.Prestacoes).CalculaStatus(contrato.Prestacoes);
            }

            return contrato;
        }

        public IList<ContratoModel> GetAll()
        {
            var _contrato = RepositoryContrato.GetAll();
            

            if (_contrato.Count > 0)
            {
                foreach (var contrato in _contrato)
                {
                    contrato.Prestacoes = RepositoryPrestacao.GetByContratoId(contrato.ContratoId).ToList();
                    contrato.Prestacoes = new PrestacaoService(contrato.Prestacoes).CalculaStatus(contrato.Prestacoes);
                }
            }         

            return _contrato;
        }

        public IList<ContratoModel> GetByStatus(StatusPrestacaoEnum status)
        {
            return RepositoryContrato.GetByStatus(status);
        }

        public ContratoModel Insert(ContratoModel contrato)
        {
            IsValid(contrato);

            contrato.Data = DateTime.Now;
            RepositoryContrato.Insert(contrato);

            return contrato;
        }

        public void Update(ContratoModel obj)
        {
            RepositoryContrato.Update(obj);
        }

        public void Delete(int id)
        {
            RepositoryContrato.DeleteById(id);
        }

        public ResponseContratoModel PopulaResponseContrato(ContratoModel contrato)
        {
            var responseContrato = new ResponseContratoModel()
            {
                ContratoId = contrato.ContratoId,
                Data = contrato.Data,
                QtdParcelas = contrato.QtdParcelas,
                ValorFinanciado = contrato.ValorFinanciado,
                Prestacoes = PopulaPrestacaoResponse(contrato.Prestacoes)
            };

            return responseContrato;
        }

        public List<ResponseContratoModel> PopulaListReponseContrato(List<ContratoModel> _contrato)
        {
            var _responseContrato = new List<ResponseContratoModel>();

            foreach (var contrato in _contrato)
            {
                _responseContrato.Add(new ResponseContratoModel()
                {
                    ContratoId = contrato.ContratoId,
                    Data = contrato.Data,
                    QtdParcelas = contrato.QtdParcelas,
                    ValorFinanciado = contrato.ValorFinanciado,
                    Prestacoes = PopulaPrestacaoResponse(contrato.Prestacoes)
                });
            }

            return _responseContrato;
        }

        public List<ResponsePrestacaoModel> PopulaPrestacaoResponse(List<PrestacaoModel> _prestacao)
        {
            var _responsePrestacao = new List<ResponsePrestacaoModel>();

            foreach (var prestacao in _prestacao)
            {
                _responsePrestacao.Add(new ResponsePrestacaoModel()
                {
                    PrestacaoId = prestacao.PrestacaoId,
                    ContratoId = prestacao.ContratoId,
                    DataVencimento = prestacao.DataVencimento,
                    DataPagamento = prestacao.DataPagamento,
                    Valor = prestacao.Valor,
                    Status = prestacao.Status,
                });
            }

            return _responsePrestacao;
        }
    }
}

