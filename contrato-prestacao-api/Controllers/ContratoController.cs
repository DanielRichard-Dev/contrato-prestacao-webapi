using System;
using System.Collections.Generic;
using System.Linq;
using contrato_prestacao_models.Contrato;
using contrato_prestacao_models.Response;
using contrato_prestacao_repository.Contrato;
using contrato_prestacao_repository.Data;
using contrato_prestacao_service.Contrato;
using Microsoft.AspNetCore.Mvc;

namespace contrato_prestacao_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        

        [HttpGet("Get")]
        public ActionResult<ResponseModel<List<ContratoModel>>> Get([FromServices] DataContext context)
        {
            var response = new ResponseModel<List<ContratoModel>>();
            try
            {
                var service = new ContratoService(new ContratoRepository(context));

                response.ObjReturn = service.GetAll().ToList();

                //var contrato = context.Contrato.ToList();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Insert")]
        public ActionResult<ResponseModel<ResponseContratoModel>> Insert(
            [FromServices] DataContext context,
            [FromBody] ContratoModel contrato)
        {
            var response = new ResponseModel<ResponseContratoModel>();

            try
            {
                if (ModelState.IsValid)
                {
                    var service = new ContratoService(new ContratoRepository(context));

                    contrato = service.Insert(contrato);
                    response.ObjReturn = service.PopulaResponseContrato(contrato);

                    return Ok(response);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErroMessage = ex.Message;
                response.Exception = ex;
                return response;
            }
        }
    }
}