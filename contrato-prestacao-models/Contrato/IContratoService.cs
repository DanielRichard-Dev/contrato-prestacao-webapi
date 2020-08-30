using contrato_prestacao_models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace contrato_prestacao_models.Contrato
{
    public interface IContratoService : IService<ContratoModel>
    {
        IList<ContratoModel> GetByStatus(StatusPrestacaoEnum status);
    }
}
