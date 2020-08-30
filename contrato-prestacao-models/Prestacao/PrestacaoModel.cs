using contrato_prestacao_models.Contrato;
using contrato_prestacao_models.Enum;
using System;

namespace contrato_prestacao_models.Prestacao
{
    public class PrestacaoModel
    {
        public int PrestacaoId { get; set; }
        public DateTime DataVencimento  { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal Valor { get; set; }
        public StatusPrestacaoEnum Status { get; set; }
    }
}
