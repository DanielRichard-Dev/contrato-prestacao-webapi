using contrato_prestacao_models.Enum;
using contrato_prestacao_models.Prestacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace contrato_prestacao_service.Prestacao
{
    public class PrestacaoService
    {
        public PrestacaoService(List<PrestacaoModel> _prestacao)
        {
            IsValid(_prestacao);
        }

        private void IsValid(List<PrestacaoModel> _validaPrestacao)
        {
            foreach (var validaPrestacao in _validaPrestacao)
            {
                if (validaPrestacao.DataVencimento == DateTime.MinValue)
                    throw new Exception("Data Vencimento inválida!");

                if (validaPrestacao.Valor <= 0)
                    throw new Exception("Valor inválido!");
            }
        }

        public List<PrestacaoModel> CalculaStatus(List<PrestacaoModel> _prestacao)
        {
            foreach (var prestacao in _prestacao)
            {
                if (prestacao.DataVencimento >= DateTime.Now && prestacao.DataPagamento == DateTime.MinValue)
                    prestacao.Status = StatusPrestacaoEnum.Aberta;

                else if (prestacao.DataVencimento < DateTime.Now && prestacao.DataPagamento == DateTime.MinValue)
                    prestacao.Status = StatusPrestacaoEnum.Atrasada;

                else if (prestacao.DataPagamento != DateTime.MinValue)
                    prestacao.Status = StatusPrestacaoEnum.Baixada;
            }

            return _prestacao;
        }
    }
}
