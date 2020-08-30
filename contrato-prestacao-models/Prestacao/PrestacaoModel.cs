using contrato_prestacao_models.Contrato;
using contrato_prestacao_models.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace contrato_prestacao_models.Prestacao
{
    public class PrestacaoModel
    {
        [Key]
        public int PrestacaoId { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime DataVencimento  { get; set; }

        public DateTime DataPagamento { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O valor financiado deve ser maior que zero")]
        public decimal Valor { get; set; }

        public StatusPrestacaoEnum Status { get; set; }
    }
}
