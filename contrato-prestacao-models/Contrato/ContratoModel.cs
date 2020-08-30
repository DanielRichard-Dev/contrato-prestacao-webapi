using contrato_prestacao_models.Prestacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace contrato_prestacao_models.Contrato
{
    public class ContratoModel
    {
        [Key]
        public int ContratoId { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int QtdParcelas { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O valor financiado deve ser maior que zero")]
        public decimal ValorFinanciado { get; set; }

        public List<PrestacaoModel> Prestacoes { get; set; }
    }
}
