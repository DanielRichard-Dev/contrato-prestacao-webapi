using System;
using System.Collections.Generic;
using System.Text;

namespace contrato_prestacao_models.Response
{
    public class ResponseModel<T>
    {
        public bool Success { get; set; } = true;
        public T ObjReturn { get; set; }
        public string ErroMessage { get; set; }
        public Exception Exception { get; set; }
    }
}
