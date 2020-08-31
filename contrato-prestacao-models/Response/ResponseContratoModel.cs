using contrato_prestacao_models.Prestacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace contrato_prestacao_models.Response
{
    public class ResponseContratoModel
    {
        public ResponseContratoModel()
        {
            Prestacoes = new List<ResponsePrestacaoModel>();
        }

        public int ContratoId { get; set; }

        public DateTime Data { get; set; }

        public int QtdParcelas { get; set; }

        public decimal ValorFinanciado { get; set; }

        public List<ResponsePrestacaoModel> Prestacoes { get; set; }
    }
}
