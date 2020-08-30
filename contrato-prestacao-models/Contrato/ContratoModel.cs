using contrato_prestacao_models.Prestacao;
using System;
using System.Collections.Generic;

namespace contrato_prestacao_models.Contrato
{
    public class ContratoModel
    {
        public int ContratoId { get; set; }
        public DateTime Data { get; set; }
        public int QtdParcelas { get; set; }
        public decimal ValorFinanciado { get; set; }
        public List<PrestacaoModel> Prestacoes { get; set; }
    }
}
