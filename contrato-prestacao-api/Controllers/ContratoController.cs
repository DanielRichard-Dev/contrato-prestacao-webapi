using System;
using System.Collections.Generic;
using System.Linq;
using contrato_prestacao_models.Contrato;
using contrato_prestacao_models.Response;
using contrato_prestacao_repository.Contrato;
using contrato_prestacao_repository.Data;
using contrato_prestacao_repository.Prestacao;
using contrato_prestacao_service.Contrato;
using Microsoft.AspNetCore.Mvc;

namespace contrato_prestacao_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {


        [HttpGet("GetAll")]
        public ActionResult<ResponseModel<List<ResponseContratoModel>>> GetAll([FromServices] DataContext context)
        {
            var response = new ResponseModel<List<ResponseContratoModel>>();
            try
            {
                var service = new ContratoService(new ContratoRepository(context), new PrestacaoRepository(context));

                var _contrato = service.GetAll().ToList();

                response.ObjReturn = service.PopulaListReponseContrato(_contrato);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById/{id:int}")]
        public ActionResult<ResponseModel<ResponseContratoModel>> GetById(
            [FromServices] DataContext context,
            int id)
        {
            var response = new ResponseModel<ResponseContratoModel>();
            try
            {
                var service = new ContratoService(new ContratoRepository(context), new PrestacaoRepository(context));

                var contrato = service.Get(id);

                if (contrato != null)
                {
                    response.ObjReturn = service.PopulaResponseContrato(contrato);

                    return Ok(response);
                }
                else
                {
                    return BadRequest("O contrato não foi encontrado!");
                }
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
                    var service = new ContratoService(new ContratoRepository(context), new PrestacaoRepository(context));

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

        [HttpPost("Update")]
        public ActionResult<ResponseModel<ResponseContratoModel>> Update(
            [FromServices] DataContext context,
            [FromBody] ContratoModel contrato)
        {
            var response = new ResponseModel<ResponseContratoModel>();

            try
            {
                if (ModelState.IsValid)
                {
                    var service = new ContratoService(new ContratoRepository(context), new PrestacaoRepository(context));

                    service.Update(contrato);

                    return Ok("Atualizado com sucesso!");
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

        [HttpDelete("DeleteById/{id:int}")]
        public ActionResult DeleteById(
            [FromServices] DataContext context,
            int id)
        {
            try
            {
                var service = new ContratoService(new ContratoRepository(context), new PrestacaoRepository(context));

                service.Delete(id);

                return Ok("Deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}