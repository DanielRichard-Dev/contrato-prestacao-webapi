using contrato_prestacao_models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace contrato_prestacao_models.Response
{
    public class ResponsePrestacaoModel
    {
        public int PrestacaoId { get; set; }

        public int ContratoId { get; set; }

        public DateTime DataVencimento { get; set; }

        public DateTime DataPagamento { get; set; }

        public decimal Valor { get; set; }

        public StatusPrestacaoEnum Status { get; set; }
    }
}
